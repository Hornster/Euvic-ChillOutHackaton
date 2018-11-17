using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackatonProj.Data;
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
            Vector2f windowSize = new Vector2f(WindowData.windowSize.X, WindowData.windowSize.Y);
            window = new RenderWindow(new VideoMode((uint)size.X, (uint)size.Y), title);
            window.SetView(new View(windowSize, new Vector2f(1.0f, 1.0f)));
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
