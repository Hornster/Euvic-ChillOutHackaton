using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HackatonProj.Data;
using HackatonProj.Data.Objects;

namespace HackatonProj.Data.Units
{
    class And : Gate
    {
        public And()
            : base()
        {
            gateSprite.Texture = Textures.AndTexture;
        }
    }

    class Or : Gate
    {
        public Or()
            : base()
        {
            gateSprite.Texture = Textures.OrTexture;
        }
    }

    class Nand : Gate
    {
        private Enums.players _vulnerableToPlayer = Enums.players.Player1;

        public Nand()
            : base()
        {
            gateSprite.Texture = Textures.NandTexture;
            _health = 2;
            _maxHealth = 2;
        }

        public new void ReceiveHit(Bullet bullet)
        {
            if (bullet.Player != _vulnerableToPlayer)
                return;

            _health -= bullet.damage;

            if (Health <= 0)
                this._isAlive = false;
            else
            {
                this.gateSprite.Texture = Textures.NandTexture2;
                this._vulnerableToPlayer = Enums.players.Player2;
            }
        }

        public new void Reset()
        {
            base.Reset();
            this.gateSprite.Texture = Textures.NandTexture;
            this._vulnerableToPlayer = Enums.players.Player1;
        }
    }

    class Nor : Gate
    {
        private Enums.players _vulnerableToPlayer = Enums.players.Player2;
        public Nor()
            : base()
        {
            gateSprite.Texture = Textures.NorTexture;
            _health = 2;
            _maxHealth = 2;
        }

        public new void ReceiveHit(Bullet bullet)
        {
            if (bullet.Player != _vulnerableToPlayer)
                return;

            _health -= bullet.damage;

            if (Health <= 0)
                this._isAlive = false;
            else
            {
                this.gateSprite.Texture = Textures.NorTexture2;
                this._vulnerableToPlayer = Enums.players.Player1;
            }
        }

        public new void Reset()
        {
            base.Reset();
            this.gateSprite.Texture = Textures.NorTexture;
            this._vulnerableToPlayer = Enums.players.Player2;
        }
    }
}
