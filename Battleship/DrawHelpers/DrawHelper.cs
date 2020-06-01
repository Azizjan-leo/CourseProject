using Battleship.BaseEntities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Battleship
{
    public class DrawHelper
    {
        private static SpriteBatch _spriteBatch;

        Texture2D _aliveDeck;
        Texture2D _deadDeck; // Dead deck texture
        Texture2D _missShootedCell;

        public Point FC { get; set; } // Field Corner

        public List<Point> MissShots = new List<Point>();

        public DrawHelper(SpriteBatch spriteBatch, Texture2D ship, Texture2D antiShip, Texture2D misShot)
        {
            _spriteBatch = spriteBatch;
            _aliveDeck = ship;
            _deadDeck = antiShip;
            _missShootedCell = misShot;
        }

        public void DrawDeck(Deck deck, (int x, int y) fieldCorner)
        {
            int i = 30;
            var shipTexure = (deck.IsAlive) ? _aliveDeck : _deadDeck;
            _spriteBatch.Draw(shipTexure, new Vector2((fieldCorner.x + deck.X * i) - i, (fieldCorner.y + i * deck.Y) - i), Color.White); 
        }

        public void DrawMissShots()
        {
            foreach (var item in MissShots)
            {
                _spriteBatch.Draw(_missShootedCell, new Vector2(item.X, item.Y), Color.White);
            }
        }
    }
}
