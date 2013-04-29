using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace GameProjectReborn.MultiJoueurs
{
    class Client
    {
        private UdpClient client;

        public Client (string name, int port)
        {
            byte[] msg = Encoding.Default.GetBytes(name);

            UdpClient udpClient = new UdpClient();

            udpClient.Send(msg, msg.Length, "127.0.0.1", port);

        }
    }
}
