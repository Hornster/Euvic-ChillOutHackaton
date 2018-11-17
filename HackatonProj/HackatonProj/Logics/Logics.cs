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
using SFML.Window;

namespace HackatonProj.Logics
{
    class Logics
    {
        private bool firstLoop = true;
        private Clock mainClock = new Clock();
        private Action<Drawable> requestDrawObj;
        private Action<Drawable> requestDrawSingleObj;
        private Action<Core.gameState> changeState;
        private Action<bool> setWindowThreadActive;
        private Func<Core.gameState> ChkCurrentState;

        private StoryPresenter storyPresenter = new StoryPresenter();
        private KeyEventResolver keyEventResolver = new KeyEventResolver();
        private GameOverseer gameOverseer = new GameOverseer();

        public Logics(Action<Drawable> drawingMethodRef, Action<Drawable> drawingSingleObjMethodRef,
            Action<Core.gameState> changeStateMethodRef, Action<bool> setWindowThreadActiveAction,
                Func<Core.gameState> ChkCurrentStateFunc)
        {
            requestDrawObj = drawingMethodRef;
            changeState = changeStateMethodRef;
            requestDrawSingleObj = drawingSingleObjMethodRef;
            this.setWindowThreadActive = setWindowThreadActiveAction;
            ChkCurrentState = ChkCurrentStateFunc;
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
            for (Enums.players player = 0; player < Enums.players.End; player++)
            {
                var result = keyEventResolver.ResolveKeyPressedEventPlayers(keyArgs, player);
                gameOverseer.ModifyPlayerMoveShotState(result, player);
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
        public void PerformGameLoop()
        {
            if (firstLoop)
            {
                mainClock.Restart();
                firstLoop = false;
            }

            gameOverseer.PerformGameLoop(mainClock.ElapsedTime);
            mainClock.Restart();
        }
    }
}
