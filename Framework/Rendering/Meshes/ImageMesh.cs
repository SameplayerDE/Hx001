using Hx001.Framework.Rendering.Renderers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hx001.Framework.Rendering.Meshes
{
    public class ImageMesh : VPTQuadMesh
    {
        
        
        public ImageMesh() { }

        public ImageMesh(Texture2D texture, float scale, FlipMode flipMode)
        {
            float x0 = -0.5f, x1 = -0.5f, x2 = 0.50f, x3 = 0.50f;
            float y0 = 0.00f, y1 = 0.00f, y2 = 0.00f, y3 = 0.00f;
            float z0 = -0.5f, z1 = 0.50f, z2 = -0.5f, z3 = 0.50f;

            float uvx0 = 0f, uvx1 = 0f, uvx2 = 1f, uvx3 = 1f;
            float uvy0 = 1f, uvy1 = 0f, uvy2 = 1f, uvy3 = 0f;

            if (flipMode == FlipMode.X || flipMode == FlipMode.Both)
            {
                uvx0 = 1f;
                uvx1 = 1f;
                uvx2 = 0f;
                uvx3 = 0f;
            }
            if (flipMode == FlipMode.Y || flipMode == FlipMode.Both)
            {
                uvy0 = 0f;
                uvy1 = 1f;
                uvy2 = 0f;
                uvy3 = 1f;
            }

            Vector3 v0, v1, v2, v3;
            Vector2 uv0, uv1, uv2, uv3;

            v0 = new Vector3(x0, y0, z0);
            v1 = new Vector3(x1, y1, z1);
            v2 = new Vector3(x2, y2, z2);
            v3 = new Vector3(x3, y3, z3);
            
            uv0 = new Vector2(uvx0, uvy0);
            uv1 = new Vector2(uvx1, uvy1);
            uv2 = new Vector2(uvx2, uvy2);
            uv3 = new Vector2(uvx3, uvy3);
            
            float width = texture.Width * (1 / scale);
            float height = texture.Height * (1 / scale);

            v0.X *= width;
            v0.Z *= height;
            v1.X *= width;
            v1.Z *= height;
            v2.X *= width;
            v2.Z *= height;
            v3.Z *= height;
            v3.X *= width;

            Add(new VPTTrianlgeMesh(v0, v1, v2, uv0, uv1, uv2));
            Add(new VPTTrianlgeMesh(v2, v1, v3, uv2, uv1, uv3));
        }
        
    }
}