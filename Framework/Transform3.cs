using Microsoft.Xna.Framework;

namespace Hx001.Framework
{
    public struct Transform3
    {
        public Vector3 Position;
        public Vector3 Rotation;

        public override string ToString()
        {
            return $"Px: {Position.X}, Py: {Position.Y}, Pz: {Position.Z}\nRp: {Rotation.X}, Rr: {Rotation.Y}, Ry: {Rotation.Z}";
        }
    }
}