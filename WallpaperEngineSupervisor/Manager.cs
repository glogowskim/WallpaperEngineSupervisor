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
    class Manager
    {
        public Manager()
        {
            processes = Process.GetProcesses().ToList();
            wallpaperEngineService = ServiceController.GetServices().ToList().Where(x => x.ServiceName == "Wallpaper Engine Service").FirstOrDefault();
            wallpaperEngineStatus = wallpaperEngineService.CanStop;

            interval = 2000;
            configPath = "config.json";

            try
            {
                JObject jo = JObject.Parse(File.ReadAllText(configPath));
                interval = jo.GetValue("INTERVAL").ToObject<int>();
            }
            catch (Exception) { }
        }

        public void loop()
        {
            while(true)
            {
                PowerLineStatus pls = SystemInformation.PowerStatus.PowerLineStatus;

                if (pls.ToString() == "Online" && wallpaperEngineStatus == false)
                {
                    //turn on service
                    wallpaperEngineService.Start();
                    wallpaperEngineStatus = true;
                }
                else if (pls.ToString() == "Offline" && wallpaperEngineStatus == true)
                {
                    //turn off service and main process
                    processes = Process.GetProcesses().ToList();    //Reload processes
                    wallpaperEngineService.Stop();
                    processes.Where(x => x.ProcessName == "wallpaper64").FirstOrDefault()?.Kill();
                    wallpaperEngineStatus = false;
                }

                Thread.Sleep(interval);
            }
        }

        private int interval;
        private string configPath;

        /// <summary>
        /// Status of Wallpaper Engine service
        /// </summary>
        private bool wallpaperEngineStatus;

        private List<Process> processes;
        private ServiceController wallpaperEngineService;
    }
}
