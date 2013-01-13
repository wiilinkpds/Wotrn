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

namespace GameProject.Camera
{
    public class Camera
    { 
        GraphicsDevice _device;

        private int _worldWidth;


        private int _worldHeight;


        public Camera(int worldWidth, int worldHeight, GraphicsDevice device)
        {
            _device = device;
            _worldWidth = worldWidth;
            _worldHeight = worldHeight;
        }

        public float Rotation
        {
            get { return _rotation; }
            set { _rotation = value; }
        }
        private float _rotation = 0.0f;

        public Vector2 Position
        {
            get { return _position; }
            set { 
                float BordGauche = (float)_device.Viewport.Width * 0.5f / _zoom;
                float BordDroit = _worldWidth - (float)_device.Viewport.Width * 0.5f / _zoom;
                float BordBas = _worldHeight - (float)_device.Viewport.Height * 0.5f / _zoom;
                float BordHaut = (float)_device.Viewport.Height * 0.5f / _zoom;
                _position = value;

                if (_position.X < BordGauche)
                    _position.X = BordGauche;
                if (_position.X > BordDroit)
                    _position.X = BordDroit;
                if (_position.Y < BordHaut)
                    _position.Y = BordHaut;
                if (_position.Y > BordBas)
                    _position.Y = BordBas;
                }
        }
        private Vector2 _position = Vector2.Zero;

        public float Zoom
        {
            get { return _zoom; }
            set
            {
                _zoom = value;
                if (_zoom < 1)
                    _zoom = ZoomArrièreMax;
                if (_zoom > 10)
                    _zoom = ZoomAvantMax;
                float zoomMinX = (float)_device.Viewport.Width / _worldWidth;
                float zoomMinY = (float)_device.Viewport.Height / _worldHeight;
                float zoomMin = (zoomMinX < zoomMinY) ? zoomMinY : zoomMinX;
                if (_zoom < zoomMin)
                    _zoom = zoomMin;
            }
        }
        private float _zoom = 1.0f;

        private const float ZoomArrièreMax = 2.0f;
        private const float ZoomAvantMax = 0.2f;

        public Matrix GetTransformation()
        {
            return Matrix.CreateTranslation(new Vector3(-_position.X, -_position.Y, 0)) * 
                Matrix.CreateRotationZ(Rotation) * 
                Matrix.CreateScale(new Vector3(Zoom, Zoom, 1)) * 
                Matrix.CreateTranslation(new Vector3(_device.Viewport.Width * 0.5f, _device.Viewport.Height * 0.5f, 0));
        }

        public void CameraMouvement(Managers.Sprite Joueur)
        {
            Position = Joueur.Position;
            for (int i = 0; i < MainGame.life; i++)
                MainGame.SLife[i].Position = new Vector2((_position.X - MainGame.ScreenX / 2 ) + i * 2.5f, _position.Y - MainGame.ScreenY / 2);
            for (int i = 0; i < MainGame.mana; i++)
                MainGame.SMana[i].Position = new Vector2((_position.X - MainGame.ScreenX / 2) + i * 2.5f, _position.Y - MainGame.ScreenY / 2 + 20);

        }
    }
}
