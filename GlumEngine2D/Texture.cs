using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;

namespace GlumEngine2D
{
    public class Texture
    {
        private static Texture lastTextureBound;
        public readonly int Id;

        public Texture(int id)
        {
            Id = id;
        }

        public void Bind(uint unit)
        {
            if (lastTextureBound == this) return;
            if (unit > 31) return;

            GL.ActiveTexture(TextureUnit.Texture0 + (byte) unit);
            GL.BindTexture(TextureTarget.Texture2D, Id);

            lastTextureBound = this;
        }
    }
}
