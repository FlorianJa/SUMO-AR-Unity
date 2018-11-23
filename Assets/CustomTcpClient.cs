using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using UnityEngine;

#if UNITY_WSA
using System.Threading.Tasks;
#endif

public class CustomTcpClient : MonoBehaviour
{
    public event EventHandler<byte[]> DataReceived;
    public bool Connected { get
        {
#if UNITY_WSA
            return false;
#endif

#if UNITY_EDITOR || UNITY_ANDROID|| UNITY_STANDALONE
            return client.Connected;
#endif
        }
    }

#if UNITY_WSA
    private bool _useUWP = true;
    private Windows.Networking.Sockets.StreamSocket socket;
    private Task exchangeTask;
#endif

#if UNITY_EDITOR || UNITY_ANDROID || UNITY_STANDALONE
    private bool _useUWP = false;
    System.Net.Sockets.TcpClient client;
    System.Net.Sockets.NetworkStream stream;
    private Thread exchangeThread;
#endif

    private StreamWriter writer;
    private StreamReader reader;

    public void Connect(string host, string port)
    {
        if (_useUWP)
        {
            ConnectUWP(host, port);
        }
        else
        {
            ConnectUnity(host, port);
        }
    }



#if UNITY_EDITOR || UNITY_ANDROID|| UNITY_STANDALONE
    private void ConnectUWP(string host, string port)
#else
    private async void ConnectUWP(string host, string port)
#endif
    {
#if UNITY_EDITOR || UNITY_ANDROID|| UNITY_STANDALONE
#else
        try
        {
            if (exchangeTask != null) StopExchange();
        
            socket = new Windows.Networking.Sockets.StreamSocket();
            Windows.Networking.HostName serverHost = new Windows.Networking.HostName(host);
            await socket.ConnectAsync(serverHost, port);
        
            Stream streamOut = socket.OutputStream.AsStreamForWrite();
            writer = new StreamWriter(streamOut) { AutoFlush = true };
        
            Stream streamIn = socket.InputStream.AsStreamForRead();
            reader = new StreamReader(streamIn);

            RestartExchange();
        }
        catch (Exception e)
        {
        }
#endif
    }

    private void ConnectUnity(string host, string port)
    {
#if UNITY_WSA
#else
        try
        {
            if (exchangeThread != null) StopExchange();

            client = new System.Net.Sockets.TcpClient(host, Int32.Parse(port));
            stream = client.GetStream();
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream) { AutoFlush = true };

            RestartExchange();
        }
        catch (Exception e)
        {
        }
#endif
    }

    private bool reading = false;
    private bool readStopRequested = false;
    private string lastPacket = null;

    

    public void RestartExchange()
    {
#if UNITY_EDITOR || UNITY_ANDROID|| UNITY_STANDALONE
        if (exchangeThread != null) StopExchange();
        readStopRequested = false;
        exchangeThread = new System.Threading.Thread(ReadPackets);
        exchangeThread.Start();
#else
        if (exchangeTask != null) StopExchange();
        readStopRequested = false;
        exchangeTask = Task.Run(() => ReadPackets());
#endif
    }

    public void Update()
    {
        //update gameobjects here (in main thread)
    }

    public bool SentData(byte[] data)
    {
#if UNITY_EDITOR || UNITY_ANDROID|| UNITY_STANDALONE
        if (writer == null || reader == null) return false;
        client.Client.Send(data);
        return true;
#else
        return true;
#endif
    }

    public void ReadPackets()
    {
        
        string received = null;
#if UNITY_EDITOR || UNITY_ANDROID|| UNITY_STANDALONE
        byte[] _receiveBuffer = new byte[client.SendBufferSize];
#endif
        while (!readStopRequested)
        {
            if (writer == null || reader == null) continue;
            reading = true;

#if UNITY_EDITOR || UNITY_ANDROID|| UNITY_STANDALONE
            var bytesRead = stream.Read(_receiveBuffer, 0, client.SendBufferSize);
            if (bytesRead < 0)
            {
                // Read returns 0 if the client closes the connection
                throw new IOException();
            }
            var response = _receiveBuffer.Take(bytesRead).ToArray();

            OnDataReceived(response);
            // handle response here (somehow)
#else
            reader.Read();
            received = reader.ReadLine();
#endif
        }
        reading = false;

    }

    private void OnDataReceived(byte[] response)
    {
        DataReceived?.Invoke(this, response);
    }

    public void StopExchange()
    {
        readStopRequested = true;

#if UNITY_EDITOR || UNITY_ANDROID|| UNITY_STANDALONE
        if (exchangeThread != null)
        {
            exchangeThread.Abort();
            stream.Close();
            client.Close();
            writer.Close();
            reader.Close();

            stream = null;
            exchangeThread = null;
        }
#else
        if (exchangeTask != null) {
            exchangeTask.Wait();
            socket.Dispose();
            writer.Dispose();
            reader.Dispose();

            socket = null;
            exchangeTask = null;
        }
#endif
        writer = null;
        reader = null;
    }

    public void OnDestroy()
    {
        StopExchange();
    }

}