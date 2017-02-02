using OpenTK;

namespace GlumEngine2D
{
    public class Vertex
    {
        public Vector2 Position { get; }
        public Vector2 TextureCoordinate { get; }

        public Vertex(float x, float y, float uvX, float uvY) : this(new Vector2(x, y), new Vector2(uvX, uvY)) { }
        public Vertex(Vector2 position, Vector2 textureCoordinate)
        {
            Position = position;
            TextureCoordinate = textureCoordinate;
        }

        public static float[] GetData(Vertex[] vertices)
        {
            int count = 0;
            float[] data = new float[vertices.Length * 4];

            foreach (Vertex vertex in vertices)
            {
                data[count] = vertex.Position.X;
                data[count + 1] = vertex.Position.Y;
                data[count + 2] = vertex.TextureCoordinate.X;
                data[count + 3] = vertex.TextureCoordinate.Y;

                // Incrementing by the amount of elements PER VERTEX!!!
                count += 4;
            }

            return data;
        }
    }
}
