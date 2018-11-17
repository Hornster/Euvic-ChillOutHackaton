using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;

namespace HackatonProj.Data
{
    public static class Textures
    {
        static public Texture OrTexture = new Texture("OR.png");
        static public Texture AndTexture = new Texture("AND.png");
        static public Texture NorTexture = new Texture("NOR0-2.png");
        static public Texture NorTexture2 = new Texture("NOR1.png");
        static public Texture NandTexture = new Texture("NAND0.png");
        static public Texture NandTexture2 = new Texture("NAND0-2.png");
        static public Texture Player1Texture = new Texture("Player1.png");
        static public Texture Player2Texture = new Texture("Player2.png");
    }
}
