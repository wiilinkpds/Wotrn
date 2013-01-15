using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Jeux
{
    class Cursor
    {
        Texture2D texture;
        Vector2 position;
        KeyboardState keyboardState;
        KeyboardState lastKeyboardState;

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Cursor()
        {
            new Vector2(0, 0);
        }

        public void LoadContent(ContentManager Content)
        {
            texture = Content.Load<Texture2D>("tile");
        }

        public void Update(GameTime gameTime, Vector2 mapSize)
        {
            lastKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Up) & lastKeyboardState.IsKeyUp(Keys.Up) & position.Y > 0)
            {
                position.Y--;
            }
            if (keyboardState.IsKeyDown(Keys.Down) & lastKeyboardState.IsKeyUp(Keys.Down) & position.Y < mapSize.Y - 1)
            {
                position.Y++;
            }
            if (keyboardState.IsKeyDown(Keys.Left) & lastKeyboardState.IsKeyUp(Keys.Left) & position.X > 0)
            {
                position.X--;
            }
            if (keyboardState.IsKeyDown(Keys.Right) & lastKeyboardState.IsKeyUp(Keys.Right) & position.X < mapSize.X - 1)
            {
                position.X++;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Vector2(position.X * texture.Width, position.Y * texture.Height), Color.Black);
        }
    }
}
