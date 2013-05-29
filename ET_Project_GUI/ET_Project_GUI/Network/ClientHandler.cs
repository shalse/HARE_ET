using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading;

namespace ET_Project_GUI.Network
{
    class ClientHandler
    {
        TcpClient clientSocket;
        string clNo;
        public ClientHandler()
        {
        }
        public void startClient(TcpClient inClientSocket, string clineNo)
        {
            this.clientSocket = inClientSocket;
            this.clNo = clineNo;
        }
        public void doChat()
        {
            byte[] recievedBytes = new byte[1000];
            MessageFormater msgFormat = new MessageFormater();
            while ((true))
            {
                try
                {

                    NetworkStream networkStream = clientSocket.GetStream();
                    networkStream.Read(recievedBytes, 0, recievedBytes.Length);
                    networkStream.Flush();
                    msgFormat.decodeMessage(recievedBytes);
                    //Console.WriteLine(">>Message recieved : "+);

                    
                    //sendBytes = msgFormat.encodeMessage("!MAZ", "This is my message");
                    //networkStream.Write(sendBytes, 0, sendBytes.Length);
                    //Console.WriteLine("message sent");
                    //Thread.Sleep(2000);

                    //byte[] sendMessage = Encoding.ASCII.GetBytes("Test message");
                    //networkStream.Write(sendMessage, 0, sendMessage.Length);
                    //Console.WriteLine("message sent");
                    //Thread.Sleep(2000);

                    //networkStream.Read(recievedBytes,0,(int)clientSocket.ReceiveBufferSize);
                    //Console.WriteLine("Recieved: " + Encoding.ASCII.GetString(recievedBytes));
                    //networkStream.Flush();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(" >> " + ex.ToString());
                }
            }
        }
    }
}
