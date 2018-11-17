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
    class Player : ILivingEntity
    {
        static int numberOfPlayers;
        
        Enums.players player;
        Sprite playerSprite = new Sprite();
        string name;
        readonly Vector2f maxVelocity = new Vector2f(800.0f, 800.0f);
        Vector2f currentVelocity = new Vector2f(0.0f, 0.0f);

        public void MultiplyVelocity(Vector2i directionVector)
        {
            currentVelocity.X = maxVelocity.X * directionVector.X;
            currentVelocity.Y = maxVelocity.Y * directionVector.Y;
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

        public void ReceiveHit(Bullet bullet)
        {
            Health -= bullet.damage;
            if (Health <= 0)
                throw new NotImplementedException();
        }

        public int Health { get; private set; } = 10;

        public Bullet Shoot()
        {
            Vector2f position = playerSprite.Position;  
            Vector2f size = new Vector2f(playerSprite.Texture.Size.X, playerSprite.Texture.Size.Y);
            return new Bullet(player, new Vector2f(position.X + (float)0.5 * size.X - (float)0.5 * size.X, position.Y));
        }

        public RectangleShape GetCollisionBox()
        {
            RectangleShape tmp = new RectangleShape(new Vector2f(playerSprite.TextureRect.Width, playerSprite.TextureRect.Height));
            tmp.Position = playerSprite.Position;
            return tmp;
        }

        public void ResetVelocity()
        {
            currentVelocity.X = currentVelocity.Y = 0.0f;
        }
    }
}
