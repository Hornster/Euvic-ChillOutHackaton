using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackatonProj.Data;
using HackatonProj.Drawing;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace HackatonProj.Logics
{
    public class Core
    {
        private Vector2i windowSize = WindowData.windowSize;
        private string title = WindowData.programTitle;
        private IView drawingComponent;
        private readonly Logics _logics;
        private EventCatcher eventCatcher;
        /// <summary>
        /// StartPresentingStory - application is presenting the story to the users.
        /// Playing - main loop of the game is being performed.
        /// Exit - game is about to be terminated.
        /// </summary>
        public enum gameState { IsPresentingStory, StartPresentingStory, StopPresentingStory,Playing, Exit }

        private gameState currentState = gameState.StartPresentingStory;

        private void IniEventCatcher()
        {
            eventCatcher.RegisterChangeState(ChangeState);
            //eventCatcher.RegisterWindowEvents();
            eventCatcher.RegisterKeyEvents(_logics.HandleKeyPressedEvent);
        }

        public void ChangeState(gameState newState)
        {
            currentState = newState;
        }

        public gameState ChkState()
        {
            return currentState;
        }

        public Core()
        {
            DrawStuff drawStuff = new DrawStuff(windowSize, title);
            _logics = new Logics(drawStuff, ChangeState, drawStuff.SetActive, ChkState);

            eventCatcher = new EventCatcher(drawStuff);
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
            //Initialize stuff that can be initialized after calls to constructors have been done.
            IniEventCatcher();
            do
            {
                eventCatcher.CatchEvents();

                switch (currentState)
                {
                    case gameState.StartPresentingStory:
                        _logics.StartPresentingStory();
                        ChangeState(gameState.IsPresentingStory);
                        break;
                    case gameState.IsPresentingStory:
                        //Basically, do nothing. It's time for the game to present the story, after all...
                        break;
                    case gameState.StopPresentingStory:
                        //Semi state - main thread regains control over the window here.
                        drawingComponent.SetActive(true);
                        ChangeState(gameState.Playing);
                        break;
                    case gameState.Playing:
                        _logics.PerformGameLoop();
                        break;
                }
            } while (currentState != gameState.Exit);
        }
    }
}
