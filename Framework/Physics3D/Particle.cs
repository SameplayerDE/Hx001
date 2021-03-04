using Microsoft.Xna.Framework;

namespace Hx001.Framework.Physics3D
{
    public class Particle
    {
        public Vector3 Acceleration;
        public Vector3 Velocity;
        public Vector3 Position;
        public bool IsLocked = false;

        public Particle(float x, float y, float z)
        {
            Position.X = x;
            Position.Y = y;
            Position.Z = z;
        }

        public Particle(Vector3 position) : this(position.X, position.Y, position.Z)
        {
          //  
        }

        public void ApplyForce(Vector3 force)
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
            Velocity *= 0.98f; // reduce Velocity
            Acceleration.X = 0; // reset Acc
            Acceleration.Y = 0; // reset Acc
            Acceleration.Z = 0; // reset Acc
        }
    }
}