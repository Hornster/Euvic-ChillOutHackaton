using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Window;

namespace HackatonProj.Data
{
    public struct WindowData
    {
        public static Vector2i windowSize = new Vector2i((int)SFML.Window.VideoMode.DesktopMode.Width, (int)SFML.Window.VideoMode.DesktopMode.Height);
        public const string programTitle = "De Vindicators";
    }
}
