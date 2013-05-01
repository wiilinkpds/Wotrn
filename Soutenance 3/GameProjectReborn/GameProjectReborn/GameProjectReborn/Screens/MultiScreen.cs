using System;
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

        public MultiScreen(Serveur server, Client client)
        {
            IsClient = false;
            this.client = client;
            this.server = server;
            Reseau = true;
            MapData mapData = new MapData();
            if (!mapData.FromFile("Content/Maps/map.mrm"))
                throw new Exception();
            MapFirst = new Map(mapData);
            Camera = new Cam(MainGame.GetInstance().graphics);
        }
        
        public MultiScreen(Client client)
        {
            IsClient = true;
            this.client = client;
            Reseau = true;
            MapData mapData = new MapData();
            if (!mapData.FromFile("Content/Maps/map.mrm"))
                throw new Exception();
            MapFirst = new Map(mapData);
            Camera = new Cam(MainGame.GetInstance().graphics);
        }

        public override void Update(GameTime gameTime)
        {
            if (client.IsLocalClient && gameTime.TotalGameTime.TotalMilliseconds % 500 < 10)
            {
                client.Send(Player.PlayerToMulti());
                server.SendToAll();
            }
            else if (!client.IsLocalClient && gameTime.TotalGameTime.TotalMilliseconds % 500 < 10)
            {
                client.Send(Player.PlayerToMulti());
            }

            base.Update(gameTime);
        }


        public override void Draw(GameTime gameTime, UberSpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
            spriteBatch.BeginCam(Camera);

                foreach (var entityPlayer in client.OtherPlayers)
                    entityPlayer.MultiToPlayer(this, TexturesManager.Player).Draw(gameTime, spriteBatch);
            //spriteBatch.DrawUI(TexturesManager.Menu, Convert.ToString.Count), Vector2.One, Color.Blue);
            spriteBatch.End();
   
        }
    }
}

