using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWatchSystemLib
{
    /// <summary>
    /// this is fitness Tracker interface with CountSteps method
    /// </summary>
    public interface IfitnessTracker
    {
        string CountSteps(int steps);
    }
}
