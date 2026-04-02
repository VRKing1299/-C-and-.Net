using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWatchSystemLib
{
    /// <summary>
    /// this is notification interface with SendNotification method
    /// </summary>
    interface Inotification
    {
        string SendNotification(string msg);
    }
}
