using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Graphics;

namespace GlumEngine2D
{
    public abstract class Game : GameWindow
    {
        private static Game instance;
        public static Game Instance
        {
            get { return instance; }
        }

        public Game(int width, int height, string title) : base(width, height, GraphicsMode.Default, title)
        {
            if(instance != null)
            {
                Console.WriteLine("You should never have more than one game class!");
            }
            instance = this;

            Run();
        }

        protected override void OnLoad(EventArgs e)
        {
            Initialize();
            RenderingSystem.Initialize(1);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            Input.Update();
            Update();
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            RenderingSystem.ClearScreen();
            Render();
            SwapBuffers();
        }

        protected override void OnClosed(EventArgs e)
        {           
            Shutdown();
            Dispose();
        }

        // Virtual methods
        protected virtual void Initialize() { }
        protected virtual void Update() { }
        protected virtual void Render() { }
        protected virtual void Shutdown() { }
    }
}
