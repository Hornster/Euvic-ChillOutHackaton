using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackatonProj.Data.Objects
{
    interface IProjectile : Drawable
    {
        /// <summary>
        /// Gets the damage of the projectile.
        /// </summary>
        /// <returns></returns>
        int damage
        {
            get;
        }
    }
}
