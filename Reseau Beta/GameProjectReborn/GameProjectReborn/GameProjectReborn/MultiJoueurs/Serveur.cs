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
        public List<ServeurClient> Clients { get; private set; } //IPEndPoint de chaque client associer a leur nom

        private Socket socket;
        private Thread Taccept;
        private UdpClient serveur;
        private bool IsLaunch;      

        public Serveur(int port)
        {
            Clients = new List<ServeurClient>();
            serveur = new UdpClient(port);
            Taccept = new Thread(Accepte);
            Taccept.Start();
        }
        public void Start()
        {
            foreach (var serveurClient in Clients)
            {
                byte[] msg = Encoding.Default.GetBytes("/Launch");
                SendMsg(msg,serveurClient.ip);
            }
            Taccept.Abort();
            MainGame.GetInstance().SetScreen(new MultiScreen(this));
        }

        public void Sending(List<Player> players)
        {
            List<EntityMulti> sendeur = new List<EntityMulti>();
            for (int i = 0; i < Clients.Count; i++)
            {
                for (int j = 0; j < players.Count;j++)
                    sendeur.Add(players[j].PlayerToMulti());
                sendeur.RemoveAt(i);
                SendMsg(ObjectToByteArray(sendeur), Clients[i].ip);
            }
        }
        public Player Receving(ref int index, GameScreen game)
        {
            try
            {
                IPEndPoint client = null;
                byte[] msg = serveur.Receive(ref client);
                index = Clients.FindIndex(serveur_client => client == serveur_client.ip);
                return ByteArrayToPlayer(msg, game);
            }
            catch (Exception)
            {    
            }
            return null;
        }

        private byte[] ObjectToByteArray(Object obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, obj);
            return ms.ToArray();
        }

        private Player ByteArrayToPlayer(byte[] obj, GameScreen game)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream(obj);
            bf.Deserialize(ms);
            EntityMulti multi = (EntityMulti)bf.Deserialize(ms);
            return multi.MultiToPlayer(game,TexturesManager.Player);
        }

        private void SendMsg(byte[] msg, IPEndPoint client)
        {
            try
            {
                serveur.Send(msg, msg.Length, client);
            }
            catch (Exception)
            {
            }         
        }

        public void Accepte()
        {
            while (true)
            {
                IPEndPoint client = null;
                string name = Encoding.Default.GetString(serveur.Receive(ref client));
                Clients.Add(new ServeurClient(name,client));
                foreach (var serveurClient in Clients)
                {
                    SendMsg(Encoding.Default.GetBytes(name),serveurClient.ip);
                    foreach (ServeurClient t in Clients)
                    {
                        byte[] msg = Encoding.Default.GetBytes(t.name);
                        SendMsg(msg,serveurClient.ip);
                    }
                }
            }
        }
    }
}
