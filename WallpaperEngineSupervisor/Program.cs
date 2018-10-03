using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Diagnostics;
using System.ServiceProcess;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json.Linq;

namespace WallpaperEngineSupervisor
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager m = new Manager();
            m.loop();
        }
    }
}
