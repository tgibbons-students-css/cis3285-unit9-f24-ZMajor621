using System;
using System.Xml.Linq;
using SingleResponsibilityPrinciple.Contracts;

namespace SingleResponsibilityPrinciple
{
    public class ConsoleLogger : ILogger
    {
        private void LogMessage(string type, string message, params object[] args)
        {
            Console.WriteLine(type+": "+message, args);
            using (StreamWriter logfile = File.AppendText("log.xml"))
            {
                logfile.WriteLine("<log><type>"+type+"</type><message>" + message + "</message></log> ", args);
            }
        }
        public void LogWarning(string message, params object[] args)
        {
            //Console.WriteLine(string.Concat("WARN: ", message), args);
            LogMessage("WARN", message, args);
        }

        public void LogInfo(string message, params object[] args)
        {
            //Console.WriteLine(string.Concat("INFO: ", message), args);
            LogMessage("INFO", message, args);
        }
    }
}
