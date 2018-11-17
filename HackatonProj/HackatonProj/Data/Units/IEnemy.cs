using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;

namespace HackatonProj.Data.Units
{
    interface IEnemy : ILivingEntity
    {
        void Reset();
        void Update();
        void Launch(float velocity);
        bool IsAlive { get; }
        //void Move(Time lastFrameTime);
    }
}
