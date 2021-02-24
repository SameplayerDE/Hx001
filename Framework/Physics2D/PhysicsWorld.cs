using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Hx001.Framework.Physics2D
{
    public class PhysicsWorld
    {

        private List<Particle> _particles = new List<Particle>();
        private List<Spring> _springs = new List<Spring>();
        
        public void Add(Particle particle)
        {
            _particles.Add(particle);
        }
        
        public void Add(Spring spring)
        {
            _springs.Add(spring);
        }

        public void Update(GameTime gameTime)
        {
            foreach (var spring in _springs)
            {
                spring.Update(gameTime);
            }
            foreach (var particle in _particles)
            {
                particle.Update(gameTime);
            }
        }
    }
}