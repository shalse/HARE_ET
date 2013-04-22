//this will become the "prototype" for the ETController and contains all the api function/struct definitions used 
using UnityEngine;
using System.Collections;
using System.Text;
using System.Runtime.InteropServices;
using System;

public class ETController {
	
	//used for connecting to ET
	[DllImport("iViewXAPI.dll", EntryPoint = "iV_Connect")]
    private static extern int Unmanaged_Connect(StringBuilder sendIPAddress, int sendPort, StringBuilder recvIPAddress, int receivePort);
    
	//used to disconnect
    [DllImport("iViewXAPI.dll", EntryPoint = "iV_Disconnect")]
    private static extern int Unmanaged_Disconnect();
	
	//used to setup sample call back
	[DllImport("iViewXAPI.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "iV_SetSampleCallback")]
    private static extern void Unmanaged_SetSampleCallback(MulticastDelegate sampleCallbackFunction);
	
    //function definitions
	//connect 
	public int iV_Connect(StringBuilder sendIP, int sendPort, StringBuilder receiveIP, int receivePort)
    {
    	return Unmanaged_Connect(sendIP, sendPort, receiveIP, receivePort);
    }
    //disconnect
	public int iV_Disconnect()
    {
        return Unmanaged_Disconnect();
    }
    //setup samplecallback
	public void iV_SetSampleCallback(MulticastDelegate sampleCallback)
    {
        Unmanaged_SetSampleCallback(sampleCallback);
    }
    //struct definitions
    //eye tracking data (one for each eye)
	public struct EyeDataStruct
    {
        public double gazeX;
        public double gazeY;
        public double diam;
        public double eyePositionX;
        public double eyePositionY;
        public double eyePositionZ;
    };
    //eye tracker data
	public struct SampleStruct
    {
        public Int64 timestamp;
        public EyeDataStruct leftEye;
        public EyeDataStruct rightEye;
        public int planeNumber;
    };

}


