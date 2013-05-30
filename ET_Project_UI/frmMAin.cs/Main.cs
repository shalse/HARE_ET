using System;
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Text;
using System.Threading;
using System.Net;

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
            ipInputBox.Text = localIP;
        }
        TcpClient client;
        Thread startConn;

        private void button1_Click(object sender, EventArgs e)
        {
            startConn = new Thread(new ThreadStart(startThread));
            startConn.Name = "Conn thread";
            startConn.Start();
    
        }
        private void startThread()
        {
            Console.WriteLine("Attempting connection");

            client = new TcpClient();
            client.Connect(ipInputBox.Text, 10000);

            byte[] recievedBytes = new byte[1000];


            NetworkStream networkStream = client.GetStream();

            while (client.Connected)
            {
                try
                {
                    byte[] msgType = Encoding.ASCII.GetBytes("!TES");
                    string msg = "!TES";
                    for (int count = 0; count < 25; count++)
                    {
                        msg += count.ToString();
                    }
                    byte[] sendMessage = Encoding.ASCII.GetBytes(msg);
                    networkStream.Write(sendMessage, 0, sendMessage.Length);
                    
                    Console.WriteLine("message sent"+msg);

                    Thread.Sleep(1000);
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
       
        private void onClose()
        {
            NetworkStream networkStream = client.GetStream();
            byte[] sendMessage = Encoding.ASCII.GetBytes("!KIL");
            networkStream.Write(sendMessage, 0, sendMessage.Length);
            Console.WriteLine("Killing conn");
            client.Close();

            startConn.Abort();
        }
    }
}
