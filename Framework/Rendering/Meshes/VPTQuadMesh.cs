using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hx001.Framework.Rendering.Meshes
{
public class VPTQuadMesh : GenericQuadMesh<VertexPositionTexture>
    {

        public VPTQuadMesh() { }

        public VPTQuadMesh(float x0, float y0, float z0, float x1, float y1, float z1, float x2, float y2, float z2, float x3, float y3, float z3, float uvx0, float uvy0, float uvx1, float uvy1, float uvx2, float uvy2, float uvx3, float uvy3) : base(x0, y0, z0, x1, y1, z1, x2, y2, z2, x3, y3, z3)
        {
            Add(new VPTTrianlgeMesh(x0, y0, z0, x1, y1, z1, x2, y2, z2, uvx0, uvy0, uvx1, uvy1, uvx2, uvy2));
            Add(new VPTTrianlgeMesh(x2, y2, z2, x1, y1, z1, x3, y3, z3, uvx2, uvy2, uvx1, uvy1, uvx3, uvy3));
        }

        public VPTQuadMesh(Vector3 v0, Vector3 v1, Vector3 v2, Vector3 v3, Vector2 uv0, Vector2 uv1, Vector2 uv2, Vector2 uv3) : base(v0, v1, v2, v3)
        {
            Add(new VPTTrianlgeMesh(v0, v1, v2, uv0, uv1, uv2));
            Add(new VPTTrianlgeMesh(v2, v1, v3, uv2, uv1, uv3));
        }

        /*public TextureQuadMesh(float sx, float sy, float sz, Facing facing)
        {
            Vector3 ooo = Vector3.Zero;

            Vector3 ioo = Vector3.UnitX * sx;
            Vector3 oio = Vector3.UnitY * sy;
            Vector3 iio = ioo + oio;
            Vector3 ooi = Vector3.UnitZ * sz;
            Vector3 ioi = ioo + ooi;
            Vector3 oii = oio + ooi;
            Vector3 iii = iio + ooi;


            if (facing.ID == Facing.South.ID)
            {
                Add(new VPTTrianlgeMesh(ooo, ooi, ioo, new Vector2(0, 1), new Vector2(0, 0), new Vector2(1, 1)));
                Add(new VPTTrianlgeMesh(ioo, ooi, ioi, new Vector2(1, 1), new Vector2(0, 0), new Vector2(1, 0)));
            }

            if (facing.ID == Facing.North.ID)
            {
                Add(new VPTTrianlgeMesh(ioo, ioi, ooo, new Vector2(0, 1), new Vector2(0, 0), new Vector2(1, 1)));
                Add(new VPTTrianlgeMesh(ooo, ioi, ooi, new Vector2(1, 1), new Vector2(0, 0), new Vector2(1, 0)));
            }
            if (facing.ID == Facing.East.ID)
            {
                Add(new VPTTrianlgeMesh(ooo, ooi, oio, new Vector2(0, 1), new Vector2(0, 0), new Vector2(1, 1)));
                Add(new VPTTrianlgeMesh(oio, ooi, oii, new Vector2(1, 1), new Vector2(0, 0), new Vector2(1, 0)));
            }
            if (facing.ID == Facing.West.ID)
            {
                Add(new VPTTrianlgeMesh(oio, oii, ooo, new Vector2(0, 1), new Vector2(0, 0), new Vector2(1, 1)));
                Add(new VPTTrianlgeMesh(ooo, oii, ooi, new Vector2(1, 1), new Vector2(0, 0), new Vector2(1, 0)));
            }
            if (facing.ID == Facing.Up.ID)
            {
                Add(new VPTTrianlgeMesh(ooo, oio, ioo, new Vector2(0, 1), new Vector2(0, 0), new Vector2(1, 1)));
                Add(new VPTTrianlgeMesh(ioo, oio, iio, new Vector2(1, 1), new Vector2(0, 0), new Vector2(1, 0)));
            }
            if (facing.ID == Facing.Down.ID)
            {
                Add(new VPTTrianlgeMesh(oio, ooo, iio, new Vector2(0, 1), new Vector2(0, 0), new Vector2(1, 1)));
                Add(new VPTTrianlgeMesh(iio, ooo, ioo, new Vector2(1, 1), new Vector2(0, 0), new Vector2(1, 0)));
            }
        }

        public TextureQuadMesh(float xo, float yo, float zo, float sx, float sy, float sz, Facing facing)
        {
            Vector3 ooo = new Vector3(xo, yo, zo);
            //Vector3 ooo = new Vector3(xo, yo, zo);

            Vector3 ioo = new Vector3(sx, 0, 0);
            Vector3 oio = new Vector3(0, sy, 0);
            Vector3 iio = ioo + oio;
            Vector3 ooi = new Vector3(0, 0, sz);
            Vector3 ioi = ioo + ooi;
            Vector3 oii = oio + ooi;
            Vector3 iii = iio + ooi;

            ioo += ooo;
            oio += ooo;
            ooi += ooo;
            ioi += ooo;
            iio += ooo;
            oii += ooo;
            iii += ooo;


            if (facing.ID == Facing.South.ID)
            {
                Add(new VPTTrianlgeMesh(ooo, ooi, ioo, new Vector2(0, 1), new Vector2(0, 0), new Vector2(1, 1)));
                Add(new VPTTrianlgeMesh(ioo, ooi, ioi, new Vector2(1, 1), new Vector2(0, 0), new Vector2(1, 0)));
            }

            if (facing.ID == Facing.North.ID)
            {
                Add(new VPTTrianlgeMesh(ioo, ioi, ooo, new Vector2(0, 1), new Vector2(0, 0), new Vector2(1, 1)));
                Add(new VPTTrianlgeMesh(ooo, ioi, ooi, new Vector2(1, 1), new Vector2(0, 0), new Vector2(1, 0)));
            }
            if (facing.ID == Facing.East.ID)
            {
                Add(new VPTTrianlgeMesh(ooo, ooi, oio, new Vector2(0, 1), new Vector2(0, 0), new Vector2(1, 1)));
                Add(new VPTTrianlgeMesh(oio, ooi, oii, new Vector2(1, 1), new Vector2(0, 0), new Vector2(1, 0)));
            }
            if (facing.ID == Facing.West.ID)
            {
                Add(new VPTTrianlgeMesh(oio, oii, ooo, new Vector2(0, 1), new Vector2(0, 0), new Vector2(1, 1)));
                Add(new VPTTrianlgeMesh(ooo, oii, ooi, new Vector2(1, 1), new Vector2(0, 0), new Vector2(1, 0)));
            }
            if (facing.ID == Facing.Up.ID)
            {
                Add(new VPTTrianlgeMesh(ooo, oio, ioo, new Vector2(0, 1), new Vector2(0, 0), new Vector2(1, 1)));
                Add(new VPTTrianlgeMesh(ioo, oio, iio, new Vector2(1, 1), new Vector2(0, 0), new Vector2(1, 0)));
            }
            if (facing.ID == Facing.Down.ID)
            {
                Add(new VPTTrianlgeMesh(oio, ooo, iio, new Vector2(0, 1), new Vector2(0, 0), new Vector2(1, 1)));
                Add(new VPTTrianlgeMesh(iio, ooo, ioo, new Vector2(1, 1), new Vector2(0, 0), new Vector2(1, 0)));
            }
        }*/

    }
}