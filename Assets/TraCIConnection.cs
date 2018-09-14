using CodingConnected.TraCI.NET;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class TraCIConnection : MonoBehaviour {

    private TraCIClient client;
    private Task Task;

    // Use this for initialization
    async void Start () {

        client = new TraCIClient();

        await client.ConnectAsync("141.99.199.199", 4000);

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
        }
    }

}
