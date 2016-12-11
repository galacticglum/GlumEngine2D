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
        public Matrix4 TransformationMatrix => CalculateTransformationMatrix();

        public Transform() : this(Vector2.Zero) { }
        public Transform(float x, float y) : this(new Vector2(x, y)) { }
        public Transform(Vector2 position)
        {
            Position = position;
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

        private Matrix4 CalculateTransformationMatrix()
        {
            Matrix4 translation = Matrix4.CreateTranslation(new Vector3(Position.X, Position.Y, 0));
            Matrix4 rotation = Matrix4.CreateFromQuaternion(Quaternion.FromEulerAngles(Rotation, 0, 0));

            Matrix4 transformationMatrix = Matrix4.Mult(rotation, translation);
            return transformationMatrix;
        }
    }
}
