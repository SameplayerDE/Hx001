using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hx001.Framework
{
    public class Camera3
    {
        public Transform3 Transform;

        public Matrix View;
        public Matrix Projection;

        public void CreatePers(float fov, float aspectRatio)
        {
            fov = MathHelper.ToRadians(fov);
            Projection = Matrix.CreatePerspectiveFieldOfView(fov, aspectRatio, 0.1f, 1000f);
        }

        public void CreateOrtho(float width, float height)
        {
            Projection = Matrix.CreateOrthographic(width, height, 0.1f, 1000f);
        }
        
        public void Update(GameTime gameTime)
        {
            Matrix RotationMatrixXZ = Matrix.Multiply(Matrix.CreateRotationX(MathHelper.ToRadians(Transform.Rotation.X)), Matrix.CreateRotationZ(MathHelper.ToRadians(Transform.Rotation.Z)));
            Vector3 Target = Vector3.Transform(new Vector3(0, 1, 0), RotationMatrixXZ);

            View = Matrix.CreateLookAt(Transform.Position, Vector3.Zero, new Vector3(0, 0, 1));
        }
    }
}