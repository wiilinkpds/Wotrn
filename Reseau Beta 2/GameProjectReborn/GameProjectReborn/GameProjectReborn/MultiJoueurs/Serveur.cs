using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using GameProjectReborn.Entities;
using GameProjectReborn.Managers;
using GameProjectReborn.Screens;

namespace GameProjectReborn.MultiJoueurs
{
    public class Serveur
    {
        public List<ServeurClient> Clients { get; set; }


        private Socket socket;
        private Thread t_accept;
        private string name;
        private int port;
        private int maxClient;
        private bool IsLaunch;

        public Serveur(string name, int port, int maxClient)
        {
            Clients = new List<ServeurClient>();

            this.name = name;
            this.port = port;
            this.maxClient = maxClient;
            
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Start()
        {
            try
            {
                socket.Bind(new IPEndPoint(IPAddress.Any, port));
            }
            catch (Exception)
            {
                throw new Exception("Impossible de Binder le socket : le port peut être occupé.");
            }
            socket.Listen(maxClient);
            t_accept = new Thread(Accept);
            t_accept.Start();
        }

        private void Accept()
        {
            while (true)
            {
                Clients.Add(new ServeurClient(socket.Accept(), this));
            }
        }

        public List<EntityMulti> ServeurClientToEntityMultiList()
        {
            List<EntityMulti> aux = new List<EntityMulti>();

            foreach (var serveurClient in Clients)
            {
                aux.Add(serveurClient.playerMul);
            }

            return aux;
        }

        public void SendToAll()
        {
            foreach (ServeurClient client in Clients)
            {
                client.SendData();
            }
        }

        public void SendToAll(Object obj)
        {
            foreach (ServeurClient client in Clients)
            {
                client.Send(obj);
            }
        }

        public void StartGame()
        {
            foreach (var client in Clients)
            {
                client.Send("/Lunch");
            }
            //MainGame.GetInstance().SetScreen(new MultiScreen(this));
        }

        public bool ClientClose(ServeurClient client)
        {
            return Clients.Remove(client);
        }
    }
}