using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;

namespace GlumEngine2D
{
    public class RenderingSystem
    {
        public static void Initialize(float red = 0.0f, float green = 0.0f, float blue = 0.0f, float alpha = 0.0f)
        {
            GL.ClearColor(red, green, blue, alpha);

            GL.Enable(EnableCap.DepthTest);
            //GL.Enable(EnableCap.FramebufferSrgb);
        }

        public static void SetClearColour(float red = 0.0f, float green = 0.0f, float blue = 0.0f, float alpha = 0.0f)
        {
            GL.ClearColor(red, green, blue, alpha);
        }

        public static void SetClearColour(float red = 0.0f, float green = 0.0f, float blue = 0.0f)
        {
            GL.ClearColor(red / 255, green / 255, blue / 255, 1);
        }

        public static void ClearScreen()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        }
    }
}
