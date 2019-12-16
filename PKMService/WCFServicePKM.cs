using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Contract;
using Contracts;
using SecutityManager;

    namespace PKMService
{
    public class WCFServicePKM : IWCFServicePKM
    {
        [PrincipalPermission(SecurityAction.Demand, Role = "neka")]
        public bool changePassword(string acc, string newPassword, string oldPassword)
        {
            string userName = Formatter.ParseName(Thread.CurrentPrincipal.Identity.Name);
            Console.WriteLine( userName+ " -> changePassword");
            return true;
            //menjanje sifre
        }
        [PrincipalPermission(SecurityAction.Demand, Role = "Delete")]
        public bool deletePassword(string acc, string Password)
        {
            string userName = Formatter.ParseName(Thread.CurrentPrincipal.Identity.Name);
            Console.WriteLine(userName + " -> deletePassword");
            return true;
            //obrisi sifru
        }

        public string readAllPassword()
        {
            string userName = Formatter.ParseName(Thread.CurrentPrincipal.Identity.Name);
            Console.WriteLine(userName + " -> readAllPassword");
            return "";
            //procitati sve sifre
        }

        public string readPasswordFor(string acc)
        {
            string userName = Formatter.ParseName(Thread.CurrentPrincipal.Identity.Name);
            Console.WriteLine(userName + " -> readPasswordFor");
            return "";
            //procitati sifru za taj acc
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "Add")]
        public bool savePassword(string acc, string pass)
        {
            string userName = Formatter.ParseName(Thread.CurrentPrincipal.Identity.Name);
            Console.WriteLine(userName + " -> savePassword");
            return true;
            //dodati sifru u dictionary tog usera

        }

       

        

        public bool SingIn()
        {
            string userName = Formatter.ParseName(Thread.CurrentPrincipal.Identity.Name);
            Console.WriteLine(userName + " -> SingIn");
            return true;
            //logovanje, kao neka funkcija za proveru konekcije, tj neki challenge response
        }

        public bool SingUp()
        {
            string userName = Formatter.ParseName(Thread.CurrentPrincipal.Identity.Name);//trenutno ime klijenta koji pristupa metodi
            Console.WriteLine(userName + " -> SingUp");
            return true;
            //prilikom prvog poziva napraviti usera i dodati u dictionary
        }
    }
}
