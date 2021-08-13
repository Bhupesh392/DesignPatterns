using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public sealed class Log : ILog
    {
        private static Lazy<Log> _instance = new Lazy<Log>();

        private Log()
        {
        }
        public static Log GetInstance
        {
            get
            {
                return _instance.Value;
            }
        }
        public void LogException(string message)
        {
            string fileName = string.Format("{0}_{1}.log", "Exception", "Bhupesh");
            string logfilePath = string.Format(@"{0}\{1}", @"C:\Users\ba35925\Source\repos\DesignPatterns\EmployeePortal", fileName);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("------------------------------------");
            sb.AppendLine(DateTime.Now.ToString());
            sb.AppendLine(message);
            using (StreamWriter writer = new StreamWriter(logfilePath, true))
            {
                writer.Write(sb.ToString());
                writer.Flush();
            }
        }
    }
}
