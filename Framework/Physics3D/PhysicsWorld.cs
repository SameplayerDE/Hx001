using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Hx001.Framework.Physics3D
{
    public class PhysicsWorld
    {

        private List<Particle> _particles = new List<Particle>();
        private List<Spring> _springs = new List<Spring>();
        private List<Behavior> _behaviors = new List<Behavior>();
        
        public void Add(Particle particle)
        {
            _particles.Add(particle);
        }
        
        public void Add(Spring spring)
        {
            _springs.Add(spring);
        }
        
        public void Add(Behavior behavior)
        {
            _behaviors.Add(behavior);
        }

        public void Update(GameTime gameTime)
        {
            foreach (var spring in _springs)
            {
                spring.Update(gameTime);
            }
            foreach (var particle in _particles)
            {
                foreach (var behavior in _behaviors)
                {
                    if (behavior is GravityBehavior)
                    {
                        GravityBehavior gravityBehavior = behavior as GravityBehavior;
                        particle.ApplyForce(gravityBehavior.Gravity);
                    }
                }
                particle.Update(gameTime);
            }
        }
    }
}