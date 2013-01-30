using GameProjectReborn.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameProjectReborn.Camera
{
    public class Cam
    {
        readonly GraphicsDevice device;

        private readonly int worldWidth;
        private readonly int worldHeight;

        private const float ZoomArrièreMax = 2.0f;
        private const float ZoomAvantMax = 0.2f;

        public Vector2 Position { get; private set; }

        public float Zoom
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

        public Cam(int world_width, int world_height, GraphicsDevice device)
        {
            Position = Vector2.Zero;
            this.device = device;
            worldWidth = world_width;
            worldHeight = world_height;
        }

        public Matrix GetTransformation()
        {
            return Matrix.CreateTranslation(new Vector3(-Position.X, -Position.Y, 0)) * 
                Matrix.CreateScale(new Vector3(Zoom, Zoom, 1)) * 
                Matrix.CreateTranslation(new Vector3(device.Viewport.Width * 0.5f, device.Viewport.Height * 0.5f, 0)) 
                * Matrix.Identity;
        }

        public void CameraMouvement(Vector2 position)
        {
            Position = position;
        }
    }
}
