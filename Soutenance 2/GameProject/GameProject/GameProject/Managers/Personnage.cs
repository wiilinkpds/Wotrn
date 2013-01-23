using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameProject.Managers
{
    public class Personnage : Sprite
    {
        public int Life { get; set; }
        public int Mana { get; set; }
        public int Fatigue { get; set; }
        public float Vitesse { get; private set; }

        protected Texture2D Barre { get; private set; } //Sert pour representer la vie
        protected SpriteFont DrawVieMana { get; private set; }
        private string Name { get; set; }

        public virtual void Initialize(Vector2 position_init, Rectangle? source_rect, int life, int mana,int fatigue, float vitesse, string name)
        {
            Position = position_init;
            SourceRectangle = source_rect;
            Life = life;
            Mana = mana;
            Fatigue = fatigue;
            Vitesse = vitesse;
            MaXindex = 0;
            MaYindex = 0;
            Name = name;
        }

        public void LoadContent(ContentManager content, string asset_name,int max_x, int max_y, string read_dim, string barre)
        {
            Texture = content.Load<Texture2D>(asset_name);
            Barre = content.Load<Texture2D>(barre);
            DrawVieMana = content.Load<SpriteFont>("Sprites/Perso/VieMana/viemana");
            MaXindex = max_x;
            MaYindex = max_y;
            ReadingDimension = read_dim;
        }

        public void Move(string direction, GameTime game_time)
        {
            if (direction == "U")
            {
                UpdateSetStateAnimation(0, 3);
                UpdateAnimation(game_time);
                Position = new Vector2(Position.X, Position.Y - 1);
            }
            else if (direction == "D")
            {
                UpdateSetStateAnimation(0, 0);
                UpdateAnimation(game_time);
                Position = new Vector2(Position.X, Position.Y + 1);
            }
            else if (direction == "R")
            {
                UpdateSetStateAnimation(0, 2);
                UpdateAnimation(game_time);
                Position = new Vector2(Position.X + 1, Position.Y);
            }
            else if (direction == "L")
            {
                UpdateSetStateAnimation(0, 1);
                UpdateAnimation(game_time);
                Position = new Vector2(Position.X - 1, Position.Y);
            }
        }

    }
}
