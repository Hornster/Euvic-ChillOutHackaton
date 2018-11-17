using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackatonProj.Data.Units;
using SFML.Graphics;

namespace HackatonProj.Data
{
    static public class PhysicsEngine
    {
        static public bool CheckCollision(IColidable first, IColidable second)
        {
            return first.GetCollisionBox().Intersects(second.GetCollisionBox());
        }
        static public bool CheckBorderCollision(IColidable colidable)
        {
            if (colidable.GetCollisionBox().Left <= 0)
                return true;
            if (colidable.GetCollisionBox().Left - colidable.GetCollisionBox().Width >= WindowData.windowSize.Y)
                return true;
            if (colidable is Player)
            {
                if (colidable.GetCollisionBox().Top <= 0)
                    return true;
                if (colidable.GetCollisionBox().Top + colidable.GetCollisionBox().Height >= WindowData.windowSize.Y)
                    return true;
            }
            return false;
        }
    }
}
