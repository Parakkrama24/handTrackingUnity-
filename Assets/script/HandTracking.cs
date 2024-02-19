using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class HandTracking : MonoBehaviour
{
    public HandTrackingReceiver udpRecever;
    public GameObject[] handPoints;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string data = udpRecever.data; 
        data = data.Remove(0, 1);
        data= data.Remove(data.Length-1, 1);
        Debug.Log(data);
        string[] points= data.Split(',');
        Debug.Log(points[0]);

        for(int i = 1; i < 21; i++)
        {
            float x = float.Parse(points[i*3])/100;
            float y= float.Parse(points[i*3+1])/100;
            float z= float.Parse(points[i*3+2])/100;
            handPoints[i].transform.localPosition = new Vector3(x,y,z);
         
        }
    }
}
