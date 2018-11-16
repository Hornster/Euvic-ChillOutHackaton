﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace HackatonProj.Drawing
{
    class DrawStuff : IView, IViewOneObject
    {
        private RenderWindow window;

        public DrawStuff(Vector2i size, string title)
        {
            window = new RenderWindow(new VideoMode((uint)size.X, (uint)size.Y), title);
        }

        public void DrawObject(Drawable obj)
        {
            window.Draw(obj);
        }

        public void ClearView()
        {
            window.Clear();
        }

        public void Display()
        {
            window.Display();
        }

        public void DrawSingleObject(Drawable obj)
        {
            ClearView();
            DrawObject(obj);
            Display();
        }
    }
}
