using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class ShipHelper
    {
        private static GraphicsDevice _graphicsDevice;
        private static SpriteBatch _spriteBatch;

        public ShipHelper(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
        {
            _graphicsDevice = graphicsDevice;
            _spriteBatch = spriteBatch;
        }

        //public static void DrawRectangle(Rectangle coords, Color color)
        //{
        //    if (rect == null)
        //    {
        //        rect = new Texture2D(_graphicsDevice, 1, 1);
        //        rect.SetData(new[] { Color.White });
        //    }
        //    _spriteBatch.Draw(rect, coords, color);
        //}
    }
}
