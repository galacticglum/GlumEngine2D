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
            RenderingSystem.SetClearColour(Color.CornflowerBlue);

            shader = new Shader("Resources/Shaders/vertex.glsl", "Resources/Shaders/fragment.glsl");
            shader.AddUniform("uniformColour");

            Vertex[] vertices = new Vertex[]
            {
                // Sector 1
                new Vertex(-0.5f, 0.5f),   // 0
                new Vertex(-0.5f, -0.5f),  // 1
                new Vertex(0.5f, -0.5f),   // 2
                new Vertex(0.5f, 0.5f),    // 3
            };

            int[] indices = new int[]
            {
                0, 1, 3,
                3, 1, 2
            };

            mesh2d = new Mesh2D(vertices, indices);
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
