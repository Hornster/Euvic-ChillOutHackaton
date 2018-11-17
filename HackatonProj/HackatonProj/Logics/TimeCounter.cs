using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackatonProj.Data;
using SFML.Graphics;
using SFML.System;

namespace HackatonProj.Logics
{
    class TimeCounter
    {
        private Vector2f myPos = new Vector2f();
        private FontLoader fontLoader = new FontLoader();
        private Text timeCounter;
        private float currentValue = 0.0f;

        public Text GetTimeCounter()
        {
            return timeCounter;
        }

        public void ResetTimer()
        {
            currentValue = 0.0f;
            timeCounter.DisplayedString = currentValue.ToString("0.00");
        }

        public void AddTime(float additionalTime)
        {
            currentValue += additionalTime;
            timeCounter.DisplayedString = currentValue.ToString("0.00");
        }

        public TimeCounter()
        {
            timeCounter = new Text("", fontLoader.GetFont(), 30);
            timeCounter.Color = Color.White;
            myPos = new Vector2f(10.0f, 10.0f);
            timeCounter.Position = myPos;
        }
        
    }
}
