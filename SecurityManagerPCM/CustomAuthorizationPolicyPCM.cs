using Contract;
using System;
using System.Collections.Generic;
using System.IdentityModel.Claims;
using System.IdentityModel.Policy;
using System.Linq;
using System.Security.Principal;
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
            object obj;
            if (!evaluationContext.Properties.TryGetValue("Identities", out obj))
                return false;

            IList<IIdentity> identities = obj as IList<IIdentity>;
            if (obj == null || identities.Count <= 0)
                return false;

            IIdentity identity = identities[0];
            try
            {
               // Logger.AuthenticationSuccess("usernameParam");
            }
            catch
            {
              //  throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.", (int)AuditEventTypes.UserAuthenticationSuccess));
            }
            evaluationContext.Properties["Principal"] = new CustomPrincipalPCM(identities[0]);
            return true;
        }
    }
}
