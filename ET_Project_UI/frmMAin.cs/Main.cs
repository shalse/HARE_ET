using System;
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Text;
using System.Threading;

namespace TCPClientTester
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

        }
        private void Main_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TcpClient client;
            Console.WriteLine("Attempting connection");

            client = new TcpClient();
            client.Connect(ipInputBox.Text, 10000);

            byte[] recievedBytes = new byte[1000];

            
             NetworkStream networkStream = client.GetStream();
          
            while(true)
            {
                try
                {
                   // networkStream.Read(recievedBytes, 0, recievedBytes.Length);
                   // Console.WriteLine("Recieved: " + Encoding.ASCII.GetString(recievedBytes));
                    //networkStream.Flush();


                    //decodeMessage(recievedBytes);

                    //networkStream.Read(recievedBytes, 0, (int)client.ReceiveBufferSize);
                    //Console.WriteLine("Recieved: " + Encoding.ASCII.GetString(recievedBytes));
                    //networkStream.Flush();

                    byte[] sendMessage = Encoding.ASCII.GetBytes("!MAZ0018This is my message");
                    networkStream.Write(sendMessage, 0, sendMessage.Length);
                    Console.WriteLine("message sent");
                    //read message from server
                    Thread.Sleep(1000);
                    
                    //output.Read(recievedMessage, 0, client.ReceiveBufferSize);
                    //output.Flush();

                   // message = reader.ReadString();
                  //  Console.WriteLine(">>Message recieved >> :" + message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            //Step 4: Close conenction
            Console.WriteLine("Exit");
            client.Close();
        }

        private void decodeMessage(byte[] recievedBytes)
        {
            string fullMessage = Encoding.ASCII.GetString(recievedBytes);
            
            string origin = fullMessage.Substring(0, 4);
            if (origin.Substring(0, 1) == "!")
            {
                int messageSize = int.Parse(fullMessage.Substring(4, 4));
                string message = fullMessage.Substring(8, messageSize);


                Console.WriteLine("Origin = " + origin);
                Console.WriteLine("messageSize = " + messageSize);
                Console.WriteLine("message = " + message);
            }
            else
            {
                Console.WriteLine("The Data has been corrupted");
            }
        }
    }
}
