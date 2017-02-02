using System;
using OpenTK.Graphics.OpenGL4;

namespace GlumEngine2D
{
    public class Mesh2D
    {
        private readonly int vboID;
        private readonly int iboID;
        private readonly int size;

        public Mesh2D(Vertex[] vertices, int[] indices)
        {
            vboID = GL.GenBuffer();
            iboID = GL.GenBuffer();
            size = indices.Length;

            float[] data = Vertex.GetData(vertices);
            GL.BindBuffer(BufferTarget.ArrayBuffer, vboID);
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(data.Length * sizeof(float)), data, BufferUsageHint.StaticDraw);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, iboID);
            GL.BufferData(BufferTarget.ElementArrayBuffer, (IntPtr)(indices.Length * sizeof(int)), indices, BufferUsageHint.StaticDraw);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
        }

        public void Draw()
        {
            GL.EnableVertexAttribArray(0);
            GL.EnableVertexAttribArray(1);

            GL.BindBuffer(BufferTarget.ArrayBuffer, vboID);
            GL.VertexAttribPointer(0, 2, VertexAttribPointerType.Float, false, 4 * sizeof(float), 0);
            GL.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, 4 * sizeof(float), 2 * sizeof(float));
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, iboID);
            GL.DrawElements(BeginMode.Triangles, size, DrawElementsType.UnsignedInt, 0);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);

            GL.DisableVertexAttribArray(0);
            GL.DisableVertexAttribArray(1);
        }
    }
}
