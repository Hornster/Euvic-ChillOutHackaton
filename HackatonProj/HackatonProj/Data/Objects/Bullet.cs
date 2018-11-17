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
        private RectangleShape _shape = new RectangleShape(new Vector2f(5, 20));
        readonly Vector2f velocity = new Vector2f(0.0f, -1000.0f);

        public int damage { get; } = 1;


        public Bullet(Enums.players player, Vector2f startingPosition)
        {
            this.Player = player;
            _shape.Position = startingPosition;
            _shape.FillColor = Color.Cyan;
        }

        public Enums.players Player { get; }

        public void Move(Vector2f vector)
        {
            _shape.Position += vector;
        }

        public void Move(Time lastFrameTime)
        {
            Vector2f frameVelocity = new Vector2f(velocity.X, velocity.Y * lastFrameTime.AsSeconds());
            Move(frameVelocity);
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
            Vector2f position = new Vector2f(_shape.Position.X, _shape.Position.Y);
            Vector2f size = new Vector2f(_shape.Size.X, _shape.Size.Y);
            FloatRect tmp = new FloatRect(position, size);

            return tmp;
        }
    }
}
