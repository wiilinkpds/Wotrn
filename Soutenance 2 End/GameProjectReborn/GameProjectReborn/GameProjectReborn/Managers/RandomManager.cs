using System;

namespace GameProjectReborn.Managers
{
    public static class RandomManager
    {
        private static Random random;

        public static void Init()
        {
            random  = new Random();
        }

        public static int Next(int min, int max)
        {
            return random.Next(min, max + 1);
        }

        public static int Next(int max)
        {
            return random.Next(max + 1);
        }
    }
}