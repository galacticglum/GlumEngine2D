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

            shader.AddUniform("ambientColour");
            shader.AddUniform("lightColour");
            shader.AddUniform("lightPosition");

            float aspectRatio = (float)Width / Height;

            Vertex[] vertices = 
            {
                // Sector 1
                new Vertex(-(aspectRatio / 2), 0.5f, 0, 0),   // 0
                new Vertex(-(aspectRatio / 2), -0.5f, 0, 1),  // 1
                new Vertex(aspectRatio / 2, -0.5f, 1, 1),   // 2
                new Vertex(aspectRatio / 2, 0.5f, 1, 0),    // 3
            };

            int[] indices = 
            {
                0, 1, 3,
                3, 1, 2
            };

            mesh2d = new Mesh2D(vertices, indices);
            sprite = Resources.Load<Sprite>("Resources/Images/hoboish.jpg");
        }

        private void Update(object sender, GameUpdatedEventArgs args)
        {
            if(Input.GetKey(OpenTK.Input.Key.W))
            {
                transform.Translate(0, 2.0f * args.DeltaTime);
            }

            if (Input.GetKey(OpenTK.Input.Key.S))
            {
                transform.Translate(0, -2.0f * args.DeltaTime);
            }

            if (Input.GetKey(OpenTK.Input.Key.A))
            {
                transform.Translate(-2.0f * args.DeltaTime, 0);
            }

            if (Input.GetKey(OpenTK.Input.Key.D))
            {
                transform.Translate(2.0f * args.DeltaTime, 0);
            }
        }

        private void Render(object sender)
        {
            shader.Start();

            shader.LoadVector("ambientColour", new Vector4(0.1f, 0.1f, 0.1f, 1));
            shader.LoadVector("lightColour", new Vector4(1, 0.6f, 0, 1));

            Vector2 mousePosition = Input.GetMousePosition();
            Vector2 position = new Vector2((mousePosition.X - Width / 2f) / (Width / 2f), (Height / 2f - mousePosition.Y) / (Height / 2f));

            shader.LoadVector("lightPosition", position);
            shader.LoadMatrix("transformationMatrix", transform.TransformationMatrix);

            sprite.Texture.Bind(0);
            mesh2d.Draw();
            shader.Stop();
        }
    }
}
