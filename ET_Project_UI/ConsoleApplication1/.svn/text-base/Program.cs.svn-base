using System.Net.Sockets;
using System.Net;
using System;
using System.Threading;
using System.Text;
public class Server
{
    static string output = "";

    public Server()
    {
    }

    public void createListener()
    {
        // Create an instance of the TcpListener class.
        TcpListener tcpListener = null;
        IPAddress ipAddress = IPAddress.Parse("192.168.1.107");//Dns.GetHostEntry("localhost").AddressList[0];
        try
        {
            // Set the listener on the local IP address 
            // and specify the port.
            tcpListener = new TcpListener(ipAddress, 7777);
            tcpListener.Start();
            output = "Waiting for a connection...";
        }
        catch (Exception e)
        {
            output = "Error: " + e.ToString();
           // MessageBox.Show(output);
        }
        while (true)
        {
            // Always use a Sleep call in a while(true) loop 
            // to avoid locking up your CPU.
            Thread.Sleep(10);
            // Create a TCP socket. 
            // If you ran this server on the desktop, you could use 
            Socket socket = tcpListener.AcceptSocket();
            // for greater flexibility.
           // TcpClient tcpClient = tcpListener.AcceptTcpClient();
            // Read the data stream from the client. 
            byte[] bytes = new byte[256];
            //NetworkStream stream = tcpClient.GetStream();
            socket.Receive(bytes);
            Console.WriteLine(Encoding.UTF8.GetString(bytes));
           // if (stream.CanRead)
            //{
             //   stream.Read(bytes, 0, bytes.Length);
            //}
            //else
            //{
             //   Console.WriteLine("Did the connection get severed?");
            //}
           // SocketHelper helper = new SocketHelper();
            //helper.processMsg(tcpClient, stream, bytes);
        }
    }
    static void Main()
    {
        Server svr = new Server();
        svr.createListener();
    }
}