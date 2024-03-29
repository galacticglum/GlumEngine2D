﻿using OpenTK.Graphics.OpenGL4;
using System.Drawing;

namespace GlumEngine2D
{
    public class RenderingSystem
    {
        public static void Initialize(float red = 0.0f, float green = 0.0f, float blue = 0.0f, float alpha = 0.0f)
        {
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.Texture2D);
        }

        public static void SetClearColour(float red = 0.0f, float green = 0.0f, float blue = 0.0f, float alpha = 0.0f)
        {
            GL.ClearColor(red, green, blue, alpha);
        }

        public static void SetClearColour(Color colour)
        {
            GL.ClearColor(colour);
        }

        public static void ClearScreen()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        }
    }
}
