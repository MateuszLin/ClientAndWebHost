using SimpleTCP;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientA
{
    public class ClientServerTCP
    {
        SimpleTcpClient _client;
        readonly string _port = "8910";
        readonly string _ip = "127.0.0.1";
        public ClientServerTCP()
        {
            _client = new SimpleTcpClient();
           _client.StringEncoder = Encoding.UTF8;
        }

        /// <summary>
        /// Connect to the host
        /// </summary>
        /// <returns>True if connected, False if not</returns>
        public bool Connect()
        {
            try
            {
                _client.Connect(_ip, Convert.ToInt32(_port));
            }
            catch(Exception e)
            {
                Debug.WriteLine("Failed connect to host");
                // connecting to the host failed
                return false;
            }
            
            return true;
        }

        /// <summary>
        /// Send message to the Host
        /// </summary>
        /// <param name="msg">Message to send</param>
        public bool SendMessage(string msg)
        {
            bool isSend = false;
            try
            {
                _client.WriteLine(msg);
                isSend = true;
            }catch(Exception e)
            {
                Debug.WriteLine("Can't send message");
            }

            return isSend;
        }
    }
}
