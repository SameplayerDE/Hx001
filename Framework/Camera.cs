using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hx001.Framework
{
    public class Camera// : ITransformable
    {

        // Kamera spezifische Werte
        public float FieldOfView = 70f;    // Grad
        public float NearPlane = 0.01f; // kleinste Sichtbarkeitsentfernung
        public float FarPlane = 100f; // größte Sichtbarkeitsentfernung

        // Position
        public float X { get; set; } = 0;
        public float Y { get; set; } = 0;
        public float Z { get; set; } = 0;
        public Vector3 Position { get { return new Vector3(X, Y, Z); } }

        // Rotation
        public float Pitch { get; set; } = 0;// X
        public float Roll { get; set; } = 0;// Y
        public float Yaw { get; set; } = 0;// Z
        public Vector3 Rotation { get { return new Vector3(Pitch, Roll, Yaw); } }

        // Richtung
        public float DX { get; set; } = 0;
        public float DY { get; set; } = 0;
        public float DZ { get; set; } = 0;
        public Vector3 Direction { get { return new Vector3(DX, DY, DZ); } }

        // ? -> In eigene Datei auslagern
        public Vector3 Up = new Vector3(0, 0, 1);
        public Vector3 Down = new Vector3(0, 0, -1);
        public Vector3 Left = new Vector3(-1, 0, 0);
        public Vector3 Right = new Vector3(1, 0, 0);
        public Vector3 Forward = new Vector3(0, 1, 0);
        public Vector3 Backward = new Vector3(0, -1, 0);

        // ?
        public Matrix View;
        public Matrix Projection;

        // ?
        public Ray Ray;
        public BoundingBox BoundingBox = new BoundingBox();

        // Leerer Konstruktor
        public Camera() { }

        // erstelle Projektionsmatrix
        public void Init(GraphicsDevice graphicsDevice)
        {
            Projection = Matrix.CreatePerspectiveFieldOfView
                (
                MathHelper.ToRadians(FieldOfView),
                graphicsDevice.Viewport.AspectRatio,
                NearPlane,
                FarPlane
                );
        }


        // setzt Kamerablickrichtung auf x,y,z
        //public void doSomething(float x, float y, float z) {}

        // setzt Kamerarotation auf x Grad 
        public void RotateTo(float pitch, float roll, float yaw)
        {
            Pitch = pitch;
            Roll = roll;
            Yaw = yaw;

            CheckRotation();
        }

        // rotiere die Kamera um x Grad
        public void RotateBy(float pitch, float roll, float yaw)
        {
            Pitch += pitch;
            Roll += roll;
            Yaw += yaw;

            CheckRotation();
        }

        public void RotateBy(float pitch, float roll, float yaw, float delta)
        {
            RotateBy(pitch * delta, roll * delta, yaw * delta);
        }

        public void RotateBy(float pitch, float roll, float yaw, double delta)
        {
            RotateBy(pitch, roll, yaw, (float)delta);
        }

        // behebt Rotationsfehler
        private void CheckRotation()
        {
            if (Yaw > 360)
            {
                Yaw -= 360;
            }
            if (Yaw < 0)
            {
                Yaw += 360;
            }

            if (Roll > 360)
            {
                Roll -= 360;
            }
            if (Roll < 0)
            {
                Roll += 360;
            }

            Pitch = Math.Clamp(Pitch, -89.9f, 89.9f);
        }

        // setzt die Kameraposition
        public void MoveTo(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        // bewegt die Kamera um x Einheiten
        public void MoveBy(float x, float y, float z)
        {
            X += x;
            Y += y;
            Z += z;
        }

        public void MoveBy(float x, float y, float z, float delta)
        {
            MoveBy(x * delta, y * delta, z * delta);
        }

        public void MoveBy(float x, float y, float z, double delta)
        {
            MoveBy(x, y, z, (float)delta);
        }

        public void MoveRelativeBy(float x, float y, float z)
        {
            Vector3 destination = new Vector3(x, y, z);
            destination = Vector3.Transform(destination, Matrix.CreateRotationZ(MathHelper.ToRadians(Yaw)));
            x = destination.X;
            y = destination.Y;
            z = destination.Z;
            MoveBy(x, y, z);
        }

        public void MoveRelativeBy(float x, float y, float z, float delta)
        {
            MoveRelativeBy(x * delta, y * delta, z * delta);
        }

        public void MoveRelativeBy(float x, float y, float z, double delta)
        {
            MoveRelativeBy(x, y, z, (float)delta);
        }

        // aktuallisiere Werte
        public void Update(GameTime gameTime)
        {
            Matrix RotationMatrixXZ = Matrix.Multiply(Matrix.CreateRotationX(MathHelper.ToRadians(Rotation.X)), Matrix.CreateRotationZ(MathHelper.ToRadians(Rotation.Z)));
            Vector3 Target = Vector3.Transform(Forward, RotationMatrixXZ);

            DX = Target.X;
            DY = Target.Y;
            DZ = Target.Z;

            Ray.Direction = Target;
            Ray.Position = Position;

            BoundingBox.Min = Position - new Vector3(.25f, .25f, .25f);
            BoundingBox.Max = Position + new Vector3(.25f, .25f, .25f);
            View = Matrix.CreateLookAt(Position, Target + Position, Up);
        }

    }
}
