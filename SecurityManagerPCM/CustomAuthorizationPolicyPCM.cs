using System;
using System.Collections.Generic;
using System.IdentityModel.Claims;
using System.IdentityModel.Policy;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityManagerPCM
{
    public class CustomAuthorizationPolicyPCM : IAuthorizationPolicy
    {
        public ClaimSet Issuer => throw new NotImplementedException();

        public string Id => throw new NotImplementedException();

        public bool Evaluate(EvaluationContext evaluationContext, ref object state)
        {
            throw new NotImplementedException();
        }
    }
}
