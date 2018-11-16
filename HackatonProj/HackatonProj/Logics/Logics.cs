using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace HackatonProj.Logics
{
    class Logics
    {
        Action<Drawable> requestDrawObj;

        public Logics(Action<Drawable> drawingMethodRef)
        {
            requestDrawObj = drawingMethodRef;
        }
        public void PresentStory()
        {
            Clock clock = new Clock();

            
        }
        public void LaunchGame()
        {
            throw new NotImplementedException();
        }
    }
}
