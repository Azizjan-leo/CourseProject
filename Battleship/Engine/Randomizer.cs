using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Engine
{
    public static class Randomizer
    {
        static bool horiz = true;

        public static (int x, int y, bool isHorizontal) GenNext()
        {
            var rand = new Random();
            int x = rand.Next(1, 11);
            int y = rand.Next(1, 11);
            bool isHorizontal = horiz = !horiz;
            return (x, y, isHorizontal);
        }
    }
}
