using CodingConnected.TraCI.NET;
using CodingConnected.TraCI.NET.Types;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class TraCIConnection : MonoBehaviour {

    public string Hostname;
    public int Port;
    public bool SimulationPaused;

    public GameObject CarPrefab;
    public GameObject CarContainer;

    private TraCIClient client;
    private Task BackgroundSimulationTask;
    private TraCIResponse<List<string>> vehicleIds;
    private object vehicleSyncLock = new object();
    private bool vehicleIdRecieved;
    private Dictionary<string,GameObject> _cars;

    private Queue<string> newCars = new Queue<string>();
    private object newCarLock = new object();
    private object updateDictionary = new object();

    // Use this for initialization
    async void Start ()
    {
        vehicleIds = new TraCIResponse<List<string>>();
        _cars = new Dictionary<string, GameObject>();
        client = new TraCIClient();

        await client.ConnectAsync(Hostname, Port);
        //client.VehicleSubscription += Client_VehicleSubscription;
        //client.EdgeSubscription += Client_EdgeSubscription;
        
        //var allEdges = client.Edge.GetIdList();

        //foreach (var edgeId in allEdges.Content)
        //{
        //    client.Edge.Subscribe(edgeId, 0, 7200 * 1000, new List<byte>() {TraCIConstants.VAR_CO2EMISSION });
        //}

        //BackgroundSimulationTask = Task.Run(() => UpdateSim());

    }

    private void Client_EdgeSubscription(object sender, CodingConnected.TraCI.NET.Types.SubscriptionEventArgs e)
    {
       
    }

    private void Client_VehicleSubscription(object sender, CodingConnected.TraCI.NET.Types.SubscriptionEventArgs e)
    {
        var pos = e.Responses[0] as TraCIResponse<Position2D>;
        //var angle = e.Responses[1] as TraCIResponse<double>;
        //UnityMainThreadDispatcher.Instance().Enqueue(UpdateCar(e.ObjecId, pos.Content));//,angle.Content));
    }

    public IEnumerator UpdateCar(string id, Position2D pos, double angle=0) //, double angle
    {
        //lock (updateDictionary)
        //{
            _cars[id].transform.position = new Vector3((float)pos.X * 0.0002f, 0, (float)pos.Y * 0.0002f);
            _cars[id].transform.rotation = Quaternion.Euler(0, (float)angle, 0);
        //}
        yield return null;
    }

    public IEnumerator UpdateCars(List<TraCISubscriptionResponse> cars) //, double angle
    {
        foreach (var car in cars)
        {
            var pos = (car.Responses[0] as TraCIResponse<Position2D>).Content;
            var angle = (car.Responses[1] as TraCIResponse<double>).Content;
                //lock (updateDictionary)
        //{
            _cars[car.ObjectId].transform.position = new Vector3((float)pos.X * 0.0002f, 0, (float)pos.Y * 0.0002f);
            _cars[car.ObjectId].transform.rotation = Quaternion.Euler(0, (float)angle, 0);
            //}
        }

        yield return null;
    }

    public IEnumerator UpdateDicitionary(string id, bool removeFromDictionary = false) //, double angle
    {
        if (removeFromDictionary)
        {
            var tmp = _cars[id];
            _cars.Remove(id);

            Destroy(tmp);

        }
        else
        {
            var car = (GameObject)Instantiate(CarPrefab, CarContainer.transform);
            car.name = id;
            //lock (updateDictionary)
            //{
            _cars.Add(id, car);
            //}
        }
        yield return null;
    }

    public IEnumerator UpdateDicitionary(List<string> idList, bool removeFromDictionary = false) //, double angle
    {
        foreach (var id in idList)
        {
            if (removeFromDictionary)
            {
                var tmp = _cars[id];
                _cars.Remove(id);

                //Destroy(tmp);

            }
            else
            {
                var car = (GameObject)Instantiate(CarPrefab, CarContainer.transform);
                car.name = id;
                //lock (updateDictionary)
                //{
                _cars.Add(id, car);
                //}
            }
        }
        yield return null;
    }

    //Update is called once per frame
    float timer = 0;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 0.1f)
        {
            if (!SimulationPaused)
            {
                if (BackgroundSimulationTask == null || BackgroundSimulationTask.IsCompleted)
                {
                    timer = 0;

                    BackgroundSimulationTask = Task.Run(() =>
                    {
                        var tmp = client.Control.SimStep();
                        //if (tmp.Result != ResultCode.Success)
                        //{

                        //}

                        vehicleIds = client.Simulation.GetDepartedIDList();
                        //vehicleIdRecieved = true;
                        foreach (var id in vehicleIds.Content)
                        {
                            client.Vehicle.Subscribe(id, 0, 10000 * 1000, new List<byte>() { TraCIConstants.VAR_POSITION, TraCIConstants.VAR_ANGLE });
                        }

                        UnityMainThreadDispatcher.Instance().Enqueue(UpdateDicitionary(vehicleIds.Content));//,angle.Content));

                        vehicleIds = client.Simulation.GetArrivedIDList("");
                        //foreach (var id in vehicleIds.Content)
                        //{
                            UnityMainThreadDispatcher.Instance().Enqueue(UpdateDicitionary(vehicleIds.Content, true));
                        //}
                        var responses = tmp.Content as List<TraCISubscriptionResponse>;
                        //Debug.Log(responses.Count);
                        //if (responses != null)
                        //{
                        //    foreach (var response in responses)
                        //    {
                        UnityMainThreadDispatcher.Instance().Enqueue(UpdateCars(responses));//,angle.Content));
                        //    }
                        //}
                    });
                }
            }
        }
    }

    void UpdateSim()
    {
        while (true)
        {
            //if (!pauseSimulation)
            //{
            //    var tmp = client.Control.SimStep();
            //    if(tmp.Result != ResultCode.Success)
            //    {

            //    }
            //    lock (vehicleSyncLock)
            //    {
            //        vehicleIds = client.Simulation.GetDepartedIDList();
            //    }
            //    vehicleIdRecieved = true;

            //    lock (newCarLock)
            //    {
            //        while (newCars.Count > 0)
            //        {
            //            client.Vehicle.Subscribe(newCars.Dequeue(), 0, 7200 * 1000, new List<byte>() { TraCIConstants.VAR_POSITION }); //TraCIConstants.VAR_ANGLE
            //        }
            //    }

            //    //lock(vehicleSyncLock)
            //    //{
            //    //    vehicleIds.Clear();
            //    //    foreach (var id in tmpAllVehicles.Content)
            //    //    {
            //    //        vehicleIds.Add(id);
            //    //    }
            //    //}

            //    //System.Threading.Thread.Sleep(10);
            //}
        }
    }

}
