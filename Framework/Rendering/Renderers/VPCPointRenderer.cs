using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hx001.Framework.Rendering.Renderers
{
    public static class VPCPointRenderer
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
        
        public static void Render(Vector3 position, Effect effect, Matrix world, Matrix view, Matrix projection)
        {
            effect.Parameters["WorldViewProjection"].SetValue(world * view * projection);

            /*foreach (var pass in effect.CurrentTechnique.Passes)
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
            }*/
        }
    }
}