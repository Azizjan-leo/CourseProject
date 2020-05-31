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

        (int x, int y) _corner;
        public int XPix // X coodinate in pixels 
        { 
            get 
            {
                return _corner.x + 30 * X;
            }
            set { }
        }
        public int YPix // Y coordinate in pixels
        {
            get
            {
                return _corner.y + 30 * Y;
            }
            set { }
        }
        public bool IsAlive { get; set; }

        public Deck((int x, int y) corner, int x, int y, bool isAlive)
        {
            _corner.x = corner.x - 30;
            _corner.y = corner.y - 30;
            X = x;
            Y = y;
            IsAlive = isAlive;
        }
    }
}
