﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SecutityManager
{
    public class CustomServiceAuthorizationManager: ServiceAuthorizationManager
    {
        protected override bool CheckAccessCore(OperationContext operationContext)
        {
            /***
             * napraviti svoju logiku
             * pozvati IsInRole u nasem principalu
             * */

            CustomPrincipalPKM principal = operationContext.ServiceSecurityContext.AuthorizationContext.Properties["Principal"] as CustomPrincipalPKM;
           return principal.IsInRole("Read");
            
        }
    }
}
