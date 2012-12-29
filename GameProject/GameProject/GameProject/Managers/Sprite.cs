using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using GameProject.Joueurs;

namespace GameProject.Managers
{
    public class Sprite
    {
        public Texture2D Texture
        {
            get { return _texture; }
            set { _texture = value; }
        }
        private Texture2D _texture;

        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }
        private Vector2 _position;

        public virtual void Initialize(Vector2 Position_init)
        {
            _position = Position_init;
        }

        public virtual void LoadContent(ContentManager content, string assetName)
        {
            _texture = content.Load<Texture2D>(assetName);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, Color.White);
        }
        public virtual int Height()
        {
            return _texture.Height;
        }
        public virtual int Width()
        {
            return _texture.Width;
        }
        public virtual void Update(Sprite[] textTab, Sprite background, Sprite[] enemis)
        {
            MoteurPhysique.Colision(textTab ,this, background, enemis);
        }
    }
}
