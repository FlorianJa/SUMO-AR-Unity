using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using CodingConnected.TraCI.NET.Commands;
using CodingConnected.TraCI.NET.Helpers;
using CodingConnected.TraCI.NET.Types;

#if NLOG
using NLog;
#endif

namespace CodingConnected.TraCI.NET
{
    /// <summary>
    /// A simple )and yet incomplete) client-side implementation of TraCI, for using SUMO
    /// with .NET applications.
    /// </summary>
    public class TraCIClient
    {

#if NLOG
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
#endif

        #region Events
        public event EventHandler<SubscriptionEventArgs> InductionLoopSubscription;
        public event EventHandler<SubscriptionEventArgs> MultiEntryMultiExitDetectorSubscription;
        public event EventHandler<SubscriptionEventArgs> TrafficLightSubscription;
        public event EventHandler<SubscriptionEventArgs> LaneSubscription;
        public event EventHandler<SubscriptionEventArgs> VehicleSubscription;
        public event EventHandler<SubscriptionEventArgs> VehicleTypeSubscription;
        public event EventHandler<SubscriptionEventArgs> RouteSubscription;
        public event EventHandler<SubscriptionEventArgs> PointOfIntrestSubscription;
        public event EventHandler<SubscriptionEventArgs> PolygonSubscription;
        public event EventHandler<SubscriptionEventArgs> JunctionSubscription;
        public event EventHandler<SubscriptionEventArgs> EdgeSubscription;
        public event EventHandler<SubscriptionEventArgs> SimulationSubscription;
        public event EventHandler<SubscriptionEventArgs> PersonSubscription;
        public event EventHandler<SubscriptionEventArgs> LaneAreaSubscription;
        public event EventHandler<SubscriptionEventArgs> GUISubscription;
        #endregion

        #region Fields
#if UNITY_EDITOR
        private TcpClient _client;
        private NetworkStream _stream;
#endif

#if !UNITY_EDITOR
        private Windows.Networking.Sockets.StreamSocket socket;
        private Task exchangeTask;
        private Stream streamOut;
        private Stream streamIn;
        private StreamReader reader;
#endif
        private readonly byte[] _receiveBuffer = new byte[32768];
        private readonly char[] _receiveCharBuffer = new char[32768];
        private ControlCommands _control;
	    private InductionLoopCommands _inductionLoop;
	    private LaneAreaDetectorCommands _laneAreaDetector;
	    private MultiEntryExitDetectorCommands _multiEntryExitDetector;
	    private LaneCommands _lane;
	    private TrafficLightCommands _trafficLight;
	    private VehicleCommands _vehicle;
	    private PersonCommands _person;
	    private VehicleTypeCommands _vehicleType;
	    private RouteCommands _route;
	    private POICommands _POI;
	    private PolygonCommands _polygon;
	    private GuiCommands _gui;
	    private JunctionCommands _junction;
	    private EdgeCommands _edge;
	    private SimulationCommands _simulation;

	    #endregion // Fields

        #region Properties

	    public ControlCommands Control => _control ?? (_control = new ControlCommands(this));

	    public InductionLoopCommands InductionLoop => _inductionLoop ?? (_inductionLoop = new InductionLoopCommands(this));

	    public LaneAreaDetectorCommands LaneAreaDetector => _laneAreaDetector ?? (_laneAreaDetector = new LaneAreaDetectorCommands(this));

	    public MultiEntryExitDetectorCommands MultiEntryExitDetector => _multiEntryExitDetector ?? (_multiEntryExitDetector = new MultiEntryExitDetectorCommands(this));

	    public LaneCommands Lane => _lane ?? (_lane = new LaneCommands(this));

	    public TrafficLightCommands TrafficLight => _trafficLight ?? (_trafficLight = new TrafficLightCommands(this));

	    public VehicleCommands Vehicle => _vehicle ?? (_vehicle = new VehicleCommands(this));

	    public PersonCommands Person => _person ?? (_person = new PersonCommands(this));
	    
	    public VehicleTypeCommands VehicleType => _vehicleType ?? (_vehicleType = new VehicleTypeCommands(this));

		public RouteCommands Route => _route ?? (_route = new RouteCommands(this));

		public POICommands POI => _POI ?? (_POI = new POICommands(this));

		public PolygonCommands Polygon => _polygon ?? (_polygon = new PolygonCommands(this));

	    public JunctionCommands Junction => _junction ?? (_junction = new JunctionCommands(this));

	    public EdgeCommands Edge => _edge ?? (_edge = new EdgeCommands(this));

	    public SimulationCommands Simulation => _simulation ?? (_simulation = new SimulationCommands(this));

	    public GuiCommands Gui => _gui ?? (_gui = new GuiCommands(this));

	    #endregion // Properties

        #region Public Methods

