using Microsoft.Xna.Framework;

namespace GameProjectReborn.Managers
{
    public class Cam
    {
        readonly GraphicsDeviceManager device;

        private Matrix transformation { get; set; }

        public static Vector2 Position { get; private set; }

        public Cam(GraphicsDeviceManager device)
        {
            Position = Vector2.Zero;
            this.device = device;
        }
        public Vector2 ScreenLocation(Vector2 position)
        {
            return Vector2.Transform(position, Matrix.Invert(transformation));
        }
        public Vector2 MapLocation(Vector2 position)
        {
            return Vector2.Transform(position, transformation);
        }

        public Matrix GetTransformation()
        {
            transformation = Matrix.CreateTranslation(new Vector3(-Position.X, -Position.Y, 0))*
                             Matrix.CreateTranslation(new Vector3(device.GraphicsDevice.Viewport.Width*0.5f,
                                                                  device.GraphicsDevice.Viewport.Height*0.5f, 0))
                             *Matrix.Identity;
            return transformation;
        }

        public void CameraMouvement(Vector2 position)
        {
            Position = position;
        }

        public void Update(Vector2 position)
        {
            CameraMouvement(position);
        }
    }
}


