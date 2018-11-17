using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackatonProj.Drawing;
using SFML.Window;

namespace HackatonProj.Logics
{
    class EventCatcher
    {
        private Action<Core.gameState> changeState;
        private Action<KeyEventArgs> keyPressed;
        private IEventHost windowEventHost;

        private void OnClose(object sender, EventArgs args)
        {
            changeState(Core.gameState.Exit);
        }
        private void OnKeyPressed(object sender, KeyEventArgs keyArgs)
        {
            keyPressed(keyArgs);
        }

        public void RegisterChangeState(Action<Core.gameState> changeStateMethod)
        {
            changeState = changeStateMethod;
        }

        public void RegisterWindowEvents()
        {
            //TODO implement OnGain/LostFocus
        }

        public void RegisterKeyEvents(Action<KeyEventArgs> keyPressedAction)
        {
            keyPressed = keyPressedAction;
        }

        private void HookUpEvents()
        {
            windowEventHost.HookEventClosedEvent(OnClose);
            windowEventHost.HookEventKeyPressedEvent(OnKeyPressed);
        }

        public void CatchEvents()
        {
            windowEventHost.DispatchEvents();
        }

        public EventCatcher(IEventHost windowEventHost)
        {
            this.windowEventHost = windowEventHost;
            HookUpEvents();
        }
    }
}
