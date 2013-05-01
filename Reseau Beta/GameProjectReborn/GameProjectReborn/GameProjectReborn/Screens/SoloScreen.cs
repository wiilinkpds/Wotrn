using System;
using System.Collections.Generic;
using GameProjectReborn.Entities;
using GameProjectReborn.Managers;
using GameProjectReborn.Maps;
using GameProjectReborn.Screens.SubScreens;
using Microsoft.Xna.Framework;

namespace GameProjectReborn.Screens
{
    class SoloScreen : GameScreen
    {
        public SoloScreen()
        {
            Reseau = false;
            MapData mapData = new MapData();
            if (!mapData.FromFile("Content/Maps/map.mrm"))
                throw new Exception();
            MapFirst = new Map(mapData);
            camera = new Cam(MapFirst.Data.MapWidth * 32, MapFirst.Data.MapHeight * 32, MainGame.graphics);
        }

        public override void Update(GameTime gameTime)
        {
            if (Player.Life <= 0)
                MainGame.GetInstance().SetScreen(new GameOverScreen());
            base.Update(gameTime);
        }
    }
}
