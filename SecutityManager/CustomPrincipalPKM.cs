using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Principal;
using System.Text;
using Contract;
using System.Threading.Tasks;
using Formatter = Contract.Formatter;
using System.Threading;

namespace SecutityManager
{
    public class CustomPrincipalPKM: IPrincipal
    {
        WindowsIdentity identity = null;
        public CustomPrincipalPKM(WindowsIdentity windowsIdentity)
        {
            identity = windowsIdentity;
        }

        public IIdentity Identity
        {
            get { return identity; }
        }

        public bool IsInRole(string permission)
        {
            string userName = Formatter.ParseName(Thread.CurrentPrincipal.Identity.Name);
            string svrName = Formatter.ParseName(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            foreach (IdentityReference group in this.identity.Groups)
            {
                SecurityIdentifier sid = (SecurityIdentifier)group.Translate(typeof(SecurityIdentifier));
                var name = sid.Translate(typeof(NTAccount));
                string groupName =Formatter.ParseName(name.ToString());
                string[] permissions;
                if (RoleConfig.GetPermissions(groupName, out permissions))
                {
                    foreach (string permision in permissions)
                    {
                        if (permision.Equals(permission))
                        {
                            Logger.AuthorizationSuccess(userName, svrName);
                            return true;
                        }
                    }
                }
            }
            Logger.AuthorizationFailed(userName, svrName, "The client does not have a permit");
            return false;
        }
    }
}
