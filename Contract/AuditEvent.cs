using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public enum AuditEventTypes
    {
        UserAuthenticationSuccess = 0,
        UserAuthorizationSuccess = 1,
        UserAuthorizationFailed = 2,
        UserSingUpSuccess = 3,
        UserSingUpFailed = 4,
        UserChangePasswordSuccess = 5,
        UserChangePasswordFailed = 6,
        UserSavePasswordSuccess = 7,
        UserSavePasswordFailed = 8,
        UserDeletePasswordSuccess = 9,
        UserDeletePasswordFailed = 10,
        UserReadPasswordSuccess = 11,
        UserReadPasswordFailed = 12,
        UserGetRandomPasswordSuccess=13,
        UserGetRandomPasswordFailed=14,
        ServiceReadDataFromDB =15,
        ServiceWriteDataInDB = 16,
        ClientCertVerificationSuccess= 17,
        ClientCertVerificationFailed=18,
        ServerCertVverificationSuccess=19,
        ServerCertVverificationFailed=20

    }

    public class AuditEvents
    {
        private static ResourceManager resourceManager = null;
        private static object resourceLock = new object();

        private static ResourceManager ResourceMgr
        {
            get
            {
                lock (resourceLock)
                {
                    if (resourceManager == null)
                    {
                        resourceManager = new ResourceManager(typeof(AuditEventFile).FullName, Assembly.GetExecutingAssembly());
                    }
                    return resourceManager;
                }
            }
        }

        public static string UserAuthenticationSuccess
        {
            get
            {
                return ResourceMgr.GetString(AuditEventTypes.UserAuthenticationSuccess.ToString());
            }
        }

        public static string UserAuthorizationSuccess
        {
            get
            {
                return ResourceMgr.GetString(AuditEventTypes.UserAuthorizationSuccess.ToString());
            }
        }

        public static string UserAuthorizationFailed
        {
            get
            {
                return ResourceMgr.GetString(AuditEventTypes.UserAuthorizationFailed.ToString());
            }
        }
  
        public static string UserSingUpSuccess
        {
            get
            {
                return ResourceMgr.GetString(AuditEventTypes.UserSingUpSuccess.ToString());
            }
        }
        public static string UserSingUpFailed
        {
            get
            {
                return ResourceMgr.GetString(AuditEventTypes.UserSingUpFailed.ToString());
            }
        }
        public static string UserChangePasswordSuccess
        {
            get
            {
                return ResourceMgr.GetString(AuditEventTypes.UserChangePasswordSuccess.ToString());
            }
        }
        public static string UserChangePasswordFailed
        {
            get
            {
                return ResourceMgr.GetString(AuditEventTypes.UserChangePasswordFailed.ToString());
            }
        }
        public static string UserSavePasswordSuccess
        {
            get
            {
                return ResourceMgr.GetString(AuditEventTypes.UserSavePasswordSuccess.ToString());
            }
        }
        public static string UserSavePasswordFailed
        {
            get
            {
                return ResourceMgr.GetString(AuditEventTypes.UserSavePasswordFailed.ToString());
            }
        }
        public static string UserDeletePasswordSuccess
        {
            get
            {
                return ResourceMgr.GetString(AuditEventTypes.UserDeletePasswordSuccess.ToString());
            }
        }
        public static string UserDeletePasswordFailed
        {
            get
            {
                return ResourceMgr.GetString(AuditEventTypes.UserDeletePasswordFailed.ToString());
            }
        }
        public static string UserReadPasswordSuccess
        {
            get
            {
                return ResourceMgr.GetString(AuditEventTypes.UserReadPasswordSuccess.ToString());
            }
        }
        public static string UserReadPasswordFailed
        {
            get
            {
                return ResourceMgr.GetString(AuditEventTypes.UserReadPasswordFailed.ToString());
            }
        }
        public static string UserGetRandomPasswordSuccess
        {
            get
            {
                return ResourceMgr.GetString(AuditEventTypes.UserGetRandomPasswordSuccess.ToString());
            }
        }
        public static string UserGetRandomPasswordFailed
        {
            get
            {
                return ResourceMgr.GetString(AuditEventTypes.UserGetRandomPasswordFailed.ToString());
            }
        }
        public static string ServiceReadDataFromDB
        {
            get
            {
                return ResourceMgr.GetString(AuditEventTypes.ServiceReadDataFromDB.ToString());
            }
        }
        public static string ServiceWriteDataInDB
        {
            get
            {
                return ResourceMgr.GetString(AuditEventTypes.ServiceWriteDataInDB.ToString());
            }
        }
  
        public static string ClientCertVerificationSuccess
        {
            get
            {
                return ResourceMgr.GetString(AuditEventTypes.ClientCertVerificationSuccess.ToString());
            }
        }
        public static string ClientCertVerificationFailed
        {
            get
            {
                return ResourceMgr.GetString(AuditEventTypes.ClientCertVerificationFailed.ToString());
            }
        }
        public static string ServerCertVverificationSuccess
        {
            get
            {
                return ResourceMgr.GetString(AuditEventTypes.ServerCertVverificationSuccess.ToString());
            }
        }
        public static string ServerCertVverificationFailed
        {
            get
            {
                return ResourceMgr.GetString(AuditEventTypes.ServerCertVverificationFailed.ToString());
            }
        }
     

    }
}
