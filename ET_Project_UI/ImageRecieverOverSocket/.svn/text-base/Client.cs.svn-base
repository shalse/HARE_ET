using System.Net.Sockets;
using System.Net;
using System;
using System.Threading;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using System.IO;
public class Client
{
    private Socket s = null;
    private IPEndPoint ipe = new IPEndPoint(IPAddress.Parse("172.17.120.134"), int.Parse("7777"));
    public Client()
    {
    }

    public void connectToServer()
    {
        s = new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
    }
    public void sendMessage(string msg)
    {
        if (s.Connected)
        {
            byte[] test = Encoding.UTF8.GetBytes(msg);
            s.Send(test);
        }
        else
        {
            try
            {
                s.Connect(ipe);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed " + ex.Message);
            }
        }
    }
    public Image getImage()
    {
        if (s.Connected)
        {
            byte[] buffer = new byte[1000000];
            s.Receive(buffer, buffer.Length, SocketFlags.None);
           
            MemoryStream ms = new MemoryStream(buffer, true);
            ms.Write(buffer, 0, 0);
            Image img = Bitmap.FromStream(ms);
            
            //Bitmap img = new Bitmap();


            return img;
        }
        else
        {
            return null;
        }
    }

}