using Microsoft.Xna.Framework;

namespace Hx001.Framework.Physics3D
{
    public class GravityBehavior : Behavior
    {
        public Vector3 Gravity = Vector3.Zero;

        public GravityBehavior(float x, float y, float z)
        {
            Gravity.X = x;
            Gravity.Y = y;
            Gravity.Z = z;
        }
        public GravityBehavior(Vector3 gravity) : this(gravity.X, gravity.Y, gravity.Z)
        {
            
        }
    }
}