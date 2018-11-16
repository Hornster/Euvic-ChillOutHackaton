using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackatonProj.Data.Objects;
using HackatonProj.Data.Units;
using SFML.Graphics;

namespace HackatonProj.Drawing
{
    interface IView
    {
        void DrawObject(Drawable obj);
    }
}
