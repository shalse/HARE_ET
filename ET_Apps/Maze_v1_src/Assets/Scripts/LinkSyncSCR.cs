using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
//using SharpConnect;
using System.Security.Permissions;
using System.Net.Sockets;
using System;
using System.IO;

public class LinkSyncSCR : MonoBehaviour
{
    //public Connector test = new Connector();
    string lastMessage;

    //Connection info
    string sNetIP = "127.0.0.1";
    const int PORT_NUM = 10000;
    bool isConnected = false;
    private TcpClient client;

    //Database info
    int wallCollisions = 0;
    string timeStart = "", timeFinish = "";
    float difficulty = 0f;
    string dataPacket;

    void Start()
    {

    }

    void Update()
    {
        //if (isConnected)//only trace info if you're connected
        //{
        //    if (Input.GetKeyDown("space"))
        //    {
        //        Debug.Log("space key was pressed");
        //        test.fnPacketTest("space key was pressed");
        //    }

        //    if (Input.GetKeyDown("escape"))
        //    {
        //        Debug.Log("escape key was pressed");
        //        test.fnPacketTest("escape key was pressed");
        //    }
        //    if (test.strMessage != "JOIN")
        //    {
        //        if (test.res != lastMessage)
        //        {
        //            Debug.Log(test.res);
        //            lastMessage = test.res;
        //        }
        //    }
        //}
    }

    void OnApplicationQuit()
    {
        //try { test.fnDisconnect(); }
        //catch { }
    }

    void SetNetIP(string ip)
    {
        sNetIP = ip;
    }

    void AttemptConnect()
    {
        string connResult = "";
        if (isConnected)
        {
            //do nothing
        }
        else
        {
            connResult = fnConnectResult(sNetIP, 10000);
        }
        if (connResult == "Connection Succeeded")
        {
            isConnected = true;
        }

        Debug.Log(connResult);
    }

    public string fnConnectResult(string sNetIP, int iPORT_NUM)
    {
        try
        {
            client = new TcpClient(sNetIP, PORT_NUM);
            return "Connection Succeeded";
        }
        catch (Exception ex)
        {
            return "Server is not active.  Please start server and try again.      " + ex.ToString();
        }
    }
    public void fnPacketTest(string sInfo)
    {
        //SendData("CHAT|" + sInfo);
        if (isConnected)
        {
            SendData(sInfo);
        }
    }
    // Use a StreamWriter to send a message to server.
    private void SendData(string data)
    {
        StreamWriter writer = new StreamWriter(client.GetStream());
        writer.Write(data + (char)13);
        writer.Flush();
    }

    void MazeBegun(float diff)
    {
        timeStart = System.DateTime.Now.ToString("f");
        difficulty = diff;
        AttemptConnect();
        fnPacketTest("START");
        Debug.Log("Begun" + timeStart + "Difficulty" + difficulty);
    }

    void MazeEnded()
    {
        timeFinish = System.DateTime.Now.ToString("f");
        //fnPacketTest("Ended" + timeFinish);
        Debug.Log("Ended" + timeFinish);
    }

    void WallCollide()
    {
        wallCollisions++;
        //fnPacketTest("Wall bump #" + wallCollisions);
        Debug.Log("Wall bump #" + wallCollisions);
    }

    void PostData()
    {
        string tempData = "?begin=" + timeStart +
            "&end=" + timeFinish +
            "&difficulty=" + difficulty +
            "&wallBumps=" + wallCollisions;

        dataPacket = "!MAZ" + tempData.Length.ToString("00000") + tempData;

        AttemptConnect();//Connects before sending data

        if (isConnected)//Checks if connection succeeded
        {
            Debug.Log(dataPacket);

            fnPacketTest(dataPacket);
        }
        else
        {
            string time = System.DateTime.Now.ToString("u");
            time = time.Replace(':', '_');
            System.IO.File.WriteAllText("MAZDATA" + time + ".txt", dataPacket);
        }

    }
}
