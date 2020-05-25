using Microsoft.Xna.Framework;

namespace TopDownShooter.Source
{
    public class World
    {
        public Hero Hero;

        public World()
        {
            Hero = new Hero("2D\\Hero", new Vector2(300, 300), new Vector2(48, 48));
        }

        public virtual void Update()
        {
            Hero.Update();
        }

        public virtual void Draw(Vector2 offset)
        {
            Hero.Draw(offset);
        }
    }
}
