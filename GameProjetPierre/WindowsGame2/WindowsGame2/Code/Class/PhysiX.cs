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
using System.IO;

namespace Jeux
{
    class PhysiX
    {
        public PhysiX()
        {

        }

        public bool Collision(Map map, Player player, string direction)
        {
            bool collision = false;
            for (int i = 0; i < map.Size.X; i++)
            {
                for (int j = 0; j < map.Size.Y; j++)
                {
                    if (map.Tiles[i, j].ColisionRectangle == null)
                        collision |= false;
                    else if (direction == "u")
                        collision |= map.Tiles[i, j].ColisionRectangle.Intersects(new Rectangle(player.ColisionRectangle.X, player.ColisionRectangle.Top, player.ColisionRectangle.Width, 0));
                    else if (direction == "d")
                        collision |= map.Tiles[i, j].ColisionRectangle.Intersects(new Rectangle(player.ColisionRectangle.X, player.ColisionRectangle.Bottom, player.ColisionRectangle.Width, 0));
                    else if (direction == "r")
                        collision |= map.Tiles[i, j].ColisionRectangle.Intersects(new Rectangle(player.ColisionRectangle.Right, player.ColisionRectangle.Y, 0, player.ColisionRectangle.Height));
                    else if (direction == "l")
                        collision |= map.Tiles[i, j].ColisionRectangle.Intersects(new Rectangle(player.ColisionRectangle.Left, player.ColisionRectangle.Y, 0, player.ColisionRectangle.Height));
                }
            }
            if (player.Colision == true)
            {
                return collision;
            }
            else
                return false;
        }
    }
}
