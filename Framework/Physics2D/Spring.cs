using System;
using Microsoft.Xna.Framework;

namespace Hx001.Framework.Physics2D
{
    public class Spring
    {

        public Particle A;
        public Particle B;
        public float Stiffness;
        public float Lenght;

        public Spring(Particle a, Particle b, float stiffness, float lenght)
        {
            A = a;
            B = b;
            Stiffness = stiffness;
            Lenght = lenght;
        }

        public void Update(GameTime gameTime)
        {
            Vector2 force = B.Position - A.Position;
            float magnitude = force.Length();
            if (Math.Abs(magnitude - Lenght) > 0.01f)
            {
                force.Normalize();
                force *= (Stiffness * magnitude);
                A.ApplyForce(force);
                force *= -1;
                B.ApplyForce(force);
            }
        }

    }
}