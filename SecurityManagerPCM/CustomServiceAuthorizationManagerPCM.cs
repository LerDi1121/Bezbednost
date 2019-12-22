using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SecurityManagerPCM
{
    public class CustomServiceAuthorizationManagerPCM : ServiceAuthorizationManager
    {
        protected override bool CheckAccessCore(OperationContext operationContext)
        {
            

            CustomPrincipalPCM principal = operationContext.ServiceSecurityContext.AuthorizationContext.Properties["Principal"] as CustomPrincipalPCM;
            return principal.IsInRole("Read");

        }
    }
}
