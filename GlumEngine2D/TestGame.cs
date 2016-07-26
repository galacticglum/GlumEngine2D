using OpenTK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlumEngine2D
{
    public class TestGame : Game
    {
        public TestGame(int width, int height, string title) : base(width, height, title) { }

        private Mesh2D mesh2d;
        private Shader shader;

        protected override void Initialize()
        {
            RenderingSystem.SetClearColour(0, 0.8f, 0.6f, 1);

            shader = new Shader("Resources/Shader/vertex.glsl", "Resources/Shader/fragment.glsl");
            shader.AddUniform("uniformColour");

            Vertex[] vertices = new Vertex[]
            {
                new Vertex(-1f, -1f),
                new Vertex(1f, -1f),
                new Vertex(0f, 1f),
            };

            mesh2d = new Mesh2D(vertices);
        }

        protected override void Update()
        {
            shader.Start();
            if (Input.GetKeyDown(OpenTK.Input.Key.R))
            {
                shader.LoadVector("uniformColour", new Vector4(1, 0, 0, 1));
            }
            if (Input.GetKeyDown(OpenTK.Input.Key.G))
            {
                shader.LoadVector("uniformColour", new Vector4(0, 1, 0, 1));
            }
            if (Input.GetKeyDown(OpenTK.Input.Key.B))
            {
                shader.LoadVector("uniformColour", new Vector4(0, 0, 1, 1));
            }
            shader.Stop();
        }

        protected override void Render()
        {
            shader.Start();
            mesh2d.Draw();
            shader.Stop();
        }

        protected override void Shutdown()
        {
            base.Shutdown();
        }
    }
}
