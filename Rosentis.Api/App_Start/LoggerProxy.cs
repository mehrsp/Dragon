namespace Rosentis.Api
{
    public static class LoggerProxy
    {
        public enum LogLevels
        {
            Trace = 0,
            Debug = 1,
            Info = 2,
            Warn = 3,
            Error = 4,
            Fatal = 5,

        }

        static LoggerProxy()
        {

        }

        public static void Log(LogLevels level, System.Type type, string message, System.Exception exception = null, params object[] args)
        {
            //NLog.Logger ologger = NLog.LogManager.GetLogger(type.ToString());
            //switch (level)
            //{
            //    case LogLevels.Info:
            //    {
            //        ologger.Info( exception: exception, message: message, args: args);
            //        break;
            //    }
            //    case LogLevels.Trace:
            //    {
            //        ologger.Trace(exception: exception, message: message, args: args);
            //        break;
            //    }
            //    case LogLevels.Debug:
            //    {
            //        ologger.Debug(exception: exception, message: message, args: args);
            //        break;
            //    }
            //    case LogLevels.Error:
            //    {
            //        ologger.Error(exception: exception, message: message, args: args);
            //        break;
            //    }
            //    case LogLevels.Warn:
            //    {
            //        ologger.Warn(exception: exception, message: message, args: args);
            //        break;
            //    }
            //    case LogLevels.Fatal:
            //    {
            //        ologger.Fatal(exception: exception, message: message, args: args);
            //        break;
            //}
            //}

        }
    }
}