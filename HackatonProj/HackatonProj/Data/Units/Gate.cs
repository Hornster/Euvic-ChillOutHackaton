using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.System;
using SFML.Graphics;
using HackatonProj.Data.Objects;

namespace HackatonProj.Data.Units
{
    class Gate : IEnemy
    {
        private int _health = 1;

        // Moves the gate by a given float vector
        public void Move(Vector2f vector)
        {

        }


        // Draws The gate
        public void Draw(RenderTarget target, RenderStates state)
        {

        }

        public void ReceiveHit(Bullet bullet)
        {
            _health--;
            if (health <= 0)
                throw new NotImplementedException();
        }

        public int health
        {
            get
            {
                return _health;
            }
        }
    }
}
