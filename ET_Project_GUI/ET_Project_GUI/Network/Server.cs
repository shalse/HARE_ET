﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ET_Project_GUI.Network
{
    class Server
    {
        private List<ClientHandler> clientList;
        private int count = 0;
        
        //send new message to main
        public delegate void newMessage(string msg);
        public newMessage newMessageToSend;

        public void startServer()
        {
            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                }
            }
            TcpListener serverSocket = new TcpListener(IPAddress.Parse(localIP), 10000);
            TcpClient clientSocket = default(TcpClient);
            clientList = new List<ClientHandler>();

            int counter = 0;

            serverSocket.Start();
            Console.WriteLine(" >> " + "Server Started");

            counter = 0;
            while (true)
            {
                    counter += 1;
                    clientSocket = serverSocket.AcceptTcpClient();
                    Console.WriteLine(" >> " + "Client No:" + Convert.ToString(counter) + " has connected");
                    ClientHandler client = new ClientHandler();
                    clientList.Add(client);
                    client.startClient(clientSocket, Convert.ToString(counter));
                    client.newMessageToSend = messageHandler;
                    startClientThread();
            }

            serverSocket.Stop();
            Console.WriteLine(" >> " + "exit");
            Console.ReadLine();
        }
        public void startClientThread()
        {
            ClientHandler temp = clientList[count];
            Thread clientThread = new Thread(new ThreadStart(temp.doListen));
            clientThread.Name = "Client " + count + " Thread";
            clientThread.Start();
            count++;
        }
        
        public void messageHandler(string message)
        {
            message = message.Trim('\0');
            newMessageToSend(message);
            
            Console.WriteLine(">>> message: "+message);
            
        }
    }
}