        /// <summary>
        /// Connects to the SUMO server instance
        /// </summary>
        /// <param name="hostname">Hostname or ip address where SUMO is running</param>
        /// <param name="port">Port at which SUMO exposes the API</param>
        public async Task ConnectAsync(string hostname, int port)
        {
#if UNITY_EDITOR
            _client = new TcpClient
            {
                ReceiveBufferSize = 32768,
                SendBufferSize = 32768
            };
            await _client.ConnectAsync(hostname, port);
            _stream = _client.GetStream();
#endif

#if !UNITY_EDITOR
            socket = new Windows.Networking.Sockets.StreamSocket();
            Windows.Networking.HostName serverHost = new Windows.Networking.HostName(hostname);
            await socket.ConnectAsync(serverHost, port.ToString());
        
            streamOut = socket.OutputStream.AsStreamForWrite();

            streamIn = socket.InputStream.AsStreamForRead();
            reader = new StreamReader(streamIn);
#endif
        }

#endregion // Public Methods


#region Public Methods

	    internal TraCIResult[] SendMessage(TraCICommand command)
	    {
            var msg = TraCIDataConverter.GetMessageBytes(command);
#if UNITY_EDITOR
            if (!_client.Connected)
		    {
			    return null;
		    }
            		    
		    _client.Client.Send(msg);
			var bytesRead = _stream.Read(_receiveBuffer, 0, 32768);
#endif
#if !UNITY_EDITOR
            streamOut.Write(msg,0,msg.Length);
            streamOut.Flush();
            var bytesRead = streamIn.Read(_receiveBuffer, 0, 32768);
#endif
            if (bytesRead < 0)
            {
                // Read returns 0 if the client closes the connection
                throw new IOException();
            }

            var revLength = _receiveBuffer.Take(4).Reverse().ToArray();
            var totlength = BitConverter.ToInt32(revLength, 0);
            var response = new List<byte>(); 
            response.AddRange(_receiveBuffer.Take(bytesRead).ToArray());

            if (bytesRead != totlength)
            {
                while (bytesRead < totlength)
                {
#if UNITY_EDITOR
                    var innerBytesRead = _stream.Read(_receiveBuffer, 0, 32768);
#endif
#if !UNITY_EDITOR
                    var innerBytesRead = streamIn.Read(_receiveBuffer, 0, 32768);
#endif
                    response.AddRange(_receiveBuffer.Take(innerBytesRead).ToArray());
                    bytesRead += innerBytesRead;
                }
            }
            //var response = _receiveBuffer.Take(bytesRead).ToArray();
            var trresponse = TraCIDataConverter.HandleResponse(response.ToArray());
            return trresponse?.Length > 0 ? trresponse : null;
            //return null;
        }

#endregion // Public Methods

#region Private Methods

#endregion // Private Methods

#region Constructor

        public TraCIClient()
	    {
	    }

#endregion // Constructor


#region EventHandlers
        internal void OnPersonSubscription(SubscriptionEventArgs eventArgs)
        {
            PersonSubscription?.Invoke(this, eventArgs);
        }

        internal void OnLaneAreaSubscription(SubscriptionEventArgs eventArgs)
        {
            LaneAreaSubscription?.Invoke(this, eventArgs);
        }

        internal void OnGUISubscription(SubscriptionEventArgs eventArgs)
        {
            GUISubscription?.Invoke(this, eventArgs);
        }

        internal void OnSimulationSubscription(SubscriptionEventArgs eventArgs)
        {
            SimulationSubscription?.Invoke(this, eventArgs);
        }

        internal void OnEdgeSubscription(SubscriptionEventArgs eventArgs)
        {
            EdgeSubscription?.Invoke(this, eventArgs);
        }

        internal void OnJunctionSubscription(SubscriptionEventArgs eventArgs)
        {
            JunctionSubscription?.Invoke(this, eventArgs);
        }

        internal void OnPolygonSubscription(SubscriptionEventArgs eventArgs)
        {
            PolygonSubscription?.Invoke(this, eventArgs);
        }

        internal void OnPOISubscription(SubscriptionEventArgs eventArgs)
        {
            PointOfIntrestSubscription?.Invoke(this, eventArgs);
        }

        internal void OnRouteSubscription(SubscriptionEventArgs eventArgs)
        {
            RouteSubscription?.Invoke(this, eventArgs);
        }

        internal void OnVehicleTypeSubscription(SubscriptionEventArgs eventArgs)
        {
            VehicleTypeSubscription?.Invoke(this, eventArgs);
        }

        internal void OnVehicleSubscription(SubscriptionEventArgs eventArgs)
        {
            VehicleSubscription?.Invoke(this, eventArgs);
        }

        internal void OnLaneSubscription(SubscriptionEventArgs eventArgs)
        {
            LaneSubscription?.Invoke(this, eventArgs);
        }

        internal void OnTrafficLightSubscription(SubscriptionEventArgs eventArgs)
        {
            TrafficLightSubscription?.Invoke(this, eventArgs);
        }

        internal void OnMultiEntryExitSubscription(SubscriptionEventArgs eventArgs)
        {
            MultiEntryMultiExitDetectorSubscription?.Invoke(this, eventArgs);
        }

        internal virtual void OnInductionLoopSubscription(SubscriptionEventArgs eventArgs)
        {
            InductionLoopSubscription?.Invoke(this, eventArgs);
        }
#endregion
    }
}
