using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using GameProjectReborn.Entities;
using GameProjectReborn.Managers;
using GameProjectReborn.Maps;
using GameProjectReborn.MultiJoueurs;
using GameProjectReborn.Utils;
using Microsoft.Xna.Framework;

namespace GameProjectReborn.Screens
{
    public class MultiScreen : GameScreen
    {
        public bool IsClient;

        private Serveur server;
        private Client client;
        private List<Player> otherPlayer;
        private Vector2 oldPos;

        public MultiScreen(Serveur serveur)
        {
            otherPlayer = new List<Player>();
            IsClient = false;       
            server = serveur;
            if (!IsClient)
                for (int i = 0; i < server.Clients.Count;i++ )
                    otherPlayer.Add(new Player(this,TexturesManager.Player));

            Reseau = true;
            MapData mapData = new MapData();
            if (!mapData.FromFile("Content/Maps/map.mrm"))
                throw new Exception();
            MapFirst = new Map(mapData);
            camera = new Cam(MapFirst.Data.MapWidth * 32, MapFirst.Data.MapHeight * 32, MainGame.graphics);

            Thread receving = new Thread(ReceiveServeur);
            receving.Start();
        }
        
        public MultiScreen(Client client)
        {
            IsClient = true;
            this.client = client;
            oldPos = Vector2.Zero;
            Reseau = true;
            MapData mapData = new MapData();
            if (!mapData.FromFile("Content/Maps/map.mrm"))
                throw new Exception();
            MapFirst = new Map(mapData);
            camera = new Cam(MapFirst.Data.MapWidth * 32, MapFirst.Data.MapHeight * 32, MainGame.graphics);
            Thread receving = new Thread(ReceiveClient);
            receving.Start();
        }

        public override void Update(GameTime gameTime)
        {
            if (!IsClient && gameTime.TotalGameTime.TotalMilliseconds % 500 < 10)
            {
                List<Player> all = otherPlayer;
                all.Add(Player);
                server.Sending(all);
            }
            else if (IsClient && oldPos != Player.Position)
            {
                oldPos = Player.Position;
                client.Sending(Player);
            }

            base.Update(gameTime);
        }

        private void ReceiveServeur()
        {
            while (true)
            {
                int i = 0;
                Player temp = server.Receving(ref i,this);
                if (temp != null)
                    otherPlayer[i] = temp;
            }
        }

        private void ReceiveClient()
        {
            while (true)
            {
                List<Player> temp = client.Receving(this);
                if (temp != null && temp.Count > 0)
                    otherPlayer = temp;
            }
        }

        public override void Draw(GameTime gameTime, UberSpriteBatch spriteBatch)
        {
            spriteBatch.BeginCam(camera);
            foreach (var player in otherPlayer)
                player.Draw(gameTime,spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime, spriteBatch);
        }
    }
}

