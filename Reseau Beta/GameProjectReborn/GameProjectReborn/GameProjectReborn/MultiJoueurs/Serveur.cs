using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using GameProjectReborn.Screens;

namespace GameProjectReborn.MultiJoueurs
{
    class Serveur
    {
        public Dictionary<string, IPEndPoint> Clients { get; private set; }

        private Socket socket;
        private Thread Taccept;
        private UdpClient serveur;
        private bool IsLaunch;      

        public Serveur(bool local, int port)
        {
            Clients = new Dictionary<string, IPEndPoint>();
            serveur = new UdpClient(port);
            Taccept = new Thread(Accepte);
            Taccept.Start();
        }
        public void Start(int port)
        {
            Taccept.Abort();
            try
            {
                socket.Bind(new IPEndPoint(IPAddress.Any, port));
            }
            catch (Exception)
            {
            }
            socket.Listen(10);

        }

        public void Update()
        {
        }

        public void Accepte()
        {
            while (true)
            {
                IPEndPoint client = null;
                string name = Encoding.Default.GetString(serveur.Receive(ref client));
                Clients.Add(name,client);
            }
        }
    }
}
