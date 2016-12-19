using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlumEngine2D
{
    public class Transform
    {
        public Vector2 Position { get; set; }
        public float Rotation { get; set; }
        public Vector2 LocalScale { get; set; }
        public Matrix4 TransformationMatrix => CalculateTransformationMatrix();

        public Transform() : this(Vector2.Zero, 0f, Vector2.One) { }
        public Transform(float x, float y) : this(new Vector2(x, y), 0f, Vector2.One) { }
        public Transform(float x, float y, float rotation) : this(new Vector2(x, y), rotation, Vector2.One) { }
        public Transform(float x, float y, float rotation, float scaleX, float scaleY) : this(new Vector2(x, y), rotation, new Vector2(scaleX, scaleY)) { }
        public Transform(Vector2 position, float rotation, Vector2 localScale)
        {
            Position = position;
            Rotation = rotation;
            LocalScale = localScale;
        }

        public void Translate(float translationFactor)
        {
            Translate(translationFactor, translationFactor);
        }

        public void Translate(float x, float y)
        {
            Translate(new Vector2(x, y));
        }

        public void Translate(Vector2 position)
        {
            Position += position;
        }

        public void Rotate(float rotation)
        {
            Rotation += rotation;
        }

        public void Scale(float scaleFactor)
        {
            Scale(scaleFactor, scaleFactor);
        }

        public void Scale(float x, float y)
        {
            Scale(new Vector2(x, y));
        }

        public void Scale(Vector2 scaleFactor)
        {
            LocalScale += scaleFactor;
        }

        private Matrix4 CalculateTransformationMatrix()
        {
            Matrix4 translation = Matrix4.CreateTranslation(new Vector3(Position.X, Position.Y, 0));
            Matrix4 rotation = Matrix4.CreateFromQuaternion(Quaternion.FromEulerAngles(Rotation, 0, 0));
            Matrix4 scale = Matrix4.CreateScale(new Vector3(LocalScale.X, LocalScale.Y, 1));

            Matrix4 transformationMatrix = translation * (rotation * scale);
            return transformationMatrix;
        }
    }
}
