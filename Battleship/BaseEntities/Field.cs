using Battleship.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.BaseEntities
{
    public class Field
    {
        public List<Ship> Ships { get; set; }

        
        public Field(int shipNum)
        {
            Ships = new List<Ship>(shipNum);
        }

        public bool AddShip(int x, int y, bool isHorizontal, int deckNum)
        {
            if ((isHorizontal && x + deckNum > 10) || (!isHorizontal && y > 10)) // A ship should not stick out the field
                return false;
            int tempX = x, tempY = y;

            int xShift = isHorizontal ? 1 : 0;
            int yShift = isHorizontal ? 0 : 1;

            for (int i = 0; i < deckNum; i++)
            {
                foreach (var ship in Ships)
                {
                    if (!ship.IsFree(tempX, tempY))
                        return false;
                }
                tempX += xShift;
                tempY += yShift;
            }        

            Ships.Add(new Ship(deckNum, x, y, isHorizontal));
            return true;
        }

        public void Place()
        {
            for (int i = 1; i < 5; i++)
            {
                for (int j = i; j < 5; j++)
                {
                    var rand = Randomizer.GenNext();
                    while (!AddShip(rand.x, rand.y, rand.isHorizontal, i))
                    {
                        rand = Randomizer.GenNext();
                    }
                }               
            }
        }
    }
}
