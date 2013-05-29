using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ET_Project_UI
{
    class Connection
    {
        public Connection()
        {
             
        }
        public int connect(ETController ETDevice)
        {
            string sendip = "127.0.0.1";
            Int32 sendport = 4444;
            string receiveip = "127.0.0.1";
            Int32 receiveport = 5555;
            int ret = 0;
            try
            {      
                ret = ETDevice.iV_Connect(new StringBuilder(sendip), sendport, new StringBuilder(receiveip), receiveport);
                if (ret == 1) Console.WriteLine("iV_Connect: connection established");
                if (ret == 100) Console.WriteLine("iV_Connect: failed to establish connection");
                if (ret == 112) Console.WriteLine("iV_Connect error: wrong parameter");
                if (ret == 123) Console.WriteLine("iV_Connect error: failed to bind sockets");
                return ret;
            }
            catch (Exception exc)
            {
                Console.WriteLine("Exception during iV_Connect: " + exc.Message);
                return 0;
            }
            
        }
    }
}
