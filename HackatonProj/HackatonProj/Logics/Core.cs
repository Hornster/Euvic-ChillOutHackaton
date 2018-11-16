using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackatonProj.Drawing;
using SFML.Graphics;
using SFML.System;

namespace HackatonProj.Logics
{
    public class Core
    {
        private Vector2i windowSize = new Vector2i(1024, 768);
        private string title = "De Vindicators";
        private IView drawingComponent;
        private Logics _logics;
        public enum gameState { Running, Playing, Exit }

        private gameState currentState = gameState.Running;

        public void ChangeState(gameState newState)
        {
            currentState = newState;
        }

        public Core()
        {
            drawingComponent = new DrawStuff(windowSize, title);
            _logics = new Logics();
        }

        private void MainLoop()
        {
            do
            {
                switch (currentState)
                {
                    case gameState.Running:
                        ChangeState(gameState.Running);
                        break;
                    case gameState.Playing:
                        _logics.LaunchGame();
                        break;
                }
            } while (currentState != gameState.Exit);
        }
    }
}
