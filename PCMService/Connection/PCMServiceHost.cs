using Contract;
using System;
using System.Collections.Generic;
using System.IdentityModel.Policy;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Text;
using SecurityManagerPCM;
using System.Threading.Tasks;
using System.ServiceModel.Description;
using System.Security.Principal;

namespace PCMService.Connection
{
    class PCMServiceHost
    {
        public ServiceHost host;
        public PCMServiceHost()
        {
            NetTcpBinding binding = new NetTcpBinding();
            binding.Security.Mode = SecurityMode.Transport;
            //sertifikati
            binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Certificate;
            string address = "net.tcp://localhost:9998/WCFServicePCM";
         //   binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;// za win autent
            host = new ServiceHost(typeof(WCFServicePCM));
            host.AddServiceEndpoint(typeof(IWCFServicePCM), binding, address);

            host.Description.Behaviors.Remove(typeof(ServiceDebugBehavior));
            host.Description.Behaviors.Add(new ServiceDebugBehavior() { IncludeExceptionDetailInFaults = true });


             host.Credentials.ClientCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.Custom;
             host.Credentials.ClientCertificate.Authentication.CustomCertificateValidator = new Servicecertvalidation();//****
              
            ///If CA doesn't have a CRL associated, WCF blocks every client because it cannot be validated
            host.Credentials.ClientCertificate.Authentication.RevocationMode = X509RevocationMode.NoCheck;

            ///Set appropriate service's certificate on the host. Use CertManager class to obtain the certificate based on the "srvCertCN"
            host.Credentials.ServiceCertificate.Certificate = CertManager.GetCertificateFromStorage(StoreName.My, StoreLocation.LocalMachine, Formatter.ParseName(WindowsIdentity.GetCurrent().Name));
            ///// za Custom principal, da proveri da li korisnik ima permisiju getPass
            ///
            // za metodu CheckAccessCore-
            //host.Authorization.ServiceAuthorizationManager = new CustomServiceAuthorizationManagerPCM();
            //podesavanje za custom principal
           // host.Authorization.PrincipalPermissionMode = PrincipalPermissionMode.Custom;


            List<IAuthorizationPolicy> policies = new List<IAuthorizationPolicy>();
            policies.Add(new CustomAuthorizationPolicyPCM());
            host.Authorization.ExternalAuthorizationPolicies = policies.AsReadOnly();
            host.Authorization.PrincipalPermissionMode = PrincipalPermissionMode.Custom;


        }
    }
}
