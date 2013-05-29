using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Net;

namespace Test_Server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void statusLabel_Click(object sender, EventArgs e)
        {

        }

        private void startListeningButton_Click(object sender, EventArgs e)
        {
            TcpListener serverSocket = new TcpListener(IPAddress.Parse(ipInputBox.Text), int.Parse(portInputBox.Text));
            int reqCount = 0;
            TcpClient clientSocket = default(TcpClient);
            try
            {
                serverSocket.Start();
                statusLabel.Text = "Server Started!";
            }
            catch (Exception ex)
            {
                statusLabel.Text = "Server could not start";
            }
            try
            {
                clientSocket = serverSocket.AcceptTcpClient();
                statusLabel.Text = "Client Has Connected!";
            }
            catch (Exception ex)
            {
                statusLabel.Text = "Client could not connect";
            }
            

            reqCount = 0;

            while ((true))
            {
                try
                {
                    reqCount = reqCount + 1;
                    NetworkStream networkStream = clientSocket.GetStream();
                    byte[] bytesFrom = new byte[10025];
                    networkStream.Read(bytesFrom, 0, (int)clientSocket.ReceiveBufferSize);
                    string dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
                    dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));
                    Console.WriteLine(" >> Data from client - " + dataFromClient);
                    string serverResponse = "Server response " + Convert.ToString(reqCount);
                    Byte[] sendBytes = Encoding.ASCII.GetBytes(serverResponse);
                    networkStream.Write(sendBytes, 0, sendBytes.Length);
                    networkStream.Flush();
                    Console.WriteLine(" >> " + serverResponse);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            clientSocket.Close();
            serverSocket.Stop();
            Console.WriteLine(" >> exit");
            Console.ReadLine();
        }
        

    }
}
