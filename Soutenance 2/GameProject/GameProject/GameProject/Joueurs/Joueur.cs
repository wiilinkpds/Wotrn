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
using GameProject.Managers;

namespace GameProject.Joueurs
{
    public class Joueur : Personnage
    {
        public virtual void Update(Sprite[] textTab, Sprite background, Sprite[] enemis, GameTime gameTime)
        {
            MoteurPhysique.Colision(textTab, this, background, enemis, gameTime);
        }

        public virtual void Draw(SpriteBatch spriteBatch, Camera.Camera camera)
        {
            spriteBatch.Draw(Texture, Position, SourceRectangle, Color.White);
            for (int i = 0; i < Life; i++)
                spriteBatch.Draw(LifeT, new Vector2(camera.Position.X + LifeT.Width * i - MainGame.ScreenX / 2, camera.Position.Y - MainGame.ScreenY / 2), Color.White);
            for (int i = 0; i < Mana; i++)
                spriteBatch.Draw(ManaT, new Vector2(camera.Position.X + ManaT.Width * i - MainGame.ScreenX / 2, camera.Position.Y + LifeT.Height + 10 - MainGame.ScreenY / 2), Color.White);
        }
    }
}
