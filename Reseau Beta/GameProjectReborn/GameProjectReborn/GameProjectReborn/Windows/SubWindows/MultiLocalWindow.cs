using System.Collections.Generic;
using System.Linq;
using GameProjectReborn.Managers;
using GameProjectReborn.Screens;
using GameProjectReborn.UI;
using GameProjectReborn.Utils;
using GameProjectReborn.Windows;
using GameProjectReborn.Windows.SubWindows;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameProjectReborn.Windows.SubWindows
{
    class MultiLocalWindow : Window
    {
        private Texture2D texture;
        private Screen parent;

        private Button Serveur;
        private Button Client;

        private Window localServeur;
        private Window localClient;

        public MultiLocalWindow(Screen parent, Vector2 position, Texture2D texture) : base(parent, position, texture)
        {
            this.parent = parent;
            Bounds = new Rectangle((int)Position.X, (int)Position.Y, MainGame.ScreenX / 8, MainGame.ScreenY / 8);  
            this.texture = texture;
            Serveur = new Button(new Vector2(Bounds.X + Bounds.Width / 4, Bounds.Y + Bounds.Height / 4),"Serveur" );
            Serveur.MouseClick += OnServeurMouseClick;
            localServeur = new LocalServeur(parent, new Vector2(Bounds.X + Bounds.Width + 10, Serveur.Bounds.Y));

            Client = new Button(new Vector2(Bounds.X + Bounds.Width / 4, Bounds.Y + Bounds.Height / 2), "Client");
            Client.MouseClick += OnClientMouseClick;
            localClient = new LocalClient(parent, new Vector2(Bounds.X + Bounds.Width + 10 , Client.Bounds.Y));
        }

        public override void Update(GameTime gameTime)
        { 
            Serveur.Update(gameTime);
            Client.Update(gameTime);
        }

        public void Close()
        {
            localClient.IsOpened = false;
            localServeur.IsOpened = false;
            parent.Windows.Remove(localClient);
            parent.Windows.Remove(localServeur);
        }

        public override void Draw(GameTime gameTime, UberSpriteBatch spriteBatch)
        {
            spriteBatch.DrawUI(texture, Bounds);
            Serveur.Draw(gameTime,spriteBatch);
            Client.Draw(gameTime,spriteBatch);
        }
        private void OnServeurMouseClick(object sender, MouseClickEventArgs e)
        {
            localServeur.IsOpened = !localServeur.IsOpened;

            if (localClient.IsOpened)
            {
                localClient.IsOpened = false;
                parent.Windows.Remove(localClient);
            }

            if (localServeur.IsOpened)
                parent.Windows.Add(localServeur);
            else
                parent.Windows.Remove(localServeur);
        }

        private void OnClientMouseClick(object sender, MouseClickEventArgs e)
        {
            localClient.IsOpened = !localClient.IsOpened;
            if (localServeur.IsOpened)
            {
                localServeur.IsOpened = false;
                parent.Windows.Remove(localServeur);
            }

            if (localClient.IsOpened)
                parent.Windows.Add(localClient);
            else
                parent.Windows.Remove(localClient);          
        }
    }
}
