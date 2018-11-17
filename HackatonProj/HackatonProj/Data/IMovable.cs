using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;

namespace HackatonProj.Data
{
    interface IMovable
    {
        /// <summary>
        /// Move the object by given vector.
        /// </summary>
        /// <param name="movement"></param>
        void Move(Vector2f movement);
    }
}
