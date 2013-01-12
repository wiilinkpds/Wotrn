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
    class Camera
    {
        protected float zoom;
        public Matrix transform;
        public Vector2 position;
        protected float rotation;
        bool camLock;

        public Camera()
        {
            camLock = true;
            zoom = 1.0f;
            rotation = 0.0f;
            position = Vector2.Zero;
        }

        public float Zoom
        {
            get { return zoom; }
            set { if (zoom < 0.1f) zoom = 0.1f; 
                  else zoom = value; }
        }

        public bool CamLock
        {
            get { return camLock; }
            set { camLock = value; }
        }

        public float Rotation
        {
            get { return this.rotation; }
            set { this.rotation = value; }
        }

        public void Move(Vector2 translation)
        {
            this.position += translation;
        }

        public Vector2 Position
        {
            get { return this.position; }
            set { this.position = value; }
        }

        public Vector2 ToLocalLocation(Vector2 position)
        {
            return Vector2.Transform(position, transform);
        }

        public Vector2 ToWorldLocation(Vector2 position)
        {
            return Vector2.Transform(position, Matrix.Invert(transform));
        }

        public Matrix GetTransformation(GraphicsDevice graphicsDevice)
        {
            transform =
              Matrix.CreateTranslation(new Vector3(-position, 0)) * Matrix.Identity *
                                         Matrix.CreateRotationZ(this.rotation) *
                                         Matrix.CreateScale(new Vector3(this.zoom, this.zoom, 1)) *
                                         Matrix.CreateTranslation(new Vector3(graphicsDevice.Viewport.Width * 0.5f, graphicsDevice.Viewport.Height * 0.5f, 0));
            return transform;
        }
    }
}