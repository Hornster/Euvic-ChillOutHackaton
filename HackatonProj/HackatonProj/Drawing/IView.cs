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
        /// <summary>
        /// Makes passed object to be drawn in the window.
        /// </summary>
        /// <param name="obj">Object to draw.</param>
        void DrawObject(Drawable obj);
        /// <summary>
        /// Clears the window.
        /// </summary>
        void ClearView();
        /// <summary>
        /// Shows drawn stuff on the screen.
        /// </summary>
        void Display();

        void SetActive(bool isActive);
    }
}
