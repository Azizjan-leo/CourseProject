using Microsoft.Xna.Framework;
using System;

namespace TopDownShooter
{
    public class Hero : Basic2D
    {
        public float Speed;

        public Hero(string path, Vector2 pos, Vector2 dims) : base(path, pos, dims)
        {
            Speed = 3;
        }

        public override void Update()
        {
            if(Globals.keyboard.GetPress("A"))
            {
                Pos.X -= Speed; 
            }
            if (Globals.keyboard.GetPress("D"))
            {
                Pos.X += Speed;
            }
            if (Globals.keyboard.GetPress("W"))
            {
                Pos.Y -= Speed;
            }
            if (Globals.keyboard.GetPress("S"))
            {
                Pos.Y += Speed;
            }

            Rotaition = Globals.RotateTowards(Pos, new Vector2(Globals.mouse.newMousePos.X, Globals.mouse.newMousePos.Y)); 
            base.Update();
        }

        public override void Draw(Vector2 offset)
        {
            base.Draw(offset);
        }

       
    }
}
