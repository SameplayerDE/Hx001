using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hx001.Framework.Rendering.Meshes
{
    public class VPTTrianlgeMesh : GenericTriangleMesh<VertexPositionTexture>
    {

        public VPTTrianlgeMesh() { }

        public VPTTrianlgeMesh(float x0, float y0, float z0, float x1, float y1, float z1, float x2, float y2, float z2, float uvx0, float uvy0, float uvx1, float uvy1, float uvx2, float uvy2) : base(x0, y0, z0, x1, y1, z1, x2, y2, z2)
        {
            Add(new VertexPositionTexture(new Vector3(x0, y0, z0), new Vector2(uvx0, uvy0)));
            Add(new VertexPositionTexture(new Vector3(x1, y1, z1), new Vector2(uvx1, uvy1)));
            Add(new VertexPositionTexture(new Vector3(x2, y2, z2), new Vector2(uvx2, uvy2)));
        }

        public VPTTrianlgeMesh(Vector3 v0, Vector3 v1, Vector3 v2, Vector2 uv0, Vector2 uv1, Vector2 uv2) : base(v0, v1, v2)
        {
            Add(new VertexPositionTexture(v0, uv0));
            Add(new VertexPositionTexture(v1, uv1));
            Add(new VertexPositionTexture(v2, uv2));
        }

    }
}