using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameProjectReborn.Managers;
using GameProjectReborn.MultiJoueurs;
using GameProjectReborn.Screens;
using GameProjectReborn.UI;
using GameProjectReborn.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameProjectReborn.Windows.SubWindows
{
    class LocalClient : Window
    {
        private List<TextBox> box;
        private Button joinButton;
        private int port, boxselect;
        private string name;
        private bool IsJoin;
        private Client client;

        public LocalClient(Screen parent, Vector2 position) : base(parent, position)
        {
            name = "";
            Bounds = new Rectangle((int)position.X, (int)position.Y, MainGame.ScreenX / 2, MainGame.ScreenY / 2);
            box = new List<TextBox>();
            box.Add(new TextBox(new Vector2(Bounds.X + 20 + TexturesManager.Menu.MeasureString("Port :").X, Bounds.Y + 50), 6, 1, TexturesManager.Menu, Color.Blue, Color.Red));
            box[0].IsSelect = true;
            box.Add(new TextBox(new Vector2(box[0].Bound.X + box[0].Bound.Width + 20 + TexturesManager.Menu.MeasureString("Nom :").X, box[0].Bound.Y), 20, 1, TexturesManager.Menu, Color.Blue, Color.Red));
            box.Add(new TextBox(new Vector2(Bounds.X + 20 + TexturesManager.Menu.MeasureString("Ip :").X, box[0].Bound.Bottom + 10),20,1,TexturesManager.Menu,Color.Blue,Color.Red));
            joinButton = new Button(new Vector2(box[2].Bound.Right + 10, box[2].Bound.Y), "Rejoindre" );
            joinButton.MouseClick += OnJoinMouseClick;
        }

        public override void Update(GameTime gameTime)
        {
            if (!IsJoin)
            {
                joinButton.Update(gameTime);
                for (int i = 0; i < box.Count; i++)
                {
                    if (MouseManager.IsInRectangle(box[i].Bound) && MouseManager.IsClicking())
                    {
                        box[boxselect].IsSelect = false;
                        boxselect = i;
                        box[i].IsSelect = true;
                    }
                }
                box[boxselect].Write(KeyboardManager.RecupClavier());
                if (KeyboardManager.IsPressed(Keys.Back))
                    box[boxselect].RemoveLast();
            }
            else
            {
                box[3].RemoveAll();
                for (int i = 0; i < client.OtherPlayers.Count ; i++)
                    box[3].WriteLine(client.OtherPlayers[i].name+"");
            }
        }

        public override void Draw(GameTime gameTime, UberSpriteBatch spriteBatch)
        {
            spriteBatch.DrawUI(TexturesManager.Window, Bounds);
            spriteBatch.DrawUI(TexturesManager.Menu, "Client :", new Vector2(Bounds.X + Bounds.Width / 2 - TexturesManager.Menu.MeasureString("Serveur :").X / 2, Bounds.Y + TexturesManager.Menu.MeasureString("Serveur :").Y / 2), Color.Red);
            if (!IsJoin)
                joinButton.Draw(gameTime, spriteBatch);
            spriteBatch.DrawUI(TexturesManager.Menu, "Port : ", new Vector2(Bounds.X + 20, Bounds.Y + 60), Color.Red);
            spriteBatch.DrawUI(TexturesManager.Menu, "Nom : ", new Vector2(box[0].Bound.X + box[0].Bound.Width + 20, Bounds.Y + 60), Color.Red);
            spriteBatch.DrawUI(TexturesManager.Menu, "Ip :", new Vector2(Bounds.X + 10, box[0].Bound.Bottom + 20), Color.Red);
            foreach (var textBox in box)
                textBox.Draw(spriteBatch);

        }

        private void OnJoinMouseClick(object sender, MouseClickEventArgs e)
        {
            if (box[0].Text().Length > 0 && box[1].Text().Length > 0 && box[2].Text().Length > 0)
            {
                name = box[1].Text();
                try
                {
                    port = Convert.ToInt32(box[0].Text());
                    joinButton.MouseClick -= OnJoinMouseClick;
                    box[0].IsSelect = false;
                    box[1].IsSelect = false;
                    box[2].IsSelect = false;
                    IsJoin = true;
                    box.Add(new TextBox(new Vector2(Bounds.X + 20, box[2].Bound.Bottom + 10), 20, 10,
                                        TexturesManager.Menu, Color.Blue, Color.Red));
                    client = new Client(name);
                    client.Connect(box[2].Text(),port);
                    client.SendData();
                    client.StartReadThread();
                    //client.StartWaitStart();
                }
                catch (Exception)
                {
                    box[0].RemoveAll();
                }
            }
        }
        
    }
}
