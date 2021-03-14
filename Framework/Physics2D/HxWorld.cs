using System.Collections.Generic;
using Hx001.Framework.Physics;
using Microsoft.Xna.Framework;

namespace Hx001.Framework.Physics2D
{
    public class HxWorld
    {
        public List<HxBody2D> Bodies { get; protected set; }
        public List<HxConstraint2D> Constraints { get; protected set; }

        public HxWorld()
        {
            Bodies = new List<HxBody2D>();
            Constraints = new List<HxConstraint2D>();
        }

        public void AddBody(HxBody2D body)
        {
            Bodies.Add(body);
        }

        public void AddConstraint(HxConstraint2D constraint)
        {
            Constraints.Add(constraint);
        }


        public void Update(GameTime gameTime)
        {
            foreach (HxConstraint2D constraint in Constraints)
            {
                constraint.Update(gameTime);
            }

            foreach (HxBody2D body in Bodies)
            {
                body.Update(gameTime);
            }
        }
    }
}