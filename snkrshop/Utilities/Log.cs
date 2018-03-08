using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace snkrshop.Utilities
{
    public static class Log
    {
        const string FILE_LOG_NAME = "log.txt";
        public static void LogMessageToFile(this string message)
        {
            StreamWriter sw = new StreamWriter(FILE_LOG_NAME);
            try
            {
                string logLine = String.Format("{0:G}: {1}", System.DateTime.Now, message);
                sw.WriteLine(logLine);
            }
            finally
            {
                sw.Close();
            }
        }
        public static void LogExceptionToFile(this Exception ex)
        {
            string message = String.Format("{0} - {1}", ex.GetType().ToString(), ex.Message);
            message.LogMessageToFile();
        }
    }
}