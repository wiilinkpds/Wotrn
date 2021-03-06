﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameProjectReborn.Managers
{
    public class Cam
    {
        readonly GraphicsDeviceManager device;

        private readonly int worldWidth;
        private readonly int worldHeight;

        private Matrix transformation { get; set; }

        public static Vector2 Position { get; private set; }

        public float Zoom
        {
            get { return zoom; }
            set
            {
                zoom = value;
                if (zoom < 0.7F)
                    zoom = 0.7F;
                else if (zoom > 2)
                    zoom = 2;
            }
        }
        private float zoom = 1.0f;

        public void Zooming()
        {
            if (MouseManager.IsScrollingUp())
                Zoom += 0.025F;
            else if (MouseManager.IsScrollingDown())
                Zoom -= 0.025F;
        }

        public Cam(int world_width, int world_height, GraphicsDeviceManager device)
        {
            Position = Vector2.Zero;
            this.device = device;
            worldWidth = world_width;
            worldHeight = world_height;
        }
        public Vector2 Location(Vector2 position)
        {
            return Vector2.Transform(position, Matrix.Invert(transformation));
        }

        public Matrix GetTransformation()
        {
            transformation = Matrix.CreateTranslation(new Vector3(-Position.X, -Position.Y, 0)) *
                Matrix.CreateScale(new Vector3(Zoom, Zoom, 1)) *
                Matrix.CreateTranslation(new Vector3(device.GraphicsDevice.Viewport.Width * 0.5f, device.GraphicsDevice.Viewport.Height * 0.5f, 0))
                * Matrix.Identity;
            return transformation;
        }

        public void CameraMouvement(Vector2 position)
        {
            Position = position;
        }

        public void Update(Vector2 position)
        {
            CameraMouvement(position);
            Zooming();
        }
    }
}


