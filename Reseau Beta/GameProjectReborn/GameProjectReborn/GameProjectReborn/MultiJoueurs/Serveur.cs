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
        public Dictionary<string, IPEndPoint> Clients { get; private set; } //IPEndPoint de chaque client associer a leur nom

        private Socket socket;
        private Thread Taccept;
        private UdpClient serveur;
        private bool IsLaunch;      

        public Serveur(int port)
        {
            Clients = new Dictionary<string, IPEndPoint>();
            serveur = new UdpClient(port);
            Taccept = new Thread(Accepte);
            Taccept.Start();
        }
        public void Start()
        {
            Taccept.Abort();
            MainGame.GetInstance().SetScreen(new MultiScreen());
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
