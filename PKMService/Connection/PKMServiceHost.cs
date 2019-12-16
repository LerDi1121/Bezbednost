using System;
using Contracts;
using SecutityManager;
using System.Collections.Generic;
using System.IdentityModel.Policy;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace PKMService.Connection
{

    class PKMServiceHost
    {
        public ServiceHost host;
        public PKMServiceHost()
        {


            NetTcpBinding binding = new NetTcpBinding();
            binding.Security.Mode = SecurityMode.Transport;
            // wind autentifikacija
            binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;
            binding.Security.Transport.ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign;//za potpis

            string address = "net.tcp://localhost:9999/WCFServicePKM";

            host = new ServiceHost(typeof(WCFServicePKM));
            host.AddServiceEndpoint(typeof(IWCFServicePKM), binding, address);

            // Omogucava da vrati bilo koji exception 
            host.Description.Behaviors.Remove(typeof(ServiceDebugBehavior));
            host.Description.Behaviors.Add(new ServiceDebugBehavior() { IncludeExceptionDetailInFaults = true });

            // za metodu CheckAccessCore-
            host.Authorization.ServiceAuthorizationManager = new CustomServiceAuthorizationManager();
            //podesavanje za custom principal
            host.Authorization.PrincipalPermissionMode = PrincipalPermissionMode.Custom;
            List<IAuthorizationPolicy> policies = new List<IAuthorizationPolicy>();
            //dodajemo taj customprincipal
            policies.Add(new CustomAuthorizationPolicyPKM());
            host.Authorization.ExternalAuthorizationPolicies = policies.AsReadOnly();

        }
    }
}
