using CodingConnected.TraCI.NET;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour {


    public CustomTcpClient tcpClient;

	// Use this for initialization
	void Start () {

        if (tcpClient == null) return;

        tcpClient.Connect("141.99.199.199", "4000");

        var bytes = new byte[] { 0, 0, 0, 10, 6, 2, 0, 0, 0, 0 };
        tcpClient.SentData(bytes);


        bytes = new byte[] { 0, 0, 0, 18, 14, 164, 0, 0, 0, 0, 7, 105, 103, 110, 111, 114, 101, 100 };

        tcpClient.SentData(bytes);
        }
	
	// Update is called once per frame
	void Update () {
		
	}
}
