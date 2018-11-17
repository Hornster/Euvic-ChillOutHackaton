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
    public class Bullet: IProjectile
    {
        private RectangleShape _shape = new RectangleShape(new Vector2f(3, 10));
        readonly Vector2f velocity = new Vector2f(0.0f, 1000.0f);
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
            this.Player = player;
        }

        public Enums.players Player { get; }

        public void Move(Vector2f vector)
        {
            _shape.Position += vector;
        }

        public void Move(Time lastFrameTime)
        {
            Vector2f frameVelocity = new Vector2f(velocity.X, velocity.Y * lastFrameTime.AsSeconds());
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
