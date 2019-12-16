using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Principal;
using System.Text;
using Contract;
using System.Threading.Tasks;
using Formatter = Contract.Formatter;

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
                            return true;
                    }
                }
            }
            return false;
        }
    }
}
