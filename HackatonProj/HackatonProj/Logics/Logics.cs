using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HackatonProj.Drawing;
using SFML.Graphics;
using SFML.Window;
using SFML.Window;

namespace HackatonProj.Logics
{
    class Logics
    {
        private Action<Drawable> requestDrawObj;
        private Action<Drawable> requestDrawSingleObj;
        private Action<Core.gameState> changeState;
        private Action<bool> setWindowThreadActive;
        
        StoryPresenter storyPresenter = new StoryPresenter();

        public Logics(Action<Drawable> drawingMethodRef, Action<Drawable> drawingSingleObjMethodRef,
            Action<Core.gameState> changeStateMethodRef, Action<bool> setWindowThreadActiveAction)
        {
            requestDrawObj = drawingMethodRef;
            changeState = changeStateMethodRef;
            requestDrawSingleObj = drawingSingleObjMethodRef;
            this.setWindowThreadActive = setWindowThreadActiveAction;
        }
        
        public void StartPresentingStory()
        {
            setWindowThreadActive(false);//Stop using the window before passing it to presenting thread
           Thread storyPresentingThread = new Thread(PresentStory);
            storyPresentingThread.Start();
        }
        /// <summary>
        /// Presents the story to the user. Is called as a separate thread.
        /// </summary>
        private void PresentStory()
        {
            setWindowThreadActive(true);//In SFML only one thread at any given time can have the window active.
            foreach (var page in storyPresenter)
            {
                requestDrawSingleObj(page.Item1);
                storyPresenter.WaitForNextPage((page.Item2));
            }
            setWindowThreadActive(false);//Deactivate the window before switching to next thread.
            changeState(Core.gameState.StopPresentingStory);
        }
        public void LaunchGame()
        {
            throw new NotImplementedException();
        }
    }
}
