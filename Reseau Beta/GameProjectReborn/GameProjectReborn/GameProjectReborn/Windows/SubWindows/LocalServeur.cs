using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameProjectReborn.Managers;
using GameProjectReborn.MultiJoueurs;
using GameProjectReborn.Screens;
using GameProjectReborn.Screens.SubScreens;
using GameProjectReborn.UI;
using GameProjectReborn.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameProjectReborn.Windows.SubWindows
{
    class LocalServeur : Window
    {
        private Button StartButton, createButton;
        private List<TextBox> box;
        private int port, boxselect;
        private string name;
        private bool isCreate;
        private Serveur serveur;

        public LocalServeur(Screen parent, Vector2 position) : base(parent, position)
        {
            isCreate = false;
            name = "";
            box = new List<TextBox>();
            Bounds = new Rectangle((int) position.X, (int) position.Y, 2*MainGame.ScreenX/3, MainGame.ScreenY/2);
            StartButton = new Button(new Vector2(Bounds.X + Bounds.Width - TexturesManager.Menu.MeasureString("Lancer").X - 30, Bounds.Y + Bounds.Height - TexturesManager.Menu.MeasureString("Lancer").Y - 15), "Lancer");
            createButton = new Button(new Vector2(Bounds.X + Bounds.Width - TexturesManager.Menu.MeasureString("Créer").X - 30, Bounds.Y + 50),"Créer");
            createButton.MouseClick += OnCreateMouseClick;
            box.Add(new TextBox(new Vector2(Bounds.X + 20 + TexturesManager.Menu.MeasureString("Port :").X, Bounds.Y + 50),6,1,TexturesManager.Menu,Color.Blue,Color.Red));
            box[0].IsSelect = true;
            box.Add(new TextBox(new Vector2(box[0].Bound.X + box[0].Bound.Width + 20 + TexturesManager.Menu.MeasureString("Nom :").X,box[0].Bound.Y),20,1, TexturesManager.Menu, Color.Blue,Color.Red));
        }

        public override void Update(GameTime gameTime)
        {
            if (isCreate)
            {
                StartButton.Update(gameTime);
                box[2].RemoveAll();
                box[2].WriteLine(name);
                for (int i = 0; i < serveur.Clients.Count;i++)
                    box[2].WriteLine(serveur.Clients[i].name);
            }
            else
            {
                createButton.Update(gameTime);
                if (KeyboardManager.IsPressed(Keys.Tab))
                {
                    box[boxselect].IsSelect = false;
                    boxselect = (boxselect + 1) % box.Count;
                    box[boxselect].IsSelect = true;
                }
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
        }

        public override void Draw(GameTime gameTime, UberSpriteBatch spriteBatch)
        { 
            spriteBatch.DrawUI(TexturesManager.Window, Bounds);
            foreach (var textBox in box)
                textBox.Draw(spriteBatch);
            spriteBatch.DrawUI(TexturesManager.Menu,"Serveur :", new Vector2(Bounds.X + Bounds.Width / 2 - TexturesManager.Menu.MeasureString("Serveur :").X / 2, Bounds.Y + TexturesManager.Menu.MeasureString("Serveur :").Y / 2),Color.Red );
            spriteBatch.DrawUI(TexturesManager.Menu,"Port : ", new Vector2(Bounds.X + 20, Bounds.Y + 60),Color.Red);
            spriteBatch.DrawUI(TexturesManager.Menu, "Nom : ", new Vector2(box[0].Bound.X + box[0].Bound.Width + 20, Bounds.Y + 60), Color.Red);
            if (isCreate)
                StartButton.Draw(gameTime, spriteBatch);
            else
                createButton.Draw(gameTime, spriteBatch);
        }

        private void OnStartMouseClick(object sender, MouseClickEventArgs e)
        {
            serveur.Start();
        }

        private void OnCreateMouseClick(object sender, MouseClickEventArgs e)
        {
            if (box[0].Text().Length > 0 && box[1].Text().Length > 0)
            {
                name = box[1].Text();
                try
                {
                    port = Convert.ToInt32(box[0].Text());
                    StartButton.MouseClick += OnStartMouseClick;
                    createButton.MouseClick -= OnCreateMouseClick;
                    isCreate = true;
                    box[0].IsSelect = false;
                    box[1].IsSelect = false;
                    serveur = new Serveur(port);
                    box.Add(new TextBox(new Vector2(Bounds.X + 20, box[0].Bound.Bottom + 10), 20, 10,
                                        TexturesManager.Menu, Color.Blue, Color.Red));
                }
                catch (Exception)
                {
                    box[0].RemoveAll();
                }
            }
        }
    }
}
