using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hx001.Framework
{
    public class HxScene
    {

        public List<HxObject> Objects { get; private set; } = new List<HxObject>();
        
        public void Add(HxObject @object)
        {
            Objects.Add(@object);
        }
        
        public void Remove(HxObject @object)
        {
            Objects.Remove(@object);
        }
        
        public void Draw(GraphicsDevice graphicsDevice)
        {
            
        }

        public void Update(GameTime gameTime)
        {
            foreach (HxObject hxObject in Objects)
            {
                //
            }
        }
    }
}