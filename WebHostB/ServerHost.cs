using SimpleTCP;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using WebHostB.Models;

namespace WebHostB
{
    public class ServerHost
    {
        SimpleTcpServer _server;
        readonly string _ip = "127.0.01";
        readonly string _port = "8910";

        public ServerHost()
        {
            _server = new SimpleTcpServer();
            _server.DataReceived += _server_DataReceived;
        }

        private void _server_DataReceived(object sender, Message e)
        {
            Debug.WriteLine("receive " + e.MessageString);
            MessageModel.message = e.MessageString.Remove(e.MessageString.Length - 1);
        }

        public bool startServer()
        {
            if (!_server.IsStarted)
            {
                try
                {
                    _server.StringEncoder = Encoding.UTF8;
                    IPAddress ip = IPAddress.Parse(_ip);
                    _server.Start(ip, Convert.ToInt32(_port));
                    
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            return true;
        }
    }
}