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
            spriteBatch.DrawString(this.DrawVieMana, "Vie : ", new Vector2(camera.Position.X - MainGame.ScreenX / 2, camera.Position.Y - MainGame.ScreenY / 2), Color.Red);
            spriteBatch.DrawString(this.DrawVieMana, "Mana : ", new Vector2(camera.Position.X - MainGame.ScreenX / 2, camera.Position.Y + Barre.Height + 10 - MainGame.ScreenY / 2), Color.BlueViolet);
            spriteBatch.DrawString(this.DrawVieMana, "Fatigue : ", new Vector2(camera.Position.X - MainGame.ScreenX / 2, camera.Position.Y + 2 * Barre.Height + 20 - MainGame.ScreenY / 2), Color.DarkMagenta);
            for (int i = 0; i < Life; i++)
                spriteBatch.Draw(Barre, new Vector2(camera.Position.X + (Barre.Width + 1) * i + this.DrawVieMana.MeasureString("Vie : ").X - MainGame.ScreenX / 2, camera.Position.Y - MainGame.ScreenY / 2), Color.Red);
            for (int i = 0; i < Mana; i++)
                spriteBatch.Draw(Barre, new Vector2(camera.Position.X + (Barre.Width + 1) * i + this.DrawVieMana.MeasureString("Mana : ").X - MainGame.ScreenX / 2, camera.Position.Y + Barre.Height + 10 - MainGame.ScreenY / 2), Color.BlueViolet);
            for (int i = 0; i < Fatigue; i++)
                spriteBatch.Draw(Barre, new Vector2(camera.Position.X + (Barre.Width + 1) * i + this.DrawVieMana.MeasureString("Fatigue : ").X - MainGame.ScreenX / 2, camera.Position.Y + 2 * Barre.Height + 20 - MainGame.ScreenY / 2), Color.DarkMagenta);
        }
    }
}
