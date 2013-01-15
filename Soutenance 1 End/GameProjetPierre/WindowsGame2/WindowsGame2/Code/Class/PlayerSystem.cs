using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    class PlayerSystem
    {
        string direction;
        PhysiX physiX = new PhysiX();

        public void Update(GameTime gameTime,KeyboardState kState, Player player, Map map)
        {
            if (kState.IsKeyDown(Keys.Up))
            {
                direction = "u";
                if (!physiX.Collision(map,player,direction))
                {
                    player.UpdateSetStateAnimation(0, 3);
                    player.UpdateAnimation(gameTime);
                    player.PlayerUpdate(new Vector2(0, -1 * player.Speed * gameTime.ElapsedGameTime.Milliseconds));
                }
                else
                {
                    player.UpdateSetStateAnimation(0, 3);
                }
            }
            else if (kState.IsKeyDown(Keys.Down))
            {
                direction = "d";
                if (!physiX.Collision(map, player, direction))
                {
                    player.UpdateSetStateAnimation(0, 0);
                    player.UpdateAnimation(gameTime); ;
                    player.PlayerUpdate(new Vector2(0, 1 * player.Speed * gameTime.ElapsedGameTime.Milliseconds));
                }
                else
                {
                    player.UpdateSetStateAnimation(0, 0);
                }
            }
            else if (kState.IsKeyDown(Keys.Right))
            {
                direction = "r";
                if (!physiX.Collision(map, player, direction))
                {
                    player.UpdateSetStateAnimation(0, 2);
                    player.UpdateAnimation(gameTime);
                    player.PlayerUpdate(new Vector2(1 * player.Speed * gameTime.ElapsedGameTime.Milliseconds, 0));
                }
                else
                {
                    player.UpdateSetStateAnimation(0, 2);
                }
            }
            else if (kState.IsKeyDown(Keys.Left))
            {
                direction = "l";
                if (!physiX.Collision(map, player, direction))
                {
                    player.UpdateSetStateAnimation(0, 1);
                    player.UpdateAnimation(gameTime);
                    player.PlayerUpdate(new Vector2(-1 * player.Speed * gameTime.ElapsedGameTime.Milliseconds, 0));
                }
                else
                    player.UpdateSetStateAnimation(0, 1);
            }
            else
            {
                player.UpdateSetStateAnimation(0);
            }
        }
    }
}
