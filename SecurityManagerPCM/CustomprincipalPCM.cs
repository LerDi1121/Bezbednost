using Contract;
using System;
using System.Collections.Generic;
using System.IdentityModel.Claims;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SecurityManagerPCM
{
    public class CustomPrincipalPCM : IPrincipal
    {

        WindowsIdentity identity = null;
        public CustomPrincipalPCM(WindowsIdentity windowsIdentity)
        {
            identity = windowsIdentity;
        }

        public IIdentity Identity
        {
            get { return identity; }
        }


        public bool IsInRole(string role)// poziva se samo za win autentifikaciju
        {
            string userName = Formatter.ParseName(Thread.CurrentPrincipal.Identity.Name);
            string svrName = Formatter.ParseName( System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            foreach (IdentityReference group in this.identity.Groups)
            {
                SecurityIdentifier sid = (SecurityIdentifier)group.Translate(typeof(SecurityIdentifier));
                var name = sid.Translate(typeof(NTAccount));
                string groupName = Formatter.ParseName(name.ToString());
                string[] permissions;
                if (RoleConfigPCM.GetPermissions(groupName, out permissions))
                {
                    foreach (string permision in permissions)
                    {
                        if (permision.Equals(role))
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
