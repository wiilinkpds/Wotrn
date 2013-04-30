using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    public class Client
    {
        public List<string> names;

        private UdpClient client;
        private IPEndPoint serveur;
        

        public Client (string name, int port, string hostname)
        {
            byte[] msg = Encoding.Default.GetBytes(name);

            client = new UdpClient();
            names = new List<string>();
            client.Send(msg, msg.Length, hostname, port);
            Thread waitStart = new Thread(WaitStart);
            waitStart.Start();
        }

        private void WaitStart()
        {
            while (true)
            {
                string msg = Encoding.Default.GetString(client.Receive(ref serveur));
                if (msg == "/Launch")
                    MainGame.GetInstance().SetScreen(new MultiScreen(this));
                else if (!names.Contains(msg))
                    names.Add(msg);
            }
        }

        public void Sending(Player player)
        {
            SendMsg(ObjectToByteArray(player.PlayerToMulti()));
        }

        public List<Player> Receving(GameScreen game)
        {
            List<Player> list = new List<Player>();
            try
            {
                List<EntityMulti> mult = ByteArrayToListPlayer(client.Receive(ref serveur));
                for (int j = 0; j < mult.Count; j++)
                    if (mult[j] != null)
                        list.Add(mult[j].MultiToPlayer(game, TexturesManager.Player));
            }
            catch (Exception)
            {
            }
 
            return list;
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

        private List<EntityMulti> ByteArrayToListPlayer(byte[] obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream(obj);
            bf.Deserialize(ms);
            return (List<EntityMulti>)bf.Deserialize(ms);
        }

        private void SendMsg(byte[] msg)
        {
            try
            {
                client.Send(msg, msg.Length, serveur);
            }
            catch (Exception)
            {
            }
            
        }
    }
}
