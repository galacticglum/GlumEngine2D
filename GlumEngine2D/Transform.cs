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
        private Vector2 position;
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Matrix4 TransformationMatrix
        {
            get { return Matrix4.CreateTranslation(new Vector3(position.X, position.Y, 0)); }
        }

        public Transform() : this(Vector2.Zero) { }
        public Transform(float x, float y) : this(new Vector2(x, y)) { }
        public Transform(Vector2 position)
        {
            this.position = position;
        }

        public void Translate(float x, float y)
        {
            Translate(new Vector2(x, y));
        }

        public void Translate(Vector2 position)
        {
            this.position += position;
        }
    }
}
