using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;
using System.Threading;
using GameProjectReborn.Entities;
using GameProjectReborn.Managers;
using Polenter;

namespace GameProjectReborn.MultiJoueurs
{
    public class ServeurClient
    {
        
        public string Name { get; set; }
        private Socket socket;
        private Stream stream;
        private StreamWriter streamWriter;
        private StreamReader streamReader;
        private Serveur server;
        private Thread t_receive;
        public EntityMulti playerMul { get; set; }
        private Polenter.Serialization.SharpSerializer serializer;
        private Polenter.Serialization.SharpSerializer deserializer;

        public ServeurClient(Socket socket, Serveur server)
        {
            this.socket = socket;
            this.server = server;
            stream = new NetworkStream(socket);
            streamReader = new StreamReader(stream);
            streamWriter = new StreamWriter(stream);
            serializer = new Polenter.Serialization.SharpSerializer(false);
            deserializer = new Polenter.Serialization.SharpSerializer(false);
            playerMul = new EntityMulti();
            t_receive = new Thread(Receive);
            t_receive.Start();
        }

        public void Receive()
        {
            Object obj = null;
            while (socket.Connected)
            {
                try
                {
                    obj = deserializer.Deserialize(stream);
                }
                catch (Exception)
                {
                    server.ClientClose(this);
                    Close();
                }
                if (obj is string && (string)obj == "/disconnect")
                {
                    server.ClientClose(this);
                    Close();
                }
                else if (obj is EntityMulti)
                    playerMul = (EntityMulti) obj;
            }
            server.ClientClose(this);
            Close();

        }

        public void Close()
        {
            t_receive.Abort();
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }

        public void Send(Object obj)
        {
            if (socket.Connected)
            {
                try
                {
                    //streamWriter.WriteLine(message);
                    serializer.Serialize(obj, stream);
                    stream.Flush();
                }
                catch (Exception)
                {
                    throw new Exception("Impossible d'envoyé le message à : " + Name + ".");
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
                    //streamWriter.WriteLine(message);
                    serializer.Serialize(server.ServeurClientToEntityMultiList(), stream);
                    stream.Flush();
                }
                catch (Exception)
                {
                    throw new Exception("Impossible d'envoyé le message à : " + Name + ".");
                }
            }
            else
            {
                Console.WriteLine("Not connected.");
            }
        }

        public Socket Socket
        {
            get { return socket; }
        }
    }
}
