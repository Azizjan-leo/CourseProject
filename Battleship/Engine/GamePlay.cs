using Battleship.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Engine
{
    public class GamePlay
    {
        Field _cpuField;
        Field _userField;

        public GamePlay(int shipNum)
        {
            _cpuField = new Field(38, 138, shipNum);
            _userField = new Field(448, 138, shipNum);
        }

        public void PlaceShips()
        {
            _cpuField.Place();
            _userField.Place();
        }

        public void DrawShips(ShipHelper shipHelper)
        {
            _cpuField.DrawShips(shipHelper);
            _userField.DrawShips(shipHelper);
        }

        public bool Shot(int x, int y, ShipHelper shipHelper)
        {
            return _cpuField.IsShotSuccess(shipHelper, x, y);
        }

        public int[] GetALiveShipsNum()
        {
            int[] ships = new int[] { 0, 0, 0, 0, 0 }; // The first one is for total alive ships number
            foreach (var ship in _cpuField.Ships)
            {
                if (ship.IsAlive)
                {
                    ships[ship.Decks.Count]++;
                    ships[0]++;
                }
            }
            return ships;
        }
    }
}
