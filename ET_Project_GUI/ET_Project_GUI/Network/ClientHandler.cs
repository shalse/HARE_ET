using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace ET_Project_GUI.Network
{
    class ClientHandler
    {
        TcpClient clientSocket;
        string clNo;

        public delegate void newMessage(string msg);
        public newMessage newMessageToSend;
        public bool running;

        public ClientHandler()
        {
        }
        public void startClient(TcpClient inClientSocket, string clineNo)
        {
            this.clientSocket = inClientSocket;
            this.clNo = clineNo;
            running = true;
        }
        public void doListen()
        {
            byte[] recievedBytes = new byte[1000];
            while (running)
            {
                    try
                    {
                        NetworkStream networkStream = clientSocket.GetStream();
 
                        
                        //check for abnormal disconnects
                        if (!clientSocket.Connected || (clientSocket.Client.Poll(1000, SelectMode.SelectRead) && clientSocket.Client.Available == 0))
                        {
                            Console.WriteLine("client DC'ed");
                            running = false;
                        }
                        //everything good
                        else
                        {
                            networkStream.Read(recievedBytes, 0, recievedBytes.Length);
                            networkStream.Flush();

                            //get message on buffer
                            string fullMessage = Encoding.ASCII.GetString(recievedBytes);
                            newMessageToSend(fullMessage);
                        }
                        
                    }
                    catch (SocketException)
                    {
                        //abnormal disconnected
                        clientSocket.Close();
                        running = false;
                    }             
            }
        }
    }
}
