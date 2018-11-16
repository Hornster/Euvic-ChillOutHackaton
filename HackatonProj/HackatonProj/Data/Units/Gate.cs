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
        protected int _health = 1;
        protected Sprite gateSprite; 

        // Moves the gate by a given float vector
        public void Move(Vector2f vector)
        {
            gateSprite.Position += vector;
        }

        // Moves the gate to a given float vector
        public void MoveTo(Vector2f vector)
        {
            gateSprite.Position = vector;
        }


        // Draws The gate
        public void Draw(RenderTarget target, RenderStates states)
        {
            gateSprite.Draw(target, states);
        }

        public void ReceiveHit(Bullet bullet)
        {
            _health -= bullet.damage;
            if (health <= 0)
                throw new NotImplementedException("He is dead, but I don't know what to do :( !");
        }

        public int health
        {
            get
            {
                return _health;
            }
        }

        public Gate()
        {
            Reset();
        }

        public void Reset()
        {
            Random r = new Random();
            gateSprite.Position = new Vector2f(-100, (float)r.Next(screeenSize));
        }
    }
}
