using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Battleship
{
    public static class DrawField
    {
        private static Texture2D _texture;
        private static Texture2D rect;

        private static GraphicsDevice _graphicsDevice;
        private static SpriteBatch _spriteBatch;

        private static SpriteFont _gameFont;

        // Window size
        private static int _height, _width;

        public static void Init(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch, SpriteFont gameFont, SpriteFont axisFont)
        {
            _graphicsDevice = graphicsDevice;
            _spriteBatch = spriteBatch;
            _gameFont = gameFont;
            _height = _graphicsDevice.Viewport.Height;
            _width = _graphicsDevice.Viewport.Width;
    }
        public static void DrawRectangle(Rectangle coords, Color color)
        {
            if (rect == null)
            {
                rect = new Texture2D(_graphicsDevice, 1, 1);
                rect.SetData(new[] { Color.White });
            }
            _spriteBatch.Draw(rect, coords, color);
        }

        private static Texture2D GetTexture()
        {
            if (_texture == null)
            {
                _texture = new Texture2D(_spriteBatch.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
                _texture.SetData(new[] { Color.White });
            }

            return _texture;
        }

        public static void DrawLine(Vector2 point1, Vector2 point2, Color color, float thickness = 1f)
        {
            var distance = Vector2.Distance(point1, point2);
            var angle = (float)Math.Atan2(point2.Y - point1.Y, point2.X - point1.X);
            DrawLine(point1, distance, angle, color, thickness);
        }

        public static void DrawLine(Vector2 point, float length, float angle, Color color, float thickness = 1f)
        {
            var origin = new Vector2(0f, 0.5f);
            var scale = new Vector2(length, thickness);
            _spriteBatch.Draw(GetTexture(), point, null, color, angle, origin, scale, SpriteEffects.None, 0);
        }

        internal static void Draw()
        {
            // Vertical opponents devider
            DrawLine(new Vector2(_width/2, 0), new Vector2(_width/2, _height), Color.White);

            // Horizontal 
            DrawLine(new Vector2(0, 100), new Vector2(_width, 100), Color.White);

            // Draw computer's field borders
           // DrawField.DrawRectangle(new Rectangle((int)40, (int)140, 320, 320), Color.Transparent);
            // Draw player's field borders
            //DrawField.DrawRectangle(new Rectangle((int)450, (int)140, 320, 320), Color.Transparent);

            for (int i = 1; i < 12; i++)
            {
                // Vertical 
                DrawLine(new Vector2(30 * i + 10, 140), new Vector2(30 * i + 10, 440), Color.White);
                // Horizontal 
                DrawLine(new Vector2(40, i * 30 + 110), new Vector2(340, i * 30 + 110), Color.White);

                // Vertical 
                DrawLine(new Vector2(30 * i + 420, 140), new Vector2(30 * i + 420, 440), Color.White);
                // Horizontal 
                DrawLine(new Vector2(450, 110 + i * 30), new Vector2(750, 110 + i * 30), Color.White);
            }

            Write();
        }

        public static void Write()
        {
            _spriteBatch.DrawString(_gameFont, "CPU", new Vector2(0, 000), Color.White);
            _spriteBatch.DrawString(_gameFont, "YOU", new Vector2(_width/2, 000), Color.White);

            for (int i = 1; i < 11; i++)
            {
                _spriteBatch.DrawString(_gameFont, string.Format("{0,2:##}", i), new Vector2(5, 107 + i * 30), Color.White);
                _spriteBatch.DrawString(_gameFont, string.Format("{0,2:##}", GetColumnName(i)), new Vector2(30 * i + 6, 107), Color.White);


                _spriteBatch.DrawString(_gameFont, string.Format("{0,2:##}", i), new Vector2(415, 107 + i * 30), Color.White);                
                _spriteBatch.DrawString(_gameFont, string.Format("{0,2:##}", GetColumnName(i)), new Vector2(30 * i + 415, 107), Color.White);
            }
        }

        static string GetColumnName(int index)
        {
            const string letters = "0ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            var value = "";

            if (index >= letters.Length)
                value += letters[index / letters.Length - 1];

            value += letters[index % letters.Length];

            return value;
        }

    }
}
