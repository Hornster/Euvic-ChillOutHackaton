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
        private enum gameState { Running, Playing, Exit }

        private gameState currentState = gameState.Running;

        public Core()
        {
            drawingComponent = new DrawStuff(windowSize, title);
            _logics = new Logics();
        }

        private MainLoop()
        {
            do
            {
                switch (currentState)
                {
                        
                }
            } while (currentState != gameState.Exit);
        }
    }
}
