using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Window;
using SFML.Graphics;
using HackatonProj.Data.Objects;
using SFML.System;

namespace HackatonProj.Data.Units
{
    abstract class Gate : IEnemy
    {
        protected bool _isAlive = false;
        protected float _velocity = 0;
        protected int _maxHealth = 1;
        protected int _health = 1;
        protected Sprite gateSprite = new Sprite();
        readonly Vector2f maxVelocity = new Vector2f(800.0f, 800.0f);
        Vector2f currentVelocity = new Vector2f(0.0f, 0.0f);

        public void Move(Time lastFrameTime)
        {
            currentVelocity *= lastFrameTime.AsSeconds();
            Move(currentVelocity);
        }
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
            if (Health <= 0)
                //throw new NotImplementedException("He is dead, but I don't know what to do :( !");
                this._isAlive = false; // Now I know :)
        }

        public int Health
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

            this._velocity = 0;
            this._health = _maxHealth;
            this.gateSprite.Position = new Vector2f((float)r.Next(WindowData.windowSize.X), 0);
        }

        public void Update()
        {
            this.Move(new Vector2f(0, _velocity / 60));
        }
        
        public void Launch(float velocity)
        {
            this._velocity = velocity;
            this._isAlive = true;
        }

        public bool IsAlive
        {
            get
            {
                return _isAlive;
            }
        }

        public FloatRect GetCollisionBox()
        {
            Vector2f position = new Vector2f(gateSprite.TextureRect.Width, gateSprite.TextureRect.Height);
            Vector2f size = new Vector2f(gateSprite.TextureRect.Left, gateSprite.TextureRect.Top);
            FloatRect tmp = new FloatRect(position, size);
            return tmp;
        }
    }
}
