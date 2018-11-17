using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace HackatonProj.Drawing
{
    interface IEventHost
    {
        void HookEventClosedEvent(EventHandler OnClose);
        void HookEventKeyPressedEvent(EventHandler<KeyEventArgs> OnKeyPressed);
        void HookLostFocusEvent(EventHandler OnLostFocus);
        void HookGainFocusEvent(EventHandler OnGainFocus);
        void HookResizedEvent(EventHandler<SizeEventArgs> OnResized);
        void DispatchEvents();      //For stuff like SFML where events have to be kicked in the ass to start moving xD
    }
}
