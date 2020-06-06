using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;

namespace Rosentis.Core.Logging
{
    public class FileLogger : ILogger
    {
        public void Log(string message)
        {
            string logPath = ConfigurationManager.AppSettings["LogPath"];
            logPath = string.IsNullOrEmpty(logPath) ? @"C:\Rosentis\Log\" : logPath;
            File.AppendAllText(string.Format(@"{0}{1}.txt", logPath, Guid.NewGuid()), message);
        }
    }
}
