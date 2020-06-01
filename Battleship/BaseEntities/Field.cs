using Battleship.Engine;
using System.Collections.Generic;

namespace Battleship.BaseEntities
{
    public class Field
    {
        public (int X, int Y) Corner; // Top-Left corner's coordinates
        public List<Ship> Ships { get; set; }

        
        public Field(int x, int y, int shipNum)
        {
            Corner = (x, y);
            Ships = new List<Ship>(shipNum);
        }

        public bool AddShip(int x, int y, bool isHorizontal, int deckNum)
        {

            if (deckNum > 1 && ((isHorizontal && x + deckNum > 10) || (!isHorizontal && y + deckNum > 10))) // A ship should not stick out the field
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

            Ships.Add(new Ship(Corner, deckNum, x, y, isHorizontal));
            return true;
        }

        public void Place()
        {
            for (int i = 4; i > 0; i--)
            {
                for (int j = i; j < 5; j++)
                {
                    var rand = Randomizer.GenNextShip();
                    while (!AddShip(rand.x, rand.y, rand.isHorizontal, i))
                    {
                        rand = Randomizer.GenNextShip();
                    }
                }               
            }
        }

        public void DrawShips(DrawHelper shipHelper, bool hideAlive)
        {
            foreach (var ship in Ships)
            {
                foreach (var deck in ship.Decks)
                {
                    if (deck.IsAlive && hideAlive)
                        continue;
                    shipHelper.DrawDeck(deck, Corner);
                }
            }
        }

        public bool IsShotSuccess(DrawHelper shipHelper, int x, int y, bool isCPUShot)
        {
            foreach (var ship in Ships)
            {
                foreach (var deck in ship.Decks)
                {
                    if (deck.IsAlive && isCPUShot && deck.X == x && deck.Y == y)
                    {
                        deck.IsAlive = false;
                        return true;
                    }    
                    if (IsShotSuccess(deck, x, y))
                        return true;
                }
            }
            return false;
        }

        public bool IsShotSuccess(Deck deck, int x, int y)
        {
            int i = 30;
            if (x == deck.XPix  && y == deck.YPix)
            {
                deck.IsAlive = false;
                return true;
            }
            return false;
        }
    }
}
