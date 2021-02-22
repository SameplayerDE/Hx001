using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace Hx001.Framework.Rendering.Meshes
{
    public class GenericMesh<T> where T : IVertexType
    {

        private List<T> _data = new List<T>();
        private bool _ready = false;

        public List<T> Data { get { return _data; } }
        public int TriangleCount { get { return _data.Count / 3; } }

        public void Clear()
        {
            _data.Clear();
        }

        public void Add(T data)
        {
            _data.Add(data);
        }

        public void Add(GenericMesh<T> mesh)
        {
            _data.AddRange(mesh.Data);
        }

        public T[] ToArray()
        {
            return _data.ToArray();
        }

    }
}