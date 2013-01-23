using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameProject.Camera
{
    public class Cam
    {
        readonly GraphicsDevice device;

        private readonly int worldWidth;
        private readonly int worldHeight;


        private float Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }
        private float rotation = 0.0f;

        public Vector2 Position
        {
            get { return position; }
            private set { 
                float bordGauche = device.Viewport.Width * 0.5f / zoom;
                float bordDroit = worldWidth - device.Viewport.Width * 0.5f / zoom;
                float bordBas = worldHeight - device.Viewport.Height * 0.5f / zoom;
                float bordHaut = device.Viewport.Height * 0.5f / zoom;
                position = value;

                if (position.X < bordGauche)
                    position.X = bordGauche;
                if (position.X > bordDroit)
                    position.X = bordDroit;
                if (position.Y < bordHaut)
                    position.Y = bordHaut;
                if (position.Y > bordBas)
                    position.Y = bordBas;
                }
        }
        private Vector2 position = Vector2.Zero;

        private float Zoom
        {
            get { return zoom; }
            set
            {
                zoom = value;
                if (zoom < 1)
                    zoom = ZoomArrièreMax;
                if (zoom > 10)
                    zoom = ZoomAvantMax;
                float zoomMinX = (float)device.Viewport.Width / worldWidth;
                float zoomMinY = (float)device.Viewport.Height / worldHeight;
                float zoomMin = (zoomMinX < zoomMinY) ? zoomMinY : zoomMinX;
                if (zoom < zoomMin)
                    zoom = zoomMin;
            }
        }
        private float zoom = 1.0f;

        private const float ZoomArrièreMax = 2.0f;
        private const float ZoomAvantMax = 0.2f;

        public Cam(int world_width, int world_height, GraphicsDevice device)
        {
            this.device = device;
            worldWidth = world_width;
            worldHeight = world_height;
        }

        public Matrix GetTransformation()
        {
            return Matrix.CreateTranslation(new Vector3(-position.X, -position.Y, 0)) * 
                Matrix.CreateRotationZ(Rotation) * 
                Matrix.CreateScale(new Vector3(Zoom, Zoom, 1)) * 
                Matrix.CreateTranslation(new Vector3(device.Viewport.Width * 0.5f, device.Viewport.Height * 0.5f, 0)) 
                * Matrix.Identity;
        }

        public void CameraMouvement(Managers.Sprite joueur)
        {
            Position = joueur.Position;
        }
    }
}
