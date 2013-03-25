using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameProjectReborn.Entities;
using GameProjectReborn.Utils;
using Microsoft.Xna.Framework;

namespace GameProjectReborn.Managers
{
    public class Temps
    {
        private static List<MoteurParticule> Rain = new List<MoteurParticule>();

        public static void Pluie(UberSpriteBatch sprite_batch, GameTime game_time, Maps.MapData mapdata, bool end)
        {
            if (game_time.TotalGameTime.TotalMilliseconds % 1 < 2 && !end)
                Rain.Add(new MoteurParticule(TexturesManager.Pluie, new Vector2(RandomManager.Next(-100, mapdata.MapWidth * 32), -100), Direction.Down, RandomManager.Next(50), 3));
            foreach (var gout in Rain)
            {
                gout.update();
                gout.Draw(sprite_batch);
            }
            Rain.RemoveAll(particule => particule.IsDead || particule.position.X > mapdata.MapWidth * 32 || particule.position.Y > mapdata.MapHeight * 32);

        }

        public static void Neige(UberSpriteBatch sprite_batch, GameTime game_time, Maps.MapData mapdata, bool end)
        {
            Random rand = new Random();
            if (game_time.TotalGameTime.TotalMilliseconds % 1 < 2 && !end)
                Rain.Add(new MoteurParticule(TexturesManager.Neige, new Vector2(RandomManager.Next(-100, mapdata.MapWidth * 32), -100), Direction.Down, RandomManager.Next(100), 1.5F));
            foreach (var flocon in Rain)
            {
                flocon.update();
                flocon.Draw(sprite_batch);
            }
            Rain.RemoveAll(particule => particule.IsDead || particule.position.X > mapdata.MapWidth * 32 || particule.position.Y > mapdata.MapHeight * 32);
        }
    }
}
