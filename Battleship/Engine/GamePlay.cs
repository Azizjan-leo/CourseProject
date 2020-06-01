using Battleship.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Battleship.Engine
{
    public class GamePlay
    {
        Field _cpuField;
        Field _userField;
        List<(int x, int y)> _cpuShots = new List<(int x, int y)>();
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

        public bool UserShotSuccess(int x, int y, ShipHelper shipHelper)
        {
            return _cpuField.IsShotSuccess(shipHelper, x, y, false);
        }

        public void Shot(int x, int y, ShipHelper shipHelper)
        {
            if ((x > _cpuField.Corner.X && x < _cpuField.Corner.X + 30 * 10) && (y > _cpuField.Corner.Y && y < _cpuField.Corner.Y + 30 * 10))
            {
                if(!UserShotSuccess(x, y, shipHelper)) // If user hit a deck, cpu will not shoot
                {
                    SetMissShot(x, y, _cpuField.Corner, shipHelper);
                    while (CPUShotSuccess(shipHelper));
                }
            }
        }
        public void SetMissShot(int x, int y, (int x, int y) fieldCorner, ShipHelper shipHelper)
        {
            int gayx = fieldCorner.x;
            int gayy = fieldCorner.y;
            int shift = 30;
            for (int i = 0; i < 10; i++)
            {
                if (x > gayx & x < gayx + shift)
                    x = gayx;
                if (y > gayy & y < gayy + shift)
                    y = gayy;
                gayx += shift;
                gayy += shift;
            }
            shipHelper.MissShots.Add(new Microsoft.Xna.Framework.Point(x, y));
        }
        public bool CPUShotSuccess(ShipHelper shipHelper)
        {

            (int x, int y) cpuShot;
            do
            {
                cpuShot = Randomizer.GetShot();
            } while (_cpuShots.Contains(cpuShot));
            
            _cpuShots.Add(cpuShot);
            if(!_userField.IsShotSuccess(shipHelper, cpuShot.x, cpuShot.y, true))
            {
                shipHelper.MissShots.Add(new Microsoft.Xna.Framework.Point(
                    (_userField.Corner.X + 30 * cpuShot.x) - 30,
                    (_userField.Corner.Y + 30 * cpuShot.y) - 30
                    ));
                return false;
            }
            return true;
        }

        public int[] GetCpuAliveShipsNum()
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

        internal int[] GetUserAliveShipsNum()
        {
            int[] ships = new int[] { 0, 0, 0, 0, 0 }; // The first one is for total alive ships number
            foreach (var ship in _userField.Ships)
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
