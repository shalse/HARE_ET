//This code is a quick and dirty demo of using the ET, it connects and gets 20 data points after which it disconnects 
using UnityEngine;
using System.Collections;
using System.Text;
using System;

public class cubeeeeOnClick : MonoBehaviour {
	
	//var decl
	private ETController ETDevice;
	private string sendIP = "127.0.0.1";
	private int sendPort = 4444; 
	private string receiveIP = "127.0.0.1"; 
	private int receivePort = 5555;  
	
	//func decl
	private delegate void GetSampleCallback(ETController.SampleStruct sampleData);
	
	//get data
	private GetSampleCallback m_SampleCallback;
	private int maxSamples = 20;
	// Use this for initialization
	void Start () {
		
		int ret = 0;
		ETDevice = new ETController();
		
		try
		{
			//connection code with corresponding et errors
			ret = ETDevice.iV_Connect(new StringBuilder(sendIP), Convert.ToInt32(sendPort), new StringBuilder(receiveIP), Convert.ToInt32(receivePort));
            if (ret == 1) Debug.Log("iV_Connect: connection established");
            else if (ret == 100) Debug.LogError("iV_Connect: failed to establish connection");
            else if (ret == 112) Debug.LogError("iV_Connect error: wrong parameter");
            else if (ret == 123) Debug.LogError("iV_Connect error: failed to bind sockets");
			else Debug.LogError("Connect Failed! Check cubeeeeOnClick.cs");
		}
		catch(Exception ex)
		{
			//some error handling code
			Debug.LogError("Connect Failed! " + ex.Message);
		}
		
		//call back forgettin data
		m_SampleCallback = new GetSampleCallback(GetSampleCallbackFunction);
		ETDevice.iV_SetSampleCallback(m_SampleCallback);
	
	}
	

	//printout the data from the callback
	void GetSampleCallbackFunction(ETController.SampleStruct sampleData)
        {
			if(maxSamples >= 0)
			{
	            Debug.Log("Data from SampleCallback - timestamp: " + sampleData.timestamp.ToString() +
	                " - GazeRX: " + sampleData.rightEye.gazeX.ToString() +
	                " - GazeRY: " + sampleData.rightEye.gazeY.ToString() +
	                " - GazeLX: " + sampleData.leftEye.gazeX.ToString() +
	                " - GazeLY: " + sampleData.leftEye.gazeY.ToString() +
	                " - DiamRX: " + sampleData.rightEye.diam.ToString() +
	                " - DiamLX: " + sampleData.leftEye.diam.ToString() +
	                " - DistanceR: " + sampleData.rightEye.eyePositionZ.ToString() +
	                " - DistanceL: " + sampleData.leftEye.eyePositionZ.ToString());
				maxSamples--;
			}
			else
			{
				int ret = 0;
				try
	            {
	                ret = ETDevice.iV_Disconnect();
	                if (ret == 1) Debug.Log("Disconnect Succesfull!");
	                if (ret == 124) Debug.Log("iV_Disconnect error: could not delete sockets");
	            }
	            catch (System.Exception exc)
	            {
	                Debug.LogError("Exception during iV_Disconnect: " + exc.Message);
	            }
			}
        }
	// Update is called once per frame
	void Update () {
		
	}
}
