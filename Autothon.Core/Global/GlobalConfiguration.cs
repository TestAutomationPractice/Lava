using log4net;
using log4net.Config;
using System;

namespace Autothon.Core.Global
{
    public class GlobalConfiguration
    {
        private static bool _IsInitialized;
        private static string ReportFolder = DateTime.UtcNow.ToString("YYYY-mm-dd hh:mm:ss");
        private GlobalConfiguration()
        {
            if (_IsInitialized)
                return;

        }
        private static readonly object padlock = new object();
        private static GlobalConfiguration instance = null;
        public static GlobalConfiguration Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new GlobalConfiguration();
                        _IsInitialized = true;
                    }
                    return instance;
                }
            }
        }
    }
}
