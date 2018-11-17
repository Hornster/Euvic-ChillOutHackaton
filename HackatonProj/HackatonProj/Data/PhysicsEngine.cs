using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackatonProj.Data.Units;
using SFML.Graphics;
using SFML.System;

namespace HackatonProj.Data
{
    static public class PhysicsEngine
    {
        private const float topOffset = 0.2f;
        public enum borderCollision { Left, Right, Up, Down,None}

        static public bool CheckCollision(IColidable first, IColidable second)
        {
            return first.GetCollisionBox().Intersects(second.GetCollisionBox());
        }

        static public Vector2f CalcColSolvePlayer(IColidable colliding, borderCollision collisionType)
        {
            Vector2f solveVect = new Vector2f(colliding.GetCollisionBox().Left, colliding.GetCollisionBox().Top);
            switch (collisionType)
            {
                case borderCollision.Down:
                       solveVect = new Vector2f(colliding.GetCollisionBox().Left ,WindowData.windowSize.Y - colliding.GetCollisionBox().Height);
                    break;
                case borderCollision.Up:
                    solveVect = new Vector2f(colliding.GetCollisionBox().Left, -topOffset*WindowData.windowSize.Y);
                    break;
                case borderCollision.Left:
                    solveVect = new Vector2f(0, colliding.GetCollisionBox().Top);
                    break;
                case borderCollision.Right:
                    solveVect = new Vector2f(WindowData.windowSize.X-colliding.GetCollisionBox().Width, colliding.GetCollisionBox().Top);
                    break;
            }

            return solveVect;
        }
        
        static public borderCollision CheckBorderCollision(IColidable colidable)
        {
            if (colidable.GetCollisionBox().Left <= 0)
                return borderCollision.Left;
            if (colidable.GetCollisionBox().Left + colidable.GetCollisionBox().Width >= WindowData.windowSize.X)
                return borderCollision.Right;
            if (colidable is Player)
            {
                if (colidable.GetCollisionBox().Top <= WindowData.windowSize.Y* topOffset)//Let's add a little bit of padding (20% of the screen) so the players have chance to react
                    return borderCollision.Up;
                if (colidable.GetCollisionBox().Top + colidable.GetCollisionBox().Height >= WindowData.windowSize.Y)
                    return borderCollision.Down;
            }
            else if (colidable is IEnemy)
            {
                if (colidable.GetCollisionBox().Top + colidable.GetCollisionBox().Height > WindowData.windowSize.Y)
                {
                    return borderCollision.Down;
                }
            }


            return borderCollision.None;
        }
    }
}
