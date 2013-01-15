using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;

namespace Jeux
{
    class CameraSystem
    {
        Camera cam;

        public CameraSystem()
        {

        }

        public void Update(Camera cam, Player player, Map map, GraphicsDeviceManager graphics, KeyboardState kState)
        {
            this.cam = cam;
            if (cam.CamLock)
            {
                if (cam.ToWorldLocation(Vector2.Zero).X <= 0)
                {
                    if(player.Position.X >= cam.ToWorldLocation(new Vector2(graphics.PreferredBackBufferWidth/2,graphics.PreferredBackBufferHeight/2)).X)
                        cam.Position = (new Vector2(player.Position.X + (player.SourceRectangle.Value.Width / 2), player.Position.Y + (player.SourceRectangle.Value.Height / 2)));
                }
                else
                    cam.Position = (new Vector2(player.Position.X + (player.SourceRectangle.Value.Width/2), player.Position.Y + (player.SourceRectangle.Value.Height/2)));
            }
            
            if (kState.IsKeyDown(Keys.Z))
            {
                cam.CamLock = false;
                cam.Move(new Vector2(0, -10));
            }
            if (kState.IsKeyDown(Keys.S))
            {
                cam.CamLock = false;
                cam.Move(new Vector2(0, 10));
            }
            if (kState.IsKeyDown(Keys.Q))
            {
                cam.CamLock = false;
                cam.Move(new Vector2(-10, 0));
            }
            if (kState.IsKeyDown(Keys.D))
            {
                cam.CamLock = false;
                cam.Move(new Vector2(10, 0));
            }
            if (kState.IsKeyDown(Keys.L) & cam.CamLock == false)
            {
                cam.CamLock = true;
            }
            if (kState.IsKeyDown(Keys.E))
            {
                cam.Zoom += 0.01f;
            }
            if (kState.IsKeyDown(Keys.A))
            {
                cam.Zoom -= 0.01f;
            }
            if (kState.IsKeyDown(Keys.W))
            {
                cam.Rotation += 0.01f;
            }
            if (kState.IsKeyDown(Keys.X))
            {
                cam.Rotation -= 0.01f;
            }
            if (kState.IsKeyDown(Keys.V))
            {
                cam.Rotation = 0;
            }
            if (kState.IsKeyDown(Keys.O))
                cam.position = cam.ToWorldLocation(player.Position);
        }

        private Camera Cam
        {
            get { return this.cam; }
            set { this.cam = value; }
        }
    }
}
