using System;
using Hx001.Framework.Rendering.Meshes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hx001.Framework.Rendering.Renderers
{
    public static class VPCLineRenderer
    {

        public static Color Color = Color.White;

        public static void SetColor(Color color)
        {
            if (Color == color)
            {
                return;
            }
            Color = color;
        }
        
        public static void Render(VPCLineMesh mesh, Effect effect, Matrix world, Matrix view, Matrix projection)
        {
            effect.Parameters["WorldViewProjection"].SetValue(world * view * projection);

            foreach (var pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                try
                {
                    Globals.GraphicsDevice.DrawUserPrimitives(PrimitiveType.LineList, mesh.ToArray(), 0, mesh.ToArray().Length / 2);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
        
        public static void Render(Vector3 from, Vector3 to, Effect effect, Matrix world, Matrix view, Matrix projection)
        {
            effect.Parameters["WorldViewProjection"].SetValue(world * view * projection);

            foreach (var pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                try
                {
                    VertexPositionColor[] mesh = {new VertexPositionColor(from, Color), new VertexPositionColor(to, Color)};
                    Globals.GraphicsDevice.DrawUserPrimitives(PrimitiveType.LineList, mesh, 0, 1);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}