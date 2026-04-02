using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWatchSystemLib
{
    /// <summary>
    /// this is implementing class of blootoothdevice ifitnesstracker inotification
    /// with connect blootooth, CountSteps, SendNotification methods overridden
    /// </summary>
    public class SmartWatch : IBluetoothDevice, IfitnessTracker, Inotification
    {
        public string ConnectBluetooth()
        {
            return " bluetooth is connected" ;
        }

        public string CountSteps(int steps)
        {
            return "steps : " + steps;
        }

        public string SendNotification(string msg)
        {
            return "notification";
        }
    }
}
