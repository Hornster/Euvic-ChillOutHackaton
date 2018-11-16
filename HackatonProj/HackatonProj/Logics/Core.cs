using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackatonProj.Data;
using HackatonProj.Drawing;
using SFML.Graphics;
using SFML.System;

namespace HackatonProj.Logics
{
    public class Core
    {
        private Vector2i windowSize = WindowData.windowSize;
        private string title = WindowData.programTitle;
        private IView drawingComponent;
        private readonly Logics _logics;
        /// <summary>
        /// StartPresentingStory - application is presenting the story to the users.
        /// Playing - main loop of the game is being performed.
        /// Exit - game is about to be terminated.
        /// </summary>
        public enum gameState { IsPresentingStory, StartPresentingStory, Playing, Exit }

        private gameState currentState = gameState.StartPresentingStory;

        public void ChangeState(gameState newState)
        {
            currentState = newState;
        }

        public Core()
        {
            DrawStuff drawStuff = new DrawStuff(windowSize, title);
            _logics = new Logics(drawingComponent.DrawObject, drawStuff.DrawSingleObject, ChangeState);

            drawingComponent = drawStuff;
        }
        /// <summary>
        /// Entrance point from the outside. Enters the main loop.
        /// </summary>
        public void Launch()
        {
            MainLoop();
        }
        private void MainLoop()
        {
            do
            {
                switch (currentState)
                {
                    case gameState.StartPresentingStory:
                        ChangeState(gameState.StartPresentingStory);
                        break;
                    case gameState.IsPresentingStory:
                        //TODO - catch events here
                        break;
                    case gameState.Playing:
                        _logics.LaunchGame();
                        break;
                }
            } while (currentState != gameState.Exit);
        }
    }
}
