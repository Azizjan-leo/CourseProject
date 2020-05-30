using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.BaseEntities
{
    public class Ship
    {
        public bool IsAlive 
        {
            get
            {
                foreach (var item in Decks)
                {
                    if (item.IsAlive)
                        return true;
                }
                return false; // If we got that far, there was no alive deck in this ship
            }
            set{ }
        }

        public List<Deck> Decks = new List<Deck>();

        public Ship(int deckNum, int x, int y, bool isHorizontal)
        {
            int xShift = isHorizontal ? 1 : 0;
            int yShift = isHorizontal ? 0 : 1;

            for (int i = 0; i < deckNum; i++)
            {
                Decks.Add(new Deck(x, y, true));
                x += xShift;
                y += yShift;
            }
        }

        public bool IsFree(int x, int y)
        {   
            foreach (var deck in Decks)
            {
                if (deck.X == x && deck.Y == y)
                    return false;
                if ((deck.X + 1 == x || deck.X - 1 == x) && deck.Y == y) // You can't place a new ship back to back to existing one
                    return false;
                if ((deck.Y + 1 == y || deck.Y - 1 == y) && deck.X == x) // You can't place a new ship back to back to existing one
                    return false;
            }
            return true;
        }
    }
}
