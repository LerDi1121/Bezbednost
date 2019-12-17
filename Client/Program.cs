using Client.Connections;
using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            NetTcpBinding binding = new NetTcpBinding();
            string address = "net.tcp://localhost:9999/WCFServicePKM";

            using (WCFClient proxy = new WCFClient(binding, new EndpointAddress(new Uri(address))))
            {   proxy.SingUp();
                    proxy.SingIn();
                    proxy.savePassword("facebook", "nesto");
                    proxy.deletePassword("facebook", "nesto");
                    proxy.changePassword("facebook", "nesto", "nesto");
                    proxy.readAllPassword();
                    proxy.readPasswordFor("facebook");


            }
            string address2 = "net.tcp://localhost:9998/WCFServicePCM";
            NetTcpBinding binding2 = new NetTcpBinding();
            Console.ReadKey();
            binding2.Security.Transport.ClientCredentialType = TcpClientCredentialType.Certificate;
            X509Certificate2 ClientCert = CertManager.GetCertificateFromStorage(StoreName.My, StoreLocation.LocalMachine, "client");
            string name = Formatter.ParseName(WindowsIdentity.GetCurrent().Name);

          /* using (WCFClientPCM proxy = new WCFClientPCM(binding2, new EndpointAddress(new Uri(address2),    new X509CertificateEndpointIdentity(ClientCert) )))
            {
                proxy.getPassword(5);
                proxy.getRndPassword();


            }*/

            Console.ReadLine();
        }
    }
}
