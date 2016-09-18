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
        private Transform transform;

        protected override void Initialize()
        {
            RenderingSystem.SetClearColour(Color.CornflowerBlue);

            transform = new Transform();
            shader = new Shader("Resources/Shaders/vertex.glsl", "Resources/Shaders/fragment.glsl");
            shader.AddUniform("transformationMatrix");

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
            if(Input.GetKey(OpenTK.Input.Key.A))
            {
                transform.Translate(-0.001f, 0);
            }

            if(Input.GetKey(OpenTK.Input.Key.D))
            {
                transform.Translate(0.001f, 0);
            }
        }

        protected override void Render()
        {
            shader.Start();
            shader.LoadMatrix("transformationMatrix", transform.TransformationMatrix);
            mesh2d.Draw();
            shader.Stop();
        }

        protected override void Shutdown()
        {
            base.Shutdown();
        }
    }
}
