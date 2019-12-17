using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;

namespace Client.Connections
{
   public class WCFClientPCM : ChannelFactory<IWCFServicePCM>, IWCFServicePCM, IDisposable
    {
        IWCFServicePCM factory;

        public WCFClientPCM(NetTcpBinding binding, EndpointAddress address)
            : base(binding, address)
        {
              this.Credentials.ServiceCertificate.Authentication.CertificateValidationMode = System.ServiceModel.Security.X509CertificateValidationMode.ChainTrust;
            this.Credentials.ServiceCertificate.Authentication.RevocationMode = X509RevocationMode.NoCheck;
            this.Credentials.ClientCertificate.Certificate = CertManager.GetCertificateFromStorage(StoreName.My, StoreLocation.LocalMachine, "client");

            factory = this.CreateChannel();
        }

        public string getPassword(int numOfChar)
        {
            string str= null;
            try
            {
                str=factory.getPassword(9);
                Console.WriteLine("success getPassword.");
               
            }
            catch (SecurityAccessDeniedException e)
            {
                Console.WriteLine("Error while trying to getPassword. Error message : {0}", e.Message);
            }
            return str;
        }

        public string getRndPassword()
        {
            string str = null;
            try
            {
                str = factory.getRndPassword();
                Console.WriteLine("success getRndPassword.");

            }
            catch (SecurityAccessDeniedException e)
            {
                Console.WriteLine("Error while trying to getRndPassword. Error message : {0}", e.Message);
            }
            return str;
        }
    }
}
