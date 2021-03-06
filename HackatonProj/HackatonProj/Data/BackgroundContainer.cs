﻿using SFML.Graphics;
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

        public void IniBg(Vector2f windowSize)
        {
            sprite = new Sprite();
            sprite.Texture = Textures.BgTexture;
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
