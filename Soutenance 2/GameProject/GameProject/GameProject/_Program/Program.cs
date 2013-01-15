using System;

namespace GameProject
{
#if WINDOWS || XBOX
    static class Program
    {
        static void Main()
        {
            using (MainGame game = new MainGame())
            {
                game.Run();
            }
        }
    }
#endif
}

