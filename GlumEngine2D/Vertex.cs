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

        public Vector2 Position { get; set; }

        public Vertex(Vector2 position)
        {
            Position = position;
        }

        public Vertex(float x, float y) : this(new Vector2(x, y)) { }

        public static float[] Process(Vertex[] vertices)
        {
            int count = 0;

            float[] data = new float[vertices.Length * Size];
            foreach (Vertex vertex in vertices)
            {
                data[count] = vertex.Position.X;
                data[count + 1] = vertex.Position.Y;

                count += 2;
            }

            return data;
        }
    }
}
