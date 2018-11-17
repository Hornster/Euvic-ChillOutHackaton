using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;

namespace HackatonProj.Data
{
    
    class BackgroundContainer
    {
        Sprite sprite;

        public BackgroundContainer(Vector2f windowSize)
        {
            sprite = new Sprite(Textures.BgTexture);
            sprite.Texture.Repeated = true;

            float factorX = windowSize.X / sprite.GetLocalBounds().Width;
            float factorY = windowSize.Y / sprite.GetLocalBounds().Width;
            float result = (factorX > factorY ? factorX : factorY);
            sprite.Scale = new Vector2f(result, result);
        }

        public Sprite GetSprite()
        {
            return sprite;
        }
    }
}
