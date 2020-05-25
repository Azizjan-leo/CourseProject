using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TopDownShooter
{
    public class Basic2D
    {
        public float Rotaition;

        public Vector2 Pos, Dims;

        public Texture2D Model;

        public Basic2D(string path, Vector2 pos, Vector2 dims)
        {
            Pos = pos;
            Dims = dims;
            Model = Globals.content.Load<Texture2D>(path);
        }

        public virtual void Update()
        {

        }

        public virtual void Draw(Vector2 offset)
        {
            if(Model != null)
            {
                Globals.spriteBatch.Draw(Model, new Rectangle((int)(Pos.X + offset.X), (int)(Pos.Y + offset.Y), (int)Dims.X, (int)Dims.Y), null, Color.White, Rotaition, new Vector2(Model.Bounds.Width / 2, Model.Bounds.Height / 2), new SpriteEffects(), 0);
            }
        }

        public virtual void Draw(Vector2 offset, Vector2 origin)
        {
            if (Model != null)
            {
                Globals.spriteBatch.Draw(Model, new Rectangle((int)(Pos.X + offset.X), (int)(Pos.Y + offset.Y), (int)Dims.X, (int)Dims.Y), null, Color.White, Rotaition, new Vector2(origin.X, origin.Y), new SpriteEffects(), 0);
            }
        }
    }
}