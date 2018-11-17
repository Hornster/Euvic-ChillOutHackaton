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
        private static readonly string texturesPlacement = "Textures\\";

        static private Texture _BossTexture     = new Texture(texturesPlacement + "BOSS.png");
        static private Texture _OrTexture       = new Texture(texturesPlacement + "OR.png");
        static private Texture _AndTexture      = new Texture(texturesPlacement + "AND.png");
        static private Texture _NorTexture      = new Texture(texturesPlacement + "NOR0-2.png");
        static private Texture _NorTexture2     = new Texture(texturesPlacement + "NOR1.png");
        static private Texture _NandTexture     = new Texture(texturesPlacement + "NAND0.png");
        static private Texture _NandTexture2    = new Texture(texturesPlacement + "NAND1-2.png");
        static private Texture _Player1Texture  = new Texture(texturesPlacement + "Player0.png");
        static private Texture _Player2Texture  = new Texture(texturesPlacement + "Player1.png");

        static public Texture BossTexture       { get { return _BossTexture; } }
        static public Texture OrTexture         { get { return _OrTexture; } }
        static public Texture AndTexture        { get { return _AndTexture; } }
        static public Texture NorTexture        { get { return _NorTexture; } }
        static public Texture NorTexture2       { get { return _NorTexture2; } }
        static public Texture NandTexture       { get { return _NandTexture; } }
        static public Texture NandTexture2      { get { return _NandTexture2; } }
        static public Texture Player1Texture    { get { return _Player1Texture; } }
        static public Texture Player2Texture    { get { return _Player2Texture; } }
    }
}
