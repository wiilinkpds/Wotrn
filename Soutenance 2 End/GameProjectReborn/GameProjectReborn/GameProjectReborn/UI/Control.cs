﻿using GameProjectReborn.Managers;
using GameProjectReborn.Utils;
using Microsoft.Xna.Framework;

namespace GameProjectReborn.UI
{
    public abstract class Control
    {
        public Vector2 Position { get; set; }
        public Rectangle Bounds { get; set; }

        public delegate void MouseClickEventHandler(object sender, MouseClickEventArgs e);
        public event MouseClickEventHandler MouseClick;

        protected Control(Vector2 position)
        {
            Position = position;
        }

        public virtual void Update(GameTime gameTime)
        {
            if (MouseManager.IsInRectangle(Bounds) && MouseManager.IsLeftClicked())
            {
                OnMouseClick(new MouseClickEventArgs(0, MouseManager.Position));
            }
        }

        public abstract void Draw(GameTime gameTime, UberSpriteBatch spriteBatch);

        private void OnMouseClick(MouseClickEventArgs e)
        {
            MouseClickEventHandler handler = MouseClick;
            if (handler != null) handler(this, e);
        }

    }
}
