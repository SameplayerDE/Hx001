using System;
using Microsoft.Xna.Framework;

namespace Hx001.Framework.Physics2D
{
    public class Rope : Spring
    {

        public Rope(Particle a, Particle b, float stiffness, float lenght)
        {
            A = a;
            B = b;
            Stiffness = stiffness;
            Lenght = lenght;
        }

        public override void Update(GameTime gameTime)
        {
            Vector2 force = B.Position - A.Position;
            float x = force.Length() - Lenght;
            if (force.Length() <= Lenght)
            {
                return;
            }
            force.Normalize();
            force *= (Stiffness * x);
            A.ApplyForce(force);
            force *= -1;
            B.ApplyForce(force);
            
        }

    }
}