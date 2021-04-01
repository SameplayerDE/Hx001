using Microsoft.Xna.Framework;

namespace Hx001.Framework.Components
{
    public class HxCollider2D : HxComponent
    {
        public bool IsTrigger = false;
        public Vector2 Offset = Vector2.Zero;
    }
}