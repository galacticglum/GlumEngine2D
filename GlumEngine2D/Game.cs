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
        public static Game Instance { get; private set; }

        protected event GameInitializedEventHandler GameInitializedEvent;
        private void OnGameInitialized() { GameInitializedEvent?.Invoke(this); }

        protected event GameUpdatedEventHandler GameUpdatedEvent;
        private void OnGameUpdated(GameUpdatedEventArgs args) { GameUpdatedEvent?.Invoke(this, args); }

        protected event GameRenderedEventHandler GameRenderedEvent;
        private void OnGameRendered() { GameRenderedEvent?.Invoke(this); }

        protected event GameClosedEventHandler GameClosedEvent;
        private void OnGameClosed() { GameClosedEvent?.Invoke(this); }

        protected Game(int width, int height, string title) : base(width, height, GraphicsMode.Default, title)
        {
            if(Instance != null)
            {
                Console.WriteLine("You should never have more than one game class!");
            }
            Instance = this;
        }

        protected override void OnLoad(EventArgs e)
        {
            RenderingSystem.Initialize();
            OnGameInitialized();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            Input.Update();
            OnGameUpdated(new GameUpdatedEventArgs((float)e.Time));
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            RenderingSystem.ClearScreen();
            OnGameRendered();
            SwapBuffers();
        }

        protected override void OnClosed(EventArgs e)
        {           
            OnGameClosed();
            Dispose();
        }
    }
}
