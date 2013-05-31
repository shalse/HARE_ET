using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ET_Project_GUI.Data
{
    class ETConnection
    {
        //default values
        private string _sendIP = "127.0.0.1";
        private Int32 _sendPort = 4444;
        private string _receiveIP = "127.0.0.1";
        private Int32 _receivePort = 5555;

        //connect to the eye tracker
        public int connect(ETController etController)
        {
            int ret = 0;
            try
            {
                ret = etController.iV_Connect(new StringBuilder(_sendIP), _sendPort, new StringBuilder(_receiveIP), _receivePort);
                if (ret == 1) Console.WriteLine("iV_Connect: connection established");
                if (ret == 100) Console.WriteLine("iV_Connect: failed to establish connection");
                if (ret == 112) Console.WriteLine("iV_Connect error: wrong parameter");
                if (ret == 123) Console.WriteLine("iV_Connect error: failed to bind sockets");
                return ret;
            }
            catch (Exception ex)
            {
                DialogResult messagebox = MessageBox.Show("Could not connect to SMI Eye Tracker\n\n"+ex.Message, "Error Connecting to Eye Tracker Server",
                MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (messagebox == DialogResult.Retry)
                {
                    connect(etController);
                }
                Console.WriteLine("Exception during iV_Connect: " + ex.Message);
                return 0;
            }

        }

        //methods to update/change the default values
        public string SendIP
        {
            get { return _sendIP; }
            set { _sendIP = value; }
        }
        public Int32 SendPort
        {
            get { return _sendPort; }
            set { _sendPort = value; }
        }
        public string RecieveIP
        {
            get { return _receiveIP; }
            set { _receiveIP = value; }
        }
        public Int32 RecievePort
        {
            get { return _receivePort; }
            set { _receivePort = value; }
        }
    }
}
