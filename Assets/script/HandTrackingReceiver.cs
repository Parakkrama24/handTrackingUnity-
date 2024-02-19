using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class HandTrackingReceiver : MonoBehaviour

{   Thread resiveThread = null;
    public int port = 5052;
    UdpClient client;
    IPEndPoint remoteEndPoint;
    public bool startresiving = true;
    public bool printToConsole= false;
    public string data;

    void Start()
    {
        /*remoteEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
        client = new UdpClient(port);*/

        resiveThread = new Thread(new ThreadStart(ReceiveData));
        resiveThread.IsBackground = true;
        resiveThread.Start();
    }

    private void ReceiveData()
    {
        client= new UdpClient(port);
        while(startresiving)
        {
            try
            {
                IPEndPoint anyIp = new IPEndPoint(IPAddress.Any, 0);
                byte[] dataByte = client.Receive(ref anyIp);
                data = Encoding.UTF8.GetString(dataByte);

                if (printToConsole) { print(data); }

            }
            catch{ 
                
            }

        }
    }

    /*void Update()
    {
        try
        {
            byte[] data = client.Receive(ref remoteEndPoint);
            string message = Encoding.UTF8.GetString(data);
            string[] values = message.Split(',');

            // Assuming you are sending X, Y, Z coordinates for each landmark
            float x = float.Parse(values[0]);
            float y = float.Parse(values[1]);
            float z = float.Parse(values[2]);

            // Update the position of your Unity object
            transform.position = new Vector3(x, y, z);
        }
        catch (System.Exception e)
        {
            Debug.LogError(e.ToString());
        }
    }

    void OnApplicationQuit()
    {
        client.Close();
    }*/
}
