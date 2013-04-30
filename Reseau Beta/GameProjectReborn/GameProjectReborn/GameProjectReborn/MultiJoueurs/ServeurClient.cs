using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace GameProjectReborn.MultiJoueurs
{
    public class ServeurClient
    {
        public string name { get; set; }
        public IPEndPoint ip { get; set; }

        public ServeurClient(string nom,IPEndPoint ip)
        {
            name = nom;
            this.ip = ip;
        }
    }
}
