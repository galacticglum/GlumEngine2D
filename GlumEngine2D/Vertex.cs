using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlumEngine2D
{
    public class Vertex
    {
        public const int Size = 2;

        private Vector2 position;
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Vertex(Vector2 position)
        {
            this.position = position;
        }

        public Vertex(float x, float y) : this(new Vector2(x, y)) { }

        public static float[] Process(Vertex[] vertices)
        {
            int count = 0;

            float[] data = new float[vertices.Length * Size];
            for (int i = 0; i < vertices.Length; i++)
            {
                data[count] = vertices[i].Position.X;
                data[count + 1] = vertices[i].Position.Y;

                count += 2;
            }

            return data;
        }
    }
}
