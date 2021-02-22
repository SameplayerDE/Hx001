using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hx001.Framework.Rendering.Meshes
{
    public class GenericTriangleMesh<T> : GenericMesh<T> where T : IVertexType
    {

        public GenericTriangleMesh() { }

        public GenericTriangleMesh(float x0, float y0, float z0, float x1, float y1, float z1, float x2, float y2, float z2)
        {

        }

        public GenericTriangleMesh(Vector3 v0, Vector3 v1, Vector3 v2) : this(v0.X, v0.Y, v0.Z, v1.X, v1.Y, v1.Z, v2.X, v2.Y, v2.Z)
        {

        }

    }
}