using log4net;
using log4net.Config;

namespace Autothon.Core.Logger
{
    public static class ConsoleLogger
    {        
        public static readonly ILog log =LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        public static void Warning(string message)
        {
            log.Warn(message);
        }
        public static void Error(string message)
        {
            log.Error(message);
        }
        public static void Information(string message)
        {
            log.Info(message);
        }
        public static void Debug(string message)
        {
            log.Debug(message);
        }
    }
}
