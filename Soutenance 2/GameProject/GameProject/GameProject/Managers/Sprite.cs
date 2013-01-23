using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameProject.Managers
{
    public class Sprite
    {
        public Texture2D Texture { get; set; }

        public Vector2 Position { get; set; }

        public Rectangle RectangleColision
        {
            get
            {
                if (SourceRectangle != null)
                    return new Rectangle((int)Position.X, (int)Position.Y + SourceRectangle.Value.Height / 2, SourceRectangle.Value.Width, SourceRectangle.Value.Height / 2);
                return new Rectangle((int)Position.X, (int)Position.Y + Height / 2, Width, Height / 2);
            }
        }
        public Rectangle Rectangle { get { return new Rectangle((int)Position.X, (int)Position.Y, Width, Height); }}

        protected Rectangle? SourceRectangle { get; set; }

        protected int MaXindex { private get; set; }
        protected int MaYindex { private get;set;}
        float xindex;
        private const float Yindex = 0;
        protected string ReadingDimension { private get; set; }

        public void Initialize(Vector2 position_init)
        {
            SourceRectangle = null;
            Position = position_init;
        }
        public void Initialize(Vector2 position_init, Rectangle? source_rect)
        {
            Position = position_init;
            SourceRectangle = source_rect;
            MaXindex = 0;
            MaYindex = 0;
        }

        public void LoadContent(ContentManager content, string asset_name)
        {
            Texture = content.Load<Texture2D>(asset_name);
        }
        public void LoadContent(ContentManager content, string asset_name, int max_xindex, int max_yindex, string reading_dim)
        {
            Texture = content.Load<Texture2D>(asset_name);
            MaXindex = max_xindex;
            MaYindex = max_yindex;
            ReadingDimension = reading_dim;
        }

        public void Draw(SpriteBatch sprite_batch)
        {
            sprite_batch.Draw(Texture,Position,SourceRectangle, Color.White);
        }
        public void Draw(SpriteBatch sprite_batch, Rectangle rectangle)
        {
            sprite_batch.Draw(Texture, rectangle, Color.White);
        }

        public int Height { get { return Texture.Height; }}

        public int Width { get { return Texture.Width; }}

        protected void UpdateAnimation(GameTime game_time)
        {
            if (MaXindex != 0)
            {
                xindex += game_time.ElapsedGameTime.Milliseconds * 0.006f;

                if (xindex > MaXindex)
                    xindex = 0;
                if (ReadingDimension == "h")
                    SourceRectangle = new Rectangle((int)xindex * SourceRectangle.Value.Width, SourceRectangle.Value.Y, SourceRectangle.Value.Width, SourceRectangle.Value.Height);
                else if (ReadingDimension == "v")
                    SourceRectangle = new Rectangle(SourceRectangle.Value.X, (int)Yindex * SourceRectangle.Value.Height, SourceRectangle.Value.Width, SourceRectangle.Value.Height);
            }
        }
        public void UpdateSetStateAnimation(int index)
        {
            if (ReadingDimension == "h")
                SourceRectangle = new Rectangle(index * SourceRectangle.Value.Width, SourceRectangle.Value.Y, SourceRectangle.Value.Width, SourceRectangle.Value.Height);
            else if (ReadingDimension == "v")
                SourceRectangle = new Rectangle(SourceRectangle.Value.X, index * SourceRectangle.Value.Height, SourceRectangle.Value.Width, SourceRectangle.Value.Height);
        }

        public void UpdateSetStateAnimation(int index_x, int index_y)
        {
            SourceRectangle = new Rectangle(index_x * SourceRectangle.Value.Width, index_y * SourceRectangle.Value.Height, SourceRectangle.Value.Width, SourceRectangle.Value.Height);
        }
    }
}
