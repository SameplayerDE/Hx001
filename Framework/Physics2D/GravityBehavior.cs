using Microsoft.Xna.Framework;

namespace Hx001.Framework.Physics2D
{
    public class GravityBehavior : Behavior
    {
        public Vector2 Gravity = Vector2.Zero;

        public GravityBehavior(float x, float y)
        {
            Gravity.X = x;
            Gravity.Y = y;
        }
        public GravityBehavior(Vector2 gravity) : this(gravity.X, gravity.Y)
        {
            
        }
    }
}