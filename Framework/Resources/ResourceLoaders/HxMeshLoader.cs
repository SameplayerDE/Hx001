using System.Collections.Generic;

namespace Hx001.Framework.Resources.ResourceLoaders
{

    public struct HxFileVertexPosition
    {
        public int ID;
        public float X;
        public float Y;
        public float Z;

        public HxFileVertexPosition(int id, float x, float y, float z)
        {
            ID = id;
            X = x;
            Y = y;
            Z = z;
        }
    }
    
    public struct HxFileVertexNormals
    {
        public int ID;
        public float X;
        public float Y;
        public float Z;

        public HxFileVertexNormals(int id, float x, float y, float z)
        {
            ID = id;
            X = x;
            Y = y;
            Z = z;
        }
    }
    
    public struct HxFileVertexTexture
    {
        public int ID;
        public float U;
        public float V;

        public HxFileVertexTexture(int id, float u, float v)
        {
            ID = id;
            U = u;
            V = v;
        }
    }
    
    public static class HxMeshLoader
    {
        public static void Load()
        {
            List<HxFileVertexPosition> positions = new List<HxFileVertexPosition>();
            List<HxFileVertexNormals> normals = new List<HxFileVertexNormals>();
            List<HxFileVertexTexture> textures = new List<HxFileVertexTexture>();
            
            
            
        }
    }
}