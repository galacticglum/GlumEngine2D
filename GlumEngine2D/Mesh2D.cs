using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL4;

namespace GlumEngine2D
{
    public class Mesh2D
    {
        private int vboID;
        private int size;

        public Mesh2D(Vertex[] vertices)
        {
            vboID = GL.GenBuffer();
            size = vertices.Length;

            float[] data = Vertex.Process(vertices);

            GL.BindBuffer(BufferTarget.ArrayBuffer, vboID);
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(data.Length * sizeof(float)), data, BufferUsageHint.StaticDraw);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }

        public void Draw()
        {
            GL.EnableVertexAttribArray(0);

            GL.BindBuffer(BufferTarget.ArrayBuffer, vboID);
            GL.VertexAttribPointer(0, Vertex.Size, VertexAttribPointerType.Float, false, Vertex.Size * 4, 0);
            GL.DrawArrays(PrimitiveType.Triangles, 0, size);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

            GL.DisableVertexAttribArray(0);
        }
    }
}
