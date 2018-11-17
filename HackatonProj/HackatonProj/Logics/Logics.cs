using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HackatonProj.Data;
using HackatonProj.Drawing;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace HackatonProj.Logics
{
    class Logics
    {
        private TimeCounter timeCounter = new TimeCounter();
        private BackgroundContainer backgroundContainer = new BackgroundContainer();
        private bool firstLoop = true;
        private Clock mainClock = new Clock();
        private const float singleFrameTime = 1.0f / 60.0f;
        private Action<Drawable> requestDrawObj;
        private Action<Drawable> requestDrawSingleObj;
        private Action<Core.gameState> changeState;
        private Action<bool> setWindowThreadActive;
        private Action clearWindow;
        private Action display;
        private Func<Core.gameState> ChkCurrentState;

        private StoryPresenter      storyPresenter      = new StoryPresenter();
        private KeyEventResolver    keyEventResolver    = new KeyEventResolver();
        private GameOverseer        gameOverseer        = new GameOverseer();

        public Logics(DrawStuff drawStuff, Action<Core.gameState> changeStateMethodRef, 
            Action<bool> setWindowThreadActiveAction, Func<Core.gameState> ChkCurrentStateFunc)
        {
            requestDrawObj = drawStuff.DrawObject;
            changeState = changeStateMethodRef;
            requestDrawSingleObj = drawStuff.DrawSingleObject;
            clearWindow = drawStuff.ClearView;
            display = drawStuff.Display;

            this.setWindowThreadActive = setWindowThreadActiveAction;
            ChkCurrentState = ChkCurrentStateFunc;
            backgroundContainer.IniBg(new Vector2f(WindowData.windowSize.X, WindowData.windowSize.Y));
        }
        
        public void StartPresentingStory()
        {
            setWindowThreadActive(false);//Stop using the window before passing it to presenting thread
           Thread storyPresentingThread = new Thread(PresentStory);
            storyPresentingThread.Start();
        }

        public void HandleKeyPressedEvent(KeyEventArgs keyArgs)
        {
            if (keyEventResolver.ResolveKeyPressedEndProgram(keyArgs))
            {
                changeState(Core.gameState.Exit);
                return;
            }

            if (keyEventResolver.ResolveKeyPressedResetState(keyArgs))
            {
                gameOverseer.ResetState();
                timeCounter.ResetTimer();
            }
            for (Enums.players player = 0; player < Enums.players.End; player++)
            {
                var result = keyEventResolver.ResolveKeyPressedEventPlayers(keyArgs, player);
                gameOverseer.ModifyPlayerShotState(result, player);
            }
        }

        public void ListenForPlayerInput()
        {
            for (Enums.players player = 0; player < Enums.players.End; player++)
            {
                var result = keyEventResolver.ListenForPlayersInput(player);
                gameOverseer.ModifyPlayerMoveState(result, player);
            }
        }
        /// <summary>
        /// Special method that makes the game run slower on fast computers.
        /// </summary>
        public void SetMax60FPS()
        {
            while (mainClock.ElapsedTime.AsSeconds() < 0.9f * singleFrameTime)
            {

            }
        }
        /// <summary>
        /// Presents the story to the user. Is called as a separate thread.
        /// </summary>
        private void PresentStory()
        {
            setWindowThreadActive(true);//In SFML only one thread at any given time can have the window active.
            foreach (var page in storyPresenter)
            {
                if (ChkCurrentState() == Core.gameState.Exit)
                    return;

                requestDrawSingleObj(page.Item1);
                storyPresenter.WaitForNextPage((page.Item2));
            }
            setWindowThreadActive(false);//Deactivate the window before switching to next thread.
            changeState(Core.gameState.StopPresentingStory);
        }

        private void ManageCounter(Time elapsedTime)
        {
            timeCounter.AddTime(elapsedTime.AsSeconds());
            requestDrawObj(timeCounter.GetTimeCounter());
        }
        public void PerformGameLoop()
        {
            SetMax60FPS();
            if (firstLoop)
            {
                mainClock.Restart();
                firstLoop = false;
            }

            ListenForPlayerInput();
            gameOverseer.PerformGameLoop(mainClock.ElapsedTime);

            clearWindow();
            requestDrawObj(backgroundContainer.GetSprite());
            ManageCounter(mainClock.ElapsedTime);
            gameOverseer.DrawEntities(requestDrawObj);
            display();

            mainClock.Restart();
        }
    }
}
