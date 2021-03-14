using Microsoft.Xna.Framework;

namespace Hx001.Framework.Physics
{
    public abstract class HxBody
    {
        
        public string ID { get; protected set; }
        public BodyType Type = BodyType.STATIC;
        
        public abstract void Update(GameTime gameTime);
    }
}