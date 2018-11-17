using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;
using SFML.System;

namespace HackatonProj.Data.Objects
{
    public class Bullet: IProjectile, IColidable
    {
        private RectangleShape _shape = new RectangleShape(new Vector2f(3, 10));
        private Enums.players _player;
        private int _damage = 1;

        public int damage
        {
            get
            {
                return damage;
            }
        }

        public Bullet(Enums.players player, Vector2f startingPosition)
        {
            this._player = player;
        }

        public Enums.players Player
        {
            get
            {
                return _player;
            }
        }

        public void Move(Vector2f vector)
        {
            _shape.Position += vector;
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            _shape.Draw(target, states);
        }

        public void Update()
        {
            Move(new Vector2f(0, 2));
        }

        public FloatRect GetCollisionBox()
        {
            Vector2f position = new Vector2f(_shape.TextureRect.Width, _shape.TextureRect.Height);
            Vector2f size = new Vector2f(_shape.TextureRect.Left, _shape.TextureRect.Top);
            FloatRect tmp = new FloatRect(position, size);

            return tmp;
        }
    }
}
