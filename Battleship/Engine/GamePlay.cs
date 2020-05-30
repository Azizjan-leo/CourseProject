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
            _field.Place();
        }
    }
}
