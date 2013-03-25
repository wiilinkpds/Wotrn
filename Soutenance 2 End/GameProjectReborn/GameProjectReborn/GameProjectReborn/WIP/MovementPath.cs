using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace GameProjectReborn.WIP
{
    public class MovementPath
    {
        public IList<Point> Cells { get; set; }

        public MovementPath()
        {
            Cells = new List<Point>();
        }
    }
}