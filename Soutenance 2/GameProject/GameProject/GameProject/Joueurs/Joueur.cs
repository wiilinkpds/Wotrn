using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameProject.Managers;

namespace GameProject.Joueurs
{
    public class Joueur : Personnage
    {
        public void Update(Sprite[] text_tab, Sprite background, Sprite[] enemis, GameTime game_time)
        {
            MoteurPhysique.Colision(text_tab, this, background, enemis, game_time);
        }

        public void Draw(SpriteBatch sprite_batch, Camera.Cam camera)
        {
            sprite_batch.Draw(Texture, Position, SourceRectangle, Color.White);
            sprite_batch.DrawString(DrawVieMana, "Vie : ", new Vector2(camera.Position.X - MainGame.ScreenX / 2, camera.Position.Y - MainGame.ScreenY / 2), Color.Red);
            sprite_batch.DrawString(DrawVieMana, "Mana : ", new Vector2(camera.Position.X - MainGame.ScreenX / 2, camera.Position.Y + Barre.Height + 10 - MainGame.ScreenY / 2), Color.BlueViolet);
            sprite_batch.DrawString(DrawVieMana, "Fatigue : ", new Vector2(camera.Position.X - MainGame.ScreenX / 2, camera.Position.Y + 2 * Barre.Height + 20 - MainGame.ScreenY / 2), Color.DarkMagenta);
            for (int i = 0; i < Life; i++)
                sprite_batch.Draw(Barre, new Vector2(camera.Position.X + (Barre.Width + 1) * i + DrawVieMana.MeasureString("Vie : ").X - MainGame.ScreenX / 2, camera.Position.Y - MainGame.ScreenY / 2), Color.Red);
            for (int i = 0; i < Mana; i++)
                sprite_batch.Draw(Barre, new Vector2(camera.Position.X + (Barre.Width + 1) * i + DrawVieMana.MeasureString("Mana : ").X - MainGame.ScreenX / 2, camera.Position.Y + Barre.Height + 10 - MainGame.ScreenY / 2), Color.BlueViolet);
            for (int i = 0; i < Fatigue; i++)
                sprite_batch.Draw(Barre, new Vector2(camera.Position.X + (Barre.Width + 1) * i + DrawVieMana.MeasureString("Fatigue : ").X - MainGame.ScreenX / 2, camera.Position.Y + 2 * Barre.Height + 20 - MainGame.ScreenY / 2), Color.DarkMagenta);
        }
    }
}
