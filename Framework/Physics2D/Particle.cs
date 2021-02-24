using Microsoft.Xna.Framework;

namespace Hx001.Framework.Physics2D
{
    public class Particle
    {
        public Vector2 Acceleration;
        public Vector2 Velocity;
        public Vector2 Position;
        public bool IsLocked = false;

        public Particle(float x, float y)
        {
            Position.X = x;
            Position.Y = y;
        }

        public Particle(Vector2 position) : this(position.X, position.Y)
        {
          //  
        }

        public void ApplyForce(Vector2 force)
        {
            Acceleration += force;
        }
        
        public void Update(GameTime gameTime)
        {
            if (IsLocked)
            {
                return;
            }

            Velocity += Acceleration;
            Position += Velocity;
            Velocity *= 0.99f; // reduce Velocity
            Acceleration.X = 0; // reset Acc
            Acceleration.Y = 0; // reset Acc
        }
    }
}