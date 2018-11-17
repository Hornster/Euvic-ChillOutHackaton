using System;
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
        static int numberOfPlayers = 0;

        Enums.players player;
        Sprite playerSprite = new Sprite();
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
                player = Enums.players.Player1;
            }
            else
            {
                playerSprite.Texture = Textures.Player2Texture;
                player = Enums.players.Player2;
            }
            this.name = name;
        }

        public void ReceiveHit(Bullet bullet)
        {
            _health -= bullet.damage;
        }

        public int Health
        {
            get
            {
                return _health;
            }
        }

        public Bullet Shoot()
        {
            Vector2f position = playerSprite.Position;  
            Vector2f size = new Vector2f(playerSprite.Texture.Size.X, playerSprite.Texture.Size.Y);
            return new Bullet(player, new Vector2f(position.X + (float)0.5 * size.X - (float)0.5 * size.X, position.Y));
        }

        public FloatRect GetCollisionBox()
        {
            Vector2f position = new Vector2f(playerSprite.TextureRect.Width, playerSprite.TextureRect.Height);
            Vector2f size = new Vector2f(playerSprite.TextureRect.Left, playerSprite.TextureRect.Top);
            FloatRect tmp = new FloatRect(position, size);
            return tmp;
        }
    }
}
