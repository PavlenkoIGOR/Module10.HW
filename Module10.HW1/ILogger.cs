﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Module10.HW1
{
    public interface ILogger
    {
        void Error(string message);

        void Event(string message);
    }
}
