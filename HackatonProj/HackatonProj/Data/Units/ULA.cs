﻿using HackatonProj.Data.Objects;
using SFML.System;
using SFML.Graphics;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackatonProj.Data.Units
{
    class ULA : IEnemy, IColidable
    {
        float myRespawnAwaitTime = 15.0f;
        private bool    _isAlive    = false;
        private Sprite  _ULASprite  = new Sprite();
        private int     _health     = 250;
        readonly Vector2f velocity = new Vector2f(20.0f, 40.0f);

        public ULA()
        {
            _ULASprite.Texture = Textures.BossTexture;
        }
        //IEnemy methods

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
            this._isAlive = true;
        }

        public void ReceiveHit(Bullet bullet)
        {
            _health -= bullet.damage;
            if(_health <= 0)
            {
                this._isAlive = false;
            }
        }

        public void Move(Vector2f vector)
        {
            _ULASprite.Position += vector;
        }

        public void Move(Time lastFrameTime)
        {
            Move(velocity * lastFrameTime.AsSeconds());
        }
        

        public void Draw(RenderTarget target, RenderStates states)
        {
            _ULASprite.Draw(target, states);
        }

        public FloatRect GetCollisionBox()
        {
            Vector2f position = _ULASprite.Position;
            Vector2f size = new Vector2f(_ULASprite.Texture.Size.X, _ULASprite.Texture.Size.Y);
            FloatRect tmp = new FloatRect(position, size);
            return tmp;
        }

        //properties

        public int Health
        {
            get
            {
                return 0;
            }
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
            if (currentTime >= respawnTime)
            {
                Launch(velocity);
                myRespawnAwaitTime = 0.0f;
            }
        }

        // Relative position of the collision box 62 47
        // Size of the collision box 136 73
    }
}
