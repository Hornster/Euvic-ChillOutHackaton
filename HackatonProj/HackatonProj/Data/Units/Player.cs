﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;
using HackatonProj.Data.Objects;
using SFML.System;

namespace HackatonProj.Data.Units
{
    class Player : ILivingEntity, IColidable
    {
        const int maxLivesCount = 3;
        static int numberOfPlayers;
        private int LivesCount = 3;
        Enums.players player;
        Sprite playerSprite = new Sprite();
        string name;
        readonly Vector2f maxVelocity = new Vector2f(800.0f, 800.0f);
        Vector2f currentVelocity = new Vector2f(0.0f, 0.0f);

        public static void ResetNumberOfPlayers()
        {
            numberOfPlayers = 0;
        }
        public void MultiplyVelocity(Vector2i directionVector)
        {
            currentVelocity.X = maxVelocity.X * directionVector.X;
            currentVelocity.Y = maxVelocity.Y * directionVector.Y;
        }

        public void Move(Time lastFrameTime)
        {
            currentVelocity *= lastFrameTime.AsSeconds();
            Move(currentVelocity);
        }
        // Moves the player by a given float vector.
        public void Move(Vector2f vector)
        {
            playerSprite.Position += vector;
        }

        // Moves the player by a given float vector.
        public void MoveTo(Vector2f vector)
        {
            playerSprite.Position = vector;
        }

        // Draws The player
        public void Draw(RenderTarget target, RenderStates states)
        {
            playerSprite.Draw(target, states);
        }

        public Player(string name)
        {
            numberOfPlayers++;
            if (numberOfPlayers > 2)
                throw new Exception("There is no way for more than 2 players!");
            if(numberOfPlayers == 1)
            {
                playerSprite.Texture = Textures.Player1Texture;
                player = Enums.players.Player1;
            }
            else
            {
                playerSprite.Texture = Textures.Player2Texture;
                player = Enums.players.Player2;
            }
            this.name = name;
        }
        public void ReceiveHit(IEnemy enemy)
        {
            Health -= enemy.Health;
            if (Health <= 0)
            {
                LivesCount--;
                if (LivesCount <= 0)
                {
                    IsAlive = false;
                }
            }
        }
        public void ReceiveHit(Bullet bullet)
        {
            Health -= bullet.damage;
            if (Health <= 0)
            {
                LivesCount--;
                if (LivesCount <= 0)
                {
                    IsAlive = false;
                }
            }
        }

        public int Health { get; private set; } = 10;
        public bool IsAlive { get; private set; } = true;

        public Bullet Shoot()
        {
            Vector2f position = playerSprite.Position;  
            Vector2f size = new Vector2f(playerSprite.Texture.Size.X, playerSprite.Texture.Size.Y);
            return new Bullet(player, new Vector2f(position.X + (float)0.5 * size.X, position.Y + 0.2f*size.Y));
        }

        public FloatRect GetCollisionBox()
        {
            Vector2f position = new Vector2f(playerSprite.Position.X, playerSprite.Position.Y);
            Vector2f size = new Vector2f(playerSprite.TextureRect.Width, playerSprite.TextureRect.Height);
            FloatRect tmp = new FloatRect(position, size);
            return tmp;
        }

        public void ResetVelocity()
        {
            currentVelocity.X = currentVelocity.Y = 0.0f;
        }
    }
}
