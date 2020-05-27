using Microsoft.Xna.Framework;
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

        Texture2D _ship;

        public ShipHelper(SpriteBatch spriteBatch, Texture2D ship)
        {
            _spriteBatch = spriteBatch;
            _ship = ship;
        }

        public void Draw()
        {
            int x = 448, y = 139;
            int i = 30;

            _spriteBatch.Draw(_ship, new Vector2(x, y), Color.White);
            _spriteBatch.Draw(_ship, new Vector2(x + 4 * i, y+i*3), Color.White);
            _spriteBatch.Draw(_ship, new Vector2(628, 319), Color.White);
            _spriteBatch.Draw(_ship, new Vector2(x+9*i, y+4*i), Color.White);

            _spriteBatch.Draw(_ship, new Vector2(x + 2 * i, y + i), Color.White);
            _spriteBatch.Draw(_ship, new Vector2(x + 3 * i, y + i), Color.White);

            _spriteBatch.Draw(_ship, new Vector2(x + 4 * i, y + i*5), Color.White);
            _spriteBatch.Draw(_ship, new Vector2(x + 4 * i, y + i*6), Color.White);

            _spriteBatch.Draw(_ship, new Vector2(x + i, y + i * 5), Color.White);
            _spriteBatch.Draw(_ship, new Vector2(x + 2 * i, y + i * 5), Color.White);

            _spriteBatch.Draw(_ship, new Vector2(x, y + i * 7), Color.White);
            _spriteBatch.Draw(_ship, new Vector2(x, y + i * 8), Color.White);
            _spriteBatch.Draw(_ship, new Vector2(x, y + i * 9), Color.White);

            _spriteBatch.Draw(_ship, new Vector2(x+i*8, y), Color.White);
            _spriteBatch.Draw(_ship, new Vector2(x+i*9, y), Color.White);
            _spriteBatch.Draw(_ship, new Vector2(x+i*9, y + i), Color.White);

            _spriteBatch.Draw(_ship, new Vector2(x + i * 4, y+i*9), Color.White);
            _spriteBatch.Draw(_ship, new Vector2(x + i * 5, y+i*8), Color.White);
            _spriteBatch.Draw(_ship, new Vector2(x + i * 5, y + i*9), Color.White);
            _spriteBatch.Draw(_ship, new Vector2(x + i * 6, y + i*9), Color.White);
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
