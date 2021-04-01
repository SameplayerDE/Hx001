using Hx001.Framework.Components;
using Hx001.Framework.Rendering.Renderers;

namespace Hx001.Framework.Graphics
{
    public class HxSprite : HxGameObject
    {
        //Renderer
        public SpriteRenderer SpriteRenderer;

        public HxSprite()
        {
            Attach(new HxTransform());
            SpriteRenderer = new SpriteRenderer(this);
        }
    }
}