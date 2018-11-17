using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackatonProj.Data.Objects;
using SFML.Graphics;

namespace HackatonProj.Data.Units
{
    interface ILivingEntity : IMovable, Drawable, IColidable
    {
        /// <summary>
        /// 
        /// </summary>
        void ReceiveHit(Bullet bullet);
        int Health
        {
            get;
        }
        
    }
    
}
