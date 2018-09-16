using CodingConnected.TraCI.NET;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class TraCIConnection : MonoBehaviour {

    public string Hostname;
    public int Port;
    private TraCIClient client;
    private Task Task;

    // Use this for initialization
    async void Start () {

        client = new TraCIClient();

        await client.ConnectAsync(Hostname, Port);

        Task = Task.Run(() => UpdateSim());
    }
	
	// Update is called once per frame
	//async void Update () {
 //       await client.Control.SimStep();
 //       await Task.Delay(10);
 //   }

    async void UpdateSim()
    {
        while (true)
        {
            await client.Control.SimStep();
            await Task.Delay(10);
            var allVehicles = await client.Vehicle.GetIdList();
            
        }
    }

}
