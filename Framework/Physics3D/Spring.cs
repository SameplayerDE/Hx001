using System;
using Microsoft.Xna.Framework;

namespace Hx001.Framework.Physics3D
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
            Vector3 force = B.Position - A.Position;
            float x = force.Length() - Lenght;
            //force.Normalize();
            //force *= (Stiffness * x);
            A.ApplyForce(force);
            force *= -1;
            B.ApplyForce(force);
            //if (Math.Abs(magnitude - Lenght) > 0.01f)
            //{
                
            //}
        }

    }
}