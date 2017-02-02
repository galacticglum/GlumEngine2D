using OpenTK;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace GlumEngine2D
{
    public class TestGame : Game
    {
        private Mesh2D mesh2d;
        private Sprite sprite;
        private Shader shader;
        private Transform transform;

        public TestGame(int width, int height, string title) : base(width, height, title)
        {
            GameInitializedEvent += Initialize;
            GameUpdatedEvent += Update;
            GameRenderedEvent += Render;

            Run();
        }

        private void Initialize(object sender)
        {
            RenderingSystem.SetClearColour(Color.CornflowerBlue);

            transform = new Transform();
            shader = new Shader("Resources/Shaders/vertex.glsl", "Resources/Shaders/fragment.glsl");
            shader.AddUniform("transformationMatrix");

            Vertex[] vertices = 
            {
                // Sector 1
                new Vertex(-0.5f, 0.5f, 0, 0),   // 0
                new Vertex(-0.5f, -0.5f, 0, 1),  // 1
                new Vertex(0.5f, -0.5f, 1, 1),   // 2
                new Vertex(0.5f, 0.5f, 1, 0),    // 3
            };

            int[] indices = 
            {
                0, 1, 3,
                3, 1, 2
            };

            mesh2d = new Mesh2D(vertices, indices);
            sprite = Resources.Load<Sprite>("Resources/Images/fatcat.png");
        }

        private void Update(object sender, GameUpdatedEventArgs args)
        {
            if(Input.GetKey(OpenTK.Input.Key.A))
            {
                transform.Translate(-2.0f * args.DeltaTime, 0);
                //transform.Rotate(-0.01f);
                //transform.Scale(-0.001f);
            }

            if (Input.GetKey(OpenTK.Input.Key.D))
            {
                transform.Translate(2.0f * args.DeltaTime, 0);
                //transform.Rotate(0.01f);
                //transform.Scale(0.001f);
            }
        }

        private void Render(object sender)
        {
            shader.Start();
            shader.LoadMatrix("transformationMatrix", transform.TransformationMatrix);
            sprite.Texture.Bind(0);
            mesh2d.Draw();
            shader.Stop();
        }
    }
}
