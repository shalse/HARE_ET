using UnityEngine;
//using SharpConnect;
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
    int[] failLevel;
    string[] failTime;
    int failNum = 0, increment;
    string timeStart, timeFinish;
    bool dynColor, dynPos;
    string dataPacket;

    void Start()
    {
        failLevel = new int[3];
        failTime = new string[3];
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
        string connResult = fnConnectResult(sNetIP, 10000);

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

    void PuzzleBegun(int inc)
    {
        increment = inc;
        timeStart = System.DateTime.Now.ToString("f");
        failNum = 0;
        //fnPacketTest("Begun" + timeStart);
        Debug.Log("Begun" + timeStart);
    }

    void PuzzleEnded()
    {
        timeFinish = System.DateTime.Now.ToString("f");
        //fnPacketTest("Ended" + timeFinish);
        Debug.Log("Ended" + timeFinish);
    }

    void Fail(int level)
    {
        failLevel[failNum] = level;
        failTime[failNum] = System.DateTime.Now.ToString("f");
        failNum++;
        //fnPacketTest("Failure#" + failNum);
        Debug.Log("Failure#" + failNum);
    }

    void SetColor(bool isDiff)//Colors set to move, but pattern remains same
    {
        dynColor = isDiff;
    }

    void SetPos(bool isDiff)//Pattern set to move, but colors remain same order
    {
        dynPos = isDiff;
    }

    void PostData()
    {
        string tempData = "?begin=" + timeStart +
            "&end=" + timeFinish +
            "&incr=" + increment +
            "&faillevel1=" + failLevel[0] + "&failTime1=" + failTime[0] +
            "&faillevel2=" + failLevel[1] + "&failTime2=" + failTime[1] +
            "&faillevel3=" + failLevel[2] + "&failTime3=" + failTime[2] +
            "&color=" + dynColor +
            "&position=" + dynPos;

        dataPacket = "!SAY" + tempData.Length.ToString("00000") + tempData;

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
            System.IO.File.WriteAllText("SAYDATA" + time + ".txt", dataPacket);
        }

    }
}