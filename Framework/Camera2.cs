using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hx001.Framework
{
    /*public class Camera2
    {
        public Transform2 Transform;

        public Matrix View;
        public Matrix Projection;

        public void CreatePers(float fov, float aspectRatio)
        {
            fov = MathHelper.ToRadians(fov);
            Projection = Matrix.CreatePerspectiveFieldOfView(fov, aspectRatio, 0.1f, 1000f);
        }

        public void CreateOrtho(GraphicsDevice graphicsDevice)
        {
            Projection = Matrix.CreateOrthographic(graphicsDevice.Viewport.Width, graphicsDevice.Viewport.Height, 0.1f, 1000f);
        }

        public void Update(GameTime gameTime)
        {
            Matrix RotationMatrixXZ = Matrix.Multiply(Matrix.CreateRotationX(MathHelper.ToRadians(Transform.Rotation.X)), Matrix.CreateRotationZ(MathHelper.ToRadians(Transform.Rotation.Y)));
            Vector3 Target = Vector3.Transform(new Vector3(0, 1, 0), RotationMatrixXZ);

            View = Matrix.CreateLookAt(new Vector3(Transform.Position, 0), Target + new Vector3(Transform.Position,0), new Vector3(0,0,1));
        }
    }*/

    public class Camera2
    {
        public Transform2 Transform;
        public Vector2 Offset;
        public float Scale { get; private set; } = 1f;
        public Matrix Translation;

        private float _addedScale = 0f;

        public void IncreaseScaleBy(float amount)
        {
            Scale += amount;
        }
        
        public void DecreaseScaleBy(float amount)
        {
            if (Scale - amount > 0.0f)
            {
                Scale -= amount;
            }
        }
        
        public void CalculateCenter(GraphicsDevice graphicsDevice)
        {
            Offset = graphicsDevice.Viewport.Bounds.Center.ToVector2();
        }
        
        public void Update(GameTime gameTime)
        {
            //Scale = MathHelper.Lerp(Scale, _addedScale, 0.01f);
            Vector2 target = Offset - Transform.Position * Scale;
            Translation = Matrix.CreateScale(Scale) * Matrix.CreateTranslation(new Vector3(target, 0));
        }
        
    }
}
