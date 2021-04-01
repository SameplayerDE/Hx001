using System;
using Hx001.Framework.Components;
using Hx001.Framework.Graphics;
using Hx001.Framework.Rendering.Meshes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hx001.Framework.Rendering.Renderers
{

    public enum FlipMode
    {
        None = 0,
        X = 2,
        Y = 1,
        Both = 3
    }
    public enum DrawMode
    {
        Simple = 0,
        Sliced = 1,
        Tiled = 2
    }
    
    public class SpriteRenderer
    {
        //Sprite
        public HxSprite Sprite { get; protected set; }
        //Texture
        public Texture2D Texture { get; protected set; }
        //Tint
        public Color Color { get; protected set; } = Color.White;
        //Flip X Y
        public FlipMode Flip { get; protected set; } = 0;
        //Draw Mode
        public DrawMode DrawMode { get; protected set; } = 0;
        //
        private ImageMesh _mesh;
        private static BasicEffect _effect;

        public SpriteRenderer(HxSprite sprite)
        {
            Sprite = sprite;
        }

        public void SetTexture(Texture2D texture)
        {
            Texture = texture;
            _mesh = new ImageMesh(Texture, 64, Flip);
        }

        public void SetColor(Color color)
        {
            if (Color != color)
            {
                Color = color;
            }
        }

        public void SetFlipMode(FlipMode flipMode)
        {
            if (Flip == flipMode)
            {
                return;
            }
            Flip = flipMode;
            _mesh = new ImageMesh(Texture, 64, Flip);
        }
        
        public void Draw(GraphicsDevice device, HxCamera camera)
        {

            if (_effect == null)
            {
                _effect = new BasicEffect(device);
            }
            
            _effect.Projection = camera.ProjectionMatrix;
            _effect.View = camera.ViewMatrix;
            _effect.World = Matrix.CreateTranslation(Sprite.Get<HxTransform>().Position);
            _effect.TextureEnabled = true;
            _effect.Texture = Texture;
            _effect.DiffuseColor = Color.ToVector3();
            //effect.Parameters["WorldViewProjection"].SetValue(world * view * projection);

            /*if (effect.Parameters["Texture"] != null)
            {
                if (texture == null)
                {
                    return;
                }
                effect.Parameters["Texture"].SetValue(texture);
            }*/
            
            if (_mesh.ToArray().Length <= 0)
            {
                return;
            }

            foreach (EffectPass effectPass in _effect.CurrentTechnique.Passes)
            {
                effectPass.Apply();
                try
                {
                    device.DrawUserPrimitives(PrimitiveType.TriangleList, _mesh.ToArray(), 0, _mesh.ToArray().Length / 3);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}