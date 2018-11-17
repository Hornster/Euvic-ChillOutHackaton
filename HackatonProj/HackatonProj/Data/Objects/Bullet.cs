using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;

namespace HackatonProj.Data.Objects
{
    public class Bullet: IProjectile
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
    }
}
