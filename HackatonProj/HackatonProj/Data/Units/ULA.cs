using HackatonProj.Data.Objects;
using SFML.System;
using SFML.Graphics;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackatonProj.Data.Units
{
    class ULA : IEnemy
    {
        private Sprite _ULASprite;
        private int _health = 10;

        public void Reset()
        {
            _ULASprite.Position = new Vector2f((float)0.5 * WindowData.windowSize.X, -100);
            _health = 10;
        }

        public void Update()
        {

        }

        public void Launch(float velocity)
        {

        }

        public void ReceiveHit(Bullet bullet)
        {
            _health -= bullet.damage;
            if(_health <= 0)
            {
                Reset();
            }
        }

        public int Health
        {
            get
            {
                return 0;
            }
        }

        public void Move(Vector2f vector)
        {
            _ULASprite.Position += vector;
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            _ULASprite.Draw(target, states);
        }

        public RectangleShape GetCollisionBox()
        {
            Vector2f position = _ULASprite.Position;
            Vector2f size = new Vector2f(_ULASprite.Texture.Size.X, _ULASprite.Texture.Size.Y);
            RectangleShape tmp = new RectangleShape(new Vector2f(136, 73));
            tmp.Position = position + new Vector2f(62, 47);
            return tmp;
        }

        // Relative position of the collision box 62 47
        // Size of the collision box 136 73
    }
}
