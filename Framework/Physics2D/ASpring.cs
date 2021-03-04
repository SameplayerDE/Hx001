using Microsoft.Xna.Framework;

namespace Hx001.Framework.Physics2D
{
    public abstract class ASpring
    {
        public Particle A;
        public Particle B;
        public float Lenght;
        public float Stiffness;

        public abstract void Update(GameTime gameTime);
    }
}