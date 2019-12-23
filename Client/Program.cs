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
            WCFClient PKM= null;
            WCFClientPCM PCM= null;
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
                PCM.getRndPassword();


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
                    int temp;
                   if(! Int32.TryParse(Chose, out temp))
                    {
                        continue;
                    }
                   if(temp<1 && temp> 6)
                    {
                        continue;
                    }
                   switch(temp)
                    {
                        case 1://cuvanje lozinke

                            Console.WriteLine( "Unesite nalog za koji zelite sacuvati lozinku");
                            string acc = Console.ReadLine();
                            Console.WriteLine("Unesite lozinku");
                            string pass = Console.ReadLine();
                            PKM.savePassword(acc, pass);
                            break;
                        case 2://generisanje
                            Console.WriteLine("\t1. Generisanje sifre od strane servera");

                            Console.WriteLine("\t1. Generisanje sifre od strane servera sa zadatom duzinom(veca od 6 karaktera)");
                            string tempgen = Console.ReadLine();
                            int numb;
                            if(! Int32.TryParse(tempgen, out numb))
                            {
                                Console.WriteLine("Unesite broj!!!");
                                continue;
                            }
                            if(numb == 1)
                            {
                                string tempPass= PCM.getRndPassword();
                                Console.WriteLine("Vasa sifra je : "+ tempPass);
                                Console.WriteLine("Da li zelite da je sacuvate? Y/N");
                                ConsoleKeyInfo yn = Console.ReadKey();
                                if (yn.Key == ConsoleKey.Y)
                                {
                                    Console.WriteLine("Unesite nalog za koji zelite da sacuvate: ");
                                    string TempAcc = Console.ReadLine();
                                    PKM.savePassword(TempAcc, tempPass);

                                }
                                else
                                    continue;

                            }
                            else if(numb==2)
                            {
                                Console.WriteLine("Unesite broj karaktera: ");
                                string numberOfchar = Console.ReadLine();
                                int numbCh;
                                if(int.TryParse(numberOfchar,out numbCh))
                                {
                                    string tempPass = PCM.getPassword(numbCh);
                                    Console.WriteLine("Vasa sifra je : " + tempPass);
                                    Console.WriteLine("Da li zelite da je sacuvate? Y/N");
                                    ConsoleKeyInfo yn = Console.ReadKey();
                                    if (yn.Key == ConsoleKey.Y)
                                    {
                                        Console.WriteLine("Unesite nalog za koji zelite da sacuvate: ");
                                        string TempAcc = Console.ReadLine();
                                        PKM.savePassword(TempAcc, tempPass);

                                    }
                                    else
                                        continue;
                                }
                                else
                                {
                                    Console.WriteLine("unesite broj!!!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Unesli ste nevazeci broj!");
                            }
                            break;
                        case 3://izmena
                            Console.WriteLine("Unesite navin naloga kojem zelite da promenite sifru: ");
                            string tempacc = Console.ReadLine();
                            Console.WriteLine("Unesite staru lozinku:");
                        
                            string oldPass = Console.ReadLine();
                            Console.WriteLine( "Unesite novu lozinku :");
                            string newPass= Console.ReadLine();
                            PKM.changePassword(tempacc, newPass, oldPass);

                            break;
                        case 4://brisanje 
                            Console.WriteLine("Unesite navin naloga kojem zelite da izbrisete sifru: ");
                            string deleteAccc = Console.ReadLine();
                            Console.WriteLine("Unesite lozinku:");

                            string deletePass = Console.ReadLine();
                            PKM.deletePassword(deleteAccc, deletePass);
                            break;
                        case 5://citanje lozinke za odredjen acc
                            Console.WriteLine("Unesite naziv naloga za koji zelite da procitate sifru: ");
                            string readAcc = Console.ReadLine();
                            PKM.readPasswordFor(readAcc);

                            
                            break;
                        case 6://citanje svih sifri
                            Console.WriteLine("Vase sifre su");
                            PKM.readAllPassword();
                            break;
                        default:
                            continue;

                         
                            

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
