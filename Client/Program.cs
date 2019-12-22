using Client.Connections;
using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.Sleep(1000);
            NetTcpBinding binding = new NetTcpBinding();
            string address = "net.tcp://localhost:9999/WCFServicePKM";
            string address2 = "net.tcp://localhost:9998/WCFServicePCM";
            NetTcpBinding binding2 = new NetTcpBinding();
   
            binding2.Security.Transport.ClientCredentialType = TcpClientCredentialType.Certificate;
            X509Certificate2 ServCert = CertManager.GetCertificateFromStorage(StoreName.TrustedPeople, StoreLocation.LocalMachine, "Selenic");//sertifikat servera 
            EndpointAddress Endaddress = new EndpointAddress(new Uri(address2), new X509CertificateEndpointIdentity(ServCert));
            WCFClient PKM;
            WCFClientPCM PCM;
            try
            {
                 PKM    = new WCFClient(binding, new EndpointAddress(new Uri(address)));
                 PCM = new WCFClientPCM(binding2, Endaddress);
                Console.Write("Povezivanje na server");
               
                Thread.Sleep(300);
                Console.Write(".");
                Thread.Sleep(300);
                Console.Write(".");
                Thread.Sleep(300);
                Console.Write(".");
                Console.WriteLine("");
                PKM.SingUp();


            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            while (true)
            {
                try
                {
                    Meni();
                    string Chose = Console.ReadLine();
                    Console.WriteLine(Chose);
                    if (Chose.ToLower().Equals("exit"))
                    {
                        break;
                    }
                   
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            /*using (WCFClient proxy = new WCFClient(binding, new EndpointAddress(new Uri(address))))
            {
                Console.ReadKey();
                proxy.SingUp();

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

            //odji u klasu wcfClientPMC 
            using (WCFClientPCM proxy = new WCFClientPCM(binding2, Endaddress))
            {
                proxy.getPassword(10);
                proxy.getRndPassword();


            }

            Console.ReadLine();*/
        }

        static void Meni()
        {
            Console.WriteLine("************************");
            Console.WriteLine("Izaberite opciju:");
            Console.WriteLine("");
            Console.WriteLine("\t1. Sacuvajte lozinku");
            Console.WriteLine("\t2. Generisite lozinku");
            Console.WriteLine("\t3. Izmenite lozinku");
            Console.WriteLine("\t4. Obrisite lozinku");
            Console.WriteLine("\t5. Procitajte lozinku za odredjen nalog");
            Console.WriteLine("\t6. Procitajte sve lozinke");
            Console.WriteLine("\tZa izlazak napisite Exit");
        }
    }
}
