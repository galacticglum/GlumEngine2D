using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using OpenTK.Graphics.OpenGL4;
using OldGL = OpenTK.Graphics.OpenGL;
using PixelFormat = OpenTK.Graphics.OpenGL4.PixelFormat;

namespace GlumEngine2D
{
    public class Sprite : IResource<Sprite>
    {
        public Texture Texture { get; private set; }

        public int Width { get; private set; }
        public int Height { get; private set; }

        public Sprite Load(string filePath)
        {
            int textureId = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, textureId);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (float)TextureMinFilter.LinearMipmapLinear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (float)TextureMagFilter.Linear);

            string[] glExtensions = GL.GetString(StringName.Extensions).Split(' ');
            if (glExtensions.Contains("GL_EXT_texture_filter_anisotropic"))
            {
                int filterAmount = GL.GetInteger((GetPName) OldGL.ExtTextureFilterAnisotropic.MaxTextureMaxAnisotropyExt);
                GL.TexParameter(TextureTarget.Texture2D, (TextureParameterName)OldGL.ExtTextureFilterAnisotropic.TextureMaxAnisotropyExt, filterAmount);
            }

            Bitmap bitmap = new Bitmap(filePath);
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bitmapData.Width, bitmapData.Height, 0, PixelFormat.Bgra, PixelType.UnsignedByte, bitmapData.Scan0);
            bitmap.UnlockBits(bitmapData);

            Width = bitmap.Width;
            Height = bitmap.Height;
            Texture = new Texture(textureId);

            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, 0);

            return this;
        }
    }
}
