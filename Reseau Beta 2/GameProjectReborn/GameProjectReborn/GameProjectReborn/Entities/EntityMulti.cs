using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameProjectReborn.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameProjectReborn.Entities
{
    [Serializable]
    public class EntityMulti
    {
        public double Life;
        public double Power;
        public Vector2 Position;
        public Direction Direction;
        public string name { get; set; }

        public Player MultiToPlayer(GameScreen game, Texture2D text)
        {
            Player player = new Player(game,text);
            player.Life = Life;
            player.Power = Power;
            player.Position = Position;
            player.Direction = Direction;
            return player;
        }

    }
}
