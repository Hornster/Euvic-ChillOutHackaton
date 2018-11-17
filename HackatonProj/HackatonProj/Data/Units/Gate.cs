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
        private float myRespawnAwaitTime = 0.0f;
        private static Random r = new Random();
        protected bool _isAlive = false;
        protected int _maxHealth = 1;
        protected int _health = 1;
        protected Sprite gateSprite = new Sprite();
        private Vector2f maxVelocity = new Vector2f(0.0f, 0.0f);
        Vector2f currentVelocity = new Vector2f(0.0f, 0.0f);

        public void Move(Time lastFrameTime)
        {
            currentVelocity = maxVelocity * lastFrameTime.AsSeconds();
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
            {
                //throw new NotImplementedException("He is dead, but I don't know what to do :( !");
                this._isAlive = false; // Now I know :)
                Reset();
            }
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
            this.rotate();
        }

        public void Reset()
        {
            this.maxVelocity.Y = 0;
            this._isAlive = false;
            this._health = _maxHealth;
            this.MoveTo(new Vector2f((float)r.Next(WindowData.windowSize.X), -gateSprite.GetLocalBounds().Height -10.0f));//a little bit of padding
        }

        public void Update()
        {
            this.Move(new Vector2f(0, currentVelocity.Y));
        }
        
        public void Launch(float velocity)
        {
            this.maxVelocity.Y = velocity;
            this._isAlive = true;
        }

        public bool IsAlive
        {
            get
            {
                return _isAlive;
            }
        }

        public void Respawn(float currentTime, float respawnTime, float velocity)
        {
            myRespawnAwaitTime += currentTime;
            if (myRespawnAwaitTime >= respawnTime)
            {
                Launch(velocity);
                myRespawnAwaitTime = 0.0f;
            }
        }

        public FloatRect GetCollisionBox()
        {
            Vector2f position = new Vector2f(gateSprite.Position.X, gateSprite.Position.Y);
            Vector2f size = new Vector2f(gateSprite.TextureRect.Width, gateSprite.TextureRect.Height);
            FloatRect tmp = new FloatRect(position, size);
            return tmp;
        }

        private void rotate()
        {
            this.gateSprite.Origin = new Vector2f(128, 128);
            this.gateSprite.Rotation = 180;
        }
    }
}
