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
using Polenter;

namespace GameProjectReborn.MultiJoueurs
{
    public class Client
    {
        private IPAddress serverIP;
        private int port;
        private Socket socket;
        private StreamReader streamReader;
        private StreamWriter streamWriter;
        private Stream stream;
        private string name;
        private Thread t_receive;
        private Thread t_waitStart;
        private string host;
        public EntityMulti entityMulti;
        public bool IsLocalClient { get; set; }
        
        private Polenter.Serialization.SharpSerializer serializer;
        private Polenter.Serialization.SharpSerializer deserializer;

        public List<EntityMulti> OtherPlayers { get; set; }


        public Client(string name)
        {
            IsLocalClient = false;
            serializer = new Polenter.Serialization.SharpSerializer(false);
            deserializer = new Polenter.Serialization.SharpSerializer(false);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            entityMulti = new EntityMulti();
            OtherPlayers = new List<EntityMulti>();
            this.name = name;
            entityMulti.name = name;
        }

        public Client(string name, bool IsLocalClient)
        {
            this.IsLocalClient = IsLocalClient;
            serializer = new Polenter.Serialization.SharpSerializer(false);
            deserializer = new Polenter.Serialization.SharpSerializer(false);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            entityMulti = new EntityMulti();
            OtherPlayers = new List<EntityMulti>();
            this.name = name;
            entityMulti.name = name;
        }

        public void StartWaitStart()
        {
            t_waitStart = new Thread(WaitStart);
            t_waitStart.Start();
        }

        private void EndWaitStart()
        {
            t_waitStart.Abort();
        }

        

        public void Connect(IPAddress serverIP, int port)
        {
            this.serverIP = serverIP;
            host = serverIP.ToString();
            this.port = port;
            try
            {
                socket.Connect(serverIP, port);
            }
            catch (Exception)
            {
                throw new Exception("Impossible de se connecter : Server en service?");
            }

            stream = new NetworkStream(socket);
            streamReader = new StreamReader(stream);
            streamWriter = new StreamWriter(stream);
        }

        public void Connect(string host, int port) // Surcharge affin d'utilisé un string au lieu d'un IPAdress afin d'utilisé le nom netbios
        {
            this.host = host;
            this.port = port;
            try
            {
                socket.Connect(host, port);
            }
            catch (Exception)
            {
                throw new Exception("Impossible de se connecter : Server en service?");
            }

            stream = new NetworkStream(socket);
            streamReader = new StreamReader(stream);
            streamWriter = new StreamWriter(stream);
        }

        public void Send(object objet)
        {
            if (socket.Connected)
            {
                try
                {
                    serializer.Serialize(objet, stream);
                    stream.Flush();
                }
                catch (Exception)
                {
                    throw new Exception("Impossible d'envoyé le message : server déconnecté.");
                }
            }
            else
            {
                Console.WriteLine("Not connected.");
            }
        }

        public void SendData()
        {
            if (socket.Connected)
            {
                try
                {
                    serializer.Serialize(entityMulti, stream);
                    stream.Flush();
                }
                catch (Exception)
                {
                    throw new Exception("Impossible d'envoyé le message : server déconnecté.");
                }
            }
            else
            {
                Console.WriteLine("Not connected.");
            }
        }

        private void WaitStart()
        {
            while (true)
            {
                Object obj = deserializer.Deserialize(stream);
                if (obj is string && (string)obj == "/Lunch")
                {
                    EndWaitStart();
                    if (!IsLocalClient)
                    {
                        MainGame.GetInstance().SetScreen(new MultiScreen(this));
                    }
                    return;
                }
                else if (obj is List<EntityMulti>)
                    OtherPlayers = (List<EntityMulti>)obj;
            }
        }

        public void ReaderThread()
        {
            Object obj = null;
            while (true)
            {
                if (socket.Connected)
                {
                    try
                    {
                        obj = deserializer.Deserialize(stream);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Server déconnecté.");
                    }
                    if (obj is List<EntityMulti>)
                    {
                       OtherPlayers = (List<EntityMulti>)obj;
                    }
                    else if (obj is string)
                    {
                        if ((string) obj == "/Lunch")
                        {
                            if (!IsLocalClient)
                            {
                                MainGame.GetInstance().SetScreen(new MultiScreen(this));
                            }
                        }
                    }
                }
                
            }

        }

        public void StartReadThread()
        {
            t_receive = new Thread(ReaderThread);
            t_receive.Start();
        }

        public void Close()
        {
            t_receive.Abort();
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }
    }
}
