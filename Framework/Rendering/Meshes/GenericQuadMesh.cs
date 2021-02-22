using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hx001.Framework.Rendering.Meshes
{
    public class GenericQuadMesh<T> : GenericMesh<T> where T : IVertexType
    {

        public GenericQuadMesh() { }

        public GenericQuadMesh(float x0, float y0, float z0, float x1, float y1, float z1, float x2, float y2, float z2, float x3, float y3, float z3)
        {

        }

        public GenericQuadMesh(Vector3 v0, Vector3 v1, Vector3 v2, Vector3 v3)
        {

        }

    }
}