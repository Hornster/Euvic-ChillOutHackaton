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
        private readonly Logics _logics;
        /// <summary>
        /// PresentingStory - application is presenting the story to the users.
        /// Playing - main loop of the game is being performed.
        /// Exit - game is about to be terminated.
        /// </summary>
        public enum gameState { PresentingStory, Playing, Exit }

        private gameState currentState = gameState.PresentingStory;

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
                    case gameState.PresentingStory:
                        ChangeState(gameState.PresentingStory);
                        break;
                    case gameState.Playing:
                        _logics.LaunchGame();
                        break;
                }
            } while (currentState != gameState.Exit);
        }
    }
}
