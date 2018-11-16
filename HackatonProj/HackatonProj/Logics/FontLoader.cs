using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace HackatonProj.Logics
{
    class FontLoader
    {
        private Font usedFont;
        private readonly string fontFilePath = "gameFont.fon";

        public Font GetFont()
        {
            return usedFont ?? (usedFont = new Font(fontFilePath));
        }

    }
}
