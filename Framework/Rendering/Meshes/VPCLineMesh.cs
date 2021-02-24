using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hx001.Framework.Rendering.Meshes
{
    public class VPCLineMesh : GenericMesh<VertexPositionColor>
    {
        public VPCLineMesh(float x0, float y0, float z0, float x1, float y1, float z1, Color color)
        {
            Add(new VertexPositionColor(new Vector3(x0, y0, z0), color));
            Add(new VertexPositionColor(new Vector3(x1, y1, z1), color));
        }
    }
}