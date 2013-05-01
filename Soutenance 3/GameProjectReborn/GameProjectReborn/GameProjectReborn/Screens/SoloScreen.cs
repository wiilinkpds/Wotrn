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
            Camera = new Cam(MainGame.GetInstance().graphics);
        }
    }
}
