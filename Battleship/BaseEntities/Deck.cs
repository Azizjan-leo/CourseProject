using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.BaseEntities
{
    public class Deck
    {
        public int X { get; set; } // Letter
        public int Y { get; set; } // Number
        public bool IsAlive { get; set; }
        public Deck(int x, int y, bool isAlive)
        {
            X = x;
            Y = y;
            IsAlive = isAlive;
        }
    }
}
