using System;

namespace Battleship.Engine
{
    public static class Randomizer
    {
        static bool horiz = true;

        public static (int x, int y, bool isHorizontal) GenNextShip()
        {
            var rand = new Random();
            int x = rand.Next(1, 11);
            int y = rand.Next(1, 11);
            bool isHorizontal = horiz = !horiz;
            return (x, y, isHorizontal);
        }

        public static (int x, int y) GetShot()
        {
            var rand = new Random();
            int x = rand.Next(1, 11);
            int y = rand.Next(1, 11);
            return (x, y);
        }
    }
}
