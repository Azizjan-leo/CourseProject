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
        Field _field;

        public GamePlay(int shipNum)
        {
            _field = new Field(shipNum);
          
           
        }

        public void PlaceShips()
        {
            _field.Place();
        }

        public void DrawShips(ShipHelper shipHelper)
        {
            _field.DrawShips(shipHelper);
        }

        public bool Shot(int x, int y, ShipHelper shipHelper)
        {
            return _field.IsShotSuccess(shipHelper, x, y);
        }
    }
}
