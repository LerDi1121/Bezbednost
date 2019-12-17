using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public class Logger: IDisposable
    {
        private static EventLog customLog = null;
        const string SourceName = "Contact.Logger";
        const string LogName = "Name";
        static Logger()
        {
            try
            {
                if(!EventLog.SourceExists(SourceName))
                {
                    EventLog.CreateEventSource(SourceName, LogName);

                }
                customLog = new EventLog(LogName, Environment.MachineName, SourceName);
            }
            catch (Exception e)
            {
                customLog = null;
                Console.WriteLine("Error while trying to create log handle. Error = {0}", e.Message);
            }

        }
        public static void LogSuccessEvent(string username, string events)
        {
            if (customLog != null)
            {
                string message = string.Format("user {0} do {1} ", username, events);
                customLog.WriteEntry(message, EventLogEntryType.SuccessAudit);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.",events));
            }
        }
        public static void LogErrorEvent(string username, string events)
        {
            if (customLog != null)
            {
                string message = string.Format("user {0} do {1} ", username, events);
                customLog.WriteEntry(message, EventLogEntryType.Error);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.", events));
            }
        }

        public  void Dispose()
        {
            if (customLog != null)
            {
                customLog.Dispose();
                customLog = null;
            }
        }
    }
}
