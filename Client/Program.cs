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
            Console.ReadKey();
            NetTcpBinding binding = new NetTcpBinding();
            string address = "net.tcp://localhost:9999/WCFServicePKM";

           using (WCFClient proxy = new WCFClient(binding, new EndpointAddress(new Uri(address))))
            {
                Console.ReadKey();
                    proxy.SingUp();
                    proxy.SingIn();
                    proxy.savePassword("facebook", "nesto");
                    proxy.savePassword("facebook", "nesto");
                    proxy.savePassword("skype", "123");
                    proxy.deletePassword("facebook", "nesto");
                    proxy.changePassword("facebook", "nesto", "nesto");
                    proxy.changePassword("skype", "nova", "123");
                    proxy.readAllPassword();
                    proxy.readPasswordFor("facebook");
                proxy.readPasswordFor("skype");



            }

            string address2 = "net.tcp://localhost:9998/WCFServicePCM";
            NetTcpBinding binding2 = new NetTcpBinding();
            Console.ReadKey();
            binding2.Security.Transport.ClientCredentialType = TcpClientCredentialType.Certificate;
            X509Certificate2 ServCert = CertManager.GetCertificateFromStorage(StoreName.TrustedPeople, StoreLocation.LocalMachine, "Selenic");//sertifikat servera 
            EndpointAddress Endaddress = new EndpointAddress(new Uri(address2), new X509CertificateEndpointIdentity(ServCert));
         //odji u klasu wcfClientPMC 
           using (WCFClientPCM proxy = new WCFClientPCM(binding2, Endaddress))
            {
                proxy.getPassword(10);
                proxy.getRndPassword();


            }

            Console.ReadLine();
        }
    }
}
