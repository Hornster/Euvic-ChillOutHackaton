﻿using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackatonProj.Data
{
    public interface IColidable
    {
        FloatRect GetCollisionBox();
    }
}
