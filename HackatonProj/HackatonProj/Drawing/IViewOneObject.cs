using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace HackatonProj.Drawing
{
    /// <summary>
    /// Used to specify view type that supports drawing of a single object
    /// (first clears the view module, then draws the object and immediately after displays it).
    /// </summary>
    interface IViewOneObject
    {
        /// <summary>
        /// Draw single object
        /// </summary>
        /// <param name="obj">Object to draw and display immediately after.</param>
        void DrawSingleObject(Drawable obj);
    }
}
