using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HackatonProj.Data;

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
        public Nand()
            : base()
        {
            gateSprite.Texture = Textures.NandTexture;
            _health = 2;
        }
    }

    class Nor : Gate
    {
        public Nor()
            : base()
        {
            gateSprite.Texture = Textures.NorTexture;
            _health = 2;
        }
    }
}
