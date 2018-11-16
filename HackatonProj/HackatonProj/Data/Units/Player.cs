﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.System;
using SFML.Graphics;
using HackatonProj.Data.Objects;

namespace HackatonProj.Data.Units
{
    class Player : ILivingEntity
    {
        static int numberOfPlayers = 0;


        Sprite playerSprite;
        string name;
        int _health = 10;

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
            }
            else
            {
                playerSprite.Texture = Textures.Player2Texture;
            }
            this.name = name;
        }

        public void ReceiveHit(Bullet bullet)
        {
            _health -= bullet.damage;
            if (health <= 0)
                throw new NotImplementedException();
        }

        public int health
        {
            get
            {
                return _health;
            }
        }
    }
}
