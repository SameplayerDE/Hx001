using System;
using Hx001.Framework.Rendering.Meshes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hx001.Framework.Rendering.Renderers
{
    public static class VPTMeshRenderer
    {

        public static void Render(GenericMesh<VertexPositionTexture> mesh, Texture2D texture, Effect effect, Matrix world, Matrix view, Matrix projection)
        {
            effect.Parameters["WorldViewProjection"].SetValue(world * view * projection);

            if (effect.Parameters["Texture"] != null)
            {
                if (texture == null)
                {
                    return;
                }
                effect.Parameters["Texture"].SetValue(texture);
            }
            
            if (mesh.ToArray().Length <= 0)
            {
                return;
            }

            foreach (EffectPass effectPass in effect.CurrentTechnique.Passes)
            {
                effectPass.Apply();
                try
                {
                    Globals.GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, mesh.ToArray(), 0, mesh.ToArray().Length / 3);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

        }

    }
}