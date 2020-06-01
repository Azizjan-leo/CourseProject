using Battleship.BaseEntities;
using System.Collections.Generic;

namespace Battleship.Engine
{
    public class GamePlay
    {
        Field _cpuField;
        Field _userField;
        List<(int x, int y)> _cpuShots = new List<(int x, int y)>();
        List<(int x, int y)> _userShots = new List<(int x, int y)>();
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

        public void DrawShips(DrawHelper shipHelper)
        {
            _cpuField.DrawShips(shipHelper, true);
            _userField.DrawShips(shipHelper, false);
        }

        public void Shot(int x, int y, DrawHelper shipHelper)
        {
            if ((x > _cpuField.Corner.X && x < _cpuField.Corner.X + 30 * 10) && (y > _cpuField.Corner.Y && y < _cpuField.Corner.Y + 30 * 10)) // Check if the shot hit the field
            {
                int shiftedX = _cpuField.Corner.X;
                int shiftedY = _cpuField.Corner.Y;

                int shift = 30;
                for (int i = 0; i < 10; i++)
                {
                    if (x > shiftedX & x < shiftedX + shift)
                        x = shiftedX;
                    if (y > shiftedY & y < shiftedY + shift)
                        y = shiftedY;
                    shiftedX += shift;
                    shiftedY += shift;
                }
                if (!_userShots.Contains((x, y)))
                {
                    _userShots.Add((x, y));
                    if (!_cpuField.IsShotSuccess(shipHelper, x, y, false)) // If user hit a deck, cpu will not shoot
                    {
                        shipHelper.MissShots.Add(new Microsoft.Xna.Framework.Point(x, y));
                        while (CPUShotSuccess(shipHelper));
                    }
                }                
            }
        }

        public bool CPUShotSuccess(DrawHelper shipHelper)
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
