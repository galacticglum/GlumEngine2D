using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlumEngine2D
{
    public delegate void GameInitializedEventHandler(object sender);
    public delegate void GameUpdatedEventHandler(object sender, GameUpdatedEventArgs args);
    public delegate void GameRenderedEventHandler(object sender);
    public delegate void GameClosedEventHandler(object sender);

    public class GameUpdatedEventArgs : EventArgs
    {
        public readonly float DeltaTime;

        public GameUpdatedEventArgs(float deltaTime) : base()
        {
            DeltaTime = deltaTime;
        }
    }
}
