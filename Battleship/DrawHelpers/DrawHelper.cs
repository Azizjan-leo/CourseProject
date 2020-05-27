using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Battleship.DrawHelpers
{
    public class DrawHelper
    {
        private static Texture2D _texture;

        private static GraphicsDevice _graphicsDevice;
        private static SpriteBatch _spriteBatch;

        public DrawHelper(SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;
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
        public void DrawLine(Vector2 point1, Vector2 point2, Color color, float thickness = 1f)
        {
            var distance = Vector2.Distance(point1, point2);
            var angle = (float)Math.Atan2(point2.Y - point1.Y, point2.X - point1.X);
            DrawLine(point1, distance, angle, color, thickness);
        }

        public void DrawLine(Vector2 point, float length, float angle, Color color, float thickness = 1f)
        {
            var origin = new Vector2(0f, 0.5f);
            var scale = new Vector2(length, thickness);
            _spriteBatch.Draw(GetTexture(), point, null, color, angle, origin, scale, SpriteEffects.None, 0);
        }
    }
}
