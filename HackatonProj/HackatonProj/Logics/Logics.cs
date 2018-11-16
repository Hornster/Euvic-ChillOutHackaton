using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HackatonProj.Drawing;
using SFML.Graphics;
using SFML.System;

namespace HackatonProj.Logics
{
    class Logics
    {
        private Action<Drawable> requestDrawObj;
        private Action<Drawable> requestDrawSingleObj;
        private Action<Core.gameState> changeState;
        
        StoryPresenter storyPresenter = new StoryPresenter();

        public Logics(Action<Drawable> drawingMethodRef, Action<Drawable> drawingSingleObjMethodRef,
            Action<Core.gameState> changeStateMethodRef)
        {
            requestDrawObj = drawingMethodRef;
            changeState = changeStateMethodRef;
            requestDrawSingleObj = drawingSingleObjMethodRef;
        }

        
        public void StartPresentingStory()
        {
           Thread storyPresentingThread = new Thread(PresentStory);
            storyPresentingThread.Start();
        }
        /// <summary>
        /// Presents the story to the user. Is called as a separate thread.
        /// </summary>
        private void PresentStory()
        {
            foreach (var page in storyPresenter)
            {
                requestDrawSingleObj(page.Item1);
                storyPresenter.WaitForNextPage((page.Item2));
            }

            changeState(Core.gameState.Playing);
        }
        public void LaunchGame()
        {
            throw new NotImplementedException();
        }
    }
}
