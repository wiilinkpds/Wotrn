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


        public MultiLocalWindow(Screen parent, Vector2 position, Texture2D texture) : base(parent, position, texture)
        {
            this.parent = parent;
            Bounds = new Rectangle((int)Position.X, (int)Position.Y, MainGame.ScreenX / 8, MainGame.ScreenY / 8);  
            this.texture = texture;
            Serveur = new Button(new Vector2(Bounds.X + Bounds.Width / 4, Bounds.Y + Bounds.Height / 4),"Serveur" );
            Serveur.MouseClick += OnServeurMouseClick;
            localServeur = new LocalServeur(parent, new Vector2(MainGame.ScreenX / 3, Serveur.Bounds.Y), TexturesManager.Window);

            Client = new Button(new Vector2(Bounds.X + Bounds.Width / 4, Bounds.Y + Bounds.Height / 2), "Client");
            

        }

        public override void Update(GameTime gameTime)
        { 
            Serveur.Update(gameTime);
            Client.Update(gameTime);
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

            if (localServeur.IsOpened)
                parent.Windows.Add(localServeur);
            else
                parent.Windows.Remove(localServeur);
        }
    }
}
