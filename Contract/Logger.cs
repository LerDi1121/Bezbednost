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

        public static void AuthenticationSuccess(string userName)
        {
            string UserAuthenticationSuccess = AuditEvents.UserAuthenticationSuccess;

            if (customLog != null)
            {
                string message = string.Format(UserAuthenticationSuccess, userName);
                customLog.WriteEntry(message);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.", (int)AuditEventTypes.UserAuthenticationSuccess));
            }
        }

        public static void AuthorizationSuccess(string userName, string serviceName)
        {
            string UserAuthorizationSuccess = AuditEvents.UserAuthorizationSuccess;
            if (customLog != null)
            {
                string message = string.Format(UserAuthorizationSuccess, userName, serviceName);
                customLog.WriteEntry(message);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.", (int)AuditEventTypes.UserAuthorizationSuccess));
            }
        }

         public static void AuthorizationFailed(string userName, string serviceName, string reason)
        {
            string UserAuthorizationFailed = AuditEvents.UserAuthorizationFailed;
            if (customLog != null)
            {
                string message = string.Format(UserAuthorizationFailed, userName, serviceName, reason);
                customLog.WriteEntry(message, EventLogEntryType.Error);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.", (int)AuditEventTypes.UserAuthorizationFailed));
            }
        }
        public static void SingUpFailed(string userName, string reason)
        {
            string TempString = AuditEvents.UserSingUpFailed;
            if (customLog != null)
            {
                string message = string.Format(TempString, userName, reason);
                customLog.WriteEntry(message, EventLogEntryType.Error);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.", (int)AuditEventTypes.UserSingUpFailed));
            }
        }
        public static void ChangePasswordFailed(string userName, string reason)
        {
            string TempString = AuditEvents.UserChangePasswordFailed;
            if (customLog != null)
            {
                string message = string.Format(TempString, userName, reason);
                customLog.WriteEntry(message, EventLogEntryType.Error);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.", (int)AuditEventTypes.UserChangePasswordFailed));
            }
        }
        public static void SavePasswordFailed(string userName, string reason)
            {
                string TempString = AuditEvents.UserSavePasswordFailed;
                if (customLog != null)
                {
                    string message = string.Format(TempString, userName, reason);
                    customLog.WriteEntry(message, EventLogEntryType.Error);
                }
                else
                {
                    throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.", (int)AuditEventTypes.UserSavePasswordFailed));
                }
            }
        public static void DeletePasswordFailed(string userName, string reason)
            {
                string TempString = AuditEvents.UserDeletePasswordFailed;
                if (customLog != null)
                {
                    string message = string.Format(TempString, userName, reason);
                    customLog.WriteEntry(message, EventLogEntryType.Error);
                }
                else
                {
                    throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.", (int)AuditEventTypes.UserDeletePasswordFailed));
                }
            }
        public static void ReadPasswordFailed(string userName, string reason)
            {
                string TempString = AuditEvents.UserReadPasswordFailed;
                if (customLog != null)
                {
                    string message = string.Format(TempString, userName, reason);
                    customLog.WriteEntry(message, EventLogEntryType.Error);
                }
                else
                {
                    throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.", (int)AuditEventTypes.UserReadPasswordFailed));
                }
            }
        public static void GetRandomPasswordFailed(string userName, string reason)
            {
                string TempString = AuditEvents.UserGetRandomPasswordFailed;
                if (customLog != null)
                {
                    string message = string.Format(TempString, userName, reason);
                    customLog.WriteEntry(message, EventLogEntryType.Error);
                }
                else
                {
                    throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.", (int)AuditEventTypes.UserGetRandomPasswordFailed));
                }
            }
        public static void ClientCertVerificationFailed(string userName,string srvName)
        {
            string TempString = AuditEvents.ClientCertVerificationFailed;
            if (customLog != null)
            {
                string message = string.Format(TempString, userName,srvName);
                customLog.WriteEntry(message, EventLogEntryType.Error);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.", (int)AuditEventTypes.ClientCertVerificationFailed));
            }
        }
        public static void ServerCertVverificationFailed(string userName, string srvName)
        {
            string TempString = AuditEvents.ServerCertVverificationFailed;
            if (customLog != null)
            {
                string message = string.Format(TempString, userName, srvName);
                customLog.WriteEntry(message, EventLogEntryType.Error);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.", (int)AuditEventTypes.ServerCertVverificationFailed));
            }
        }


        public static void SingUpSuccess(string userName)
        {
            string TempString = AuditEvents.UserSingUpSuccess;
            if (customLog != null)
            {
                string message = string.Format(TempString, userName);
                customLog.WriteEntry(message);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.", (int)AuditEventTypes.UserSingUpSuccess));
            }
        }
        public static void ChangePasswordSuccess(string userName)
        {
            string TempString = AuditEvents.UserChangePasswordSuccess;
            if (customLog != null)
            {
                string message = string.Format(TempString, userName);
                customLog.WriteEntry(message);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.", (int)AuditEventTypes.UserChangePasswordSuccess));
            }
        }
        public static void SavePasswordSuccess(string userName)
        {
            string TempString = AuditEvents.UserSavePasswordSuccess;
            if (customLog != null)
            {
                string message = string.Format(TempString, userName);
                customLog.WriteEntry(message);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.", (int)AuditEventTypes.UserSavePasswordSuccess));
            }
        }
        public static void DeletePasswordSuccess(string userName)
        {
            string TempString = AuditEvents.UserDeletePasswordSuccess;
            if (customLog != null)
            {
                string message = string.Format(TempString, userName);
                customLog.WriteEntry(message);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.", (int)AuditEventTypes.UserDeletePasswordSuccess));
            }
        }
        public static void ReadPasswordSuccess(string userName)
        {
            string TempString = AuditEvents.UserReadPasswordSuccess;
            if (customLog != null)
            {
                string message = string.Format(TempString, userName);
                customLog.WriteEntry(message);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.", (int)AuditEventTypes.UserReadPasswordSuccess));
            }
        }
        public static void GetRandomPasswordSuccess(string userName)
        {
            string TempString = AuditEvents.UserGetRandomPasswordSuccess;
            if (customLog != null)
            {
                string message = string.Format(TempString, userName);
                customLog.WriteEntry(message);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.", (int)AuditEventTypes.UserGetRandomPasswordSuccess));
            }
        }
        public static void ClientCertVerificationSuccess(string userName,string srvName)
        {
            string TempString = AuditEvents.ClientCertVerificationSuccess;
            if (customLog != null)
            {
                string message = string.Format(TempString, userName,srvName);
                customLog.WriteEntry(message);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.", (int)AuditEventTypes.ClientCertVerificationSuccess));
            }
        }
        public static void ServerCertVverificationSuccess(string userName, string srvName)
        {
            string TempString = AuditEvents.ServerCertVverificationSuccess;
            if (customLog != null)
            {
                string message = string.Format(TempString, userName,srvName);
                customLog.WriteEntry(message);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.", (int)AuditEventTypes.ServerCertVverificationSuccess));
            }
        }
        public static void ServiceReadDataFromDB(string userName)
        {
            string TempString = AuditEvents.ServiceReadDataFromDB;
            if (customLog != null)
            {
                string message = string.Format(TempString, userName);
                customLog.WriteEntry(message);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.", (int)AuditEventTypes.ServiceReadDataFromDB));
            }
        }
        public static void ServiceWriteDataInDB(string userName)
        {
            string TempString = AuditEvents.ServiceWriteDataInDB;
            if (customLog != null)
            {
                string message = string.Format(TempString, userName);
                customLog.WriteEntry(message);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.", (int)AuditEventTypes.ServiceWriteDataInDB));
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
