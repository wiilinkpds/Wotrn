using System;
using GameProjectReborn.Managers;
using GameProjectReborn.Maps;
using Microsoft.Xna.Framework;

namespace GameProjectReborn.Screens
{
    public class MultiScreen : GameScreen
    {
        public MultiScreen()
        {
            Reseau = true;
            MapData mapData = new MapData();
            if (!mapData.FromFile("Content/Maps/map.mrm"))
                throw new Exception();
            MapFirst = new Map(mapData);
            camera = new Cam(MapFirst.Data.MapWidth * 32, MapFirst.Data.MapHeight * 32, MainGame.graphics);
        }

    }
}

