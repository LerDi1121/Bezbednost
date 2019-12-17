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
        [PrincipalPermission(SecurityAction.Demand, Role = "Modify")]
        public bool changePassword(string acc, string newPassword, string oldPassword)
        {
            string userName = Formatter.ParseName(Thread.CurrentPrincipal.Identity.Name);
            Console.WriteLine( userName+ " -> changePassword");

            if (Database.AllUsers[userName].AccountAndPassword.ContainsKey(acc))
            {
                if (Database.AllUsers[userName].AccountAndPassword[acc] == oldPassword)
                {
                    Database.AllUsers[userName].AccountAndPassword[acc] = newPassword;
                    return true;
                }
            }
            return false;
            //menjanje sifre
        }


        [PrincipalPermission(SecurityAction.Demand, Role = "Delete")]
        public bool deletePassword(string acc, string Password)
        {
            string userName = Formatter.ParseName(Thread.CurrentPrincipal.Identity.Name);
            Console.WriteLine(userName + " -> deletePassword");

            
            if(Database.AllUsers[userName].AccountAndPassword.ContainsKey(acc))
            {
                if(Database.AllUsers[userName].AccountAndPassword[acc] == Password)
                {
                    Database.AllUsers[userName].AccountAndPassword.Remove(acc);
                    return true;
                }
            }

            return false;
            //obrisi sifru
        }

        public string readAllPassword()
        {
            string userName = Formatter.ParseName(Thread.CurrentPrincipal.Identity.Name);
            Console.WriteLine(userName + " -> readAllPassword");

            string str = "";
            
            foreach(var s in Database.AllUsers[userName].AccountAndPassword)
            {
                str += s.Key + "*" + s.Value + "/";
            }
            return str;
            //procitati sve sifre
        }

        public string readPasswordFor(string acc)
        {
            string userName = Formatter.ParseName(Thread.CurrentPrincipal.Identity.Name);
            Console.WriteLine(userName + " -> readPasswordFor");

            if(Database.AllUsers[userName].AccountAndPassword.ContainsKey(acc))
            {
                return Database.AllUsers[userName].AccountAndPassword[acc];
            }
            else
            {
                return "";
            }

            //procitati sifru za taj acc
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "Add")]
        public bool savePassword(string acc, string pass)
        {
            string userName = Formatter.ParseName(Thread.CurrentPrincipal.Identity.Name);
            Console.WriteLine(userName + " -> savePassword");

            if(!Database.AllUsers[userName].AccountAndPassword.ContainsKey(acc))
            {
                Database.AllUsers[userName].AccountAndPassword[acc] = pass;
                return true;
            }
            return false;
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
            if(!Database.AllUsers.ContainsKey(userName))
            {
                User u = new User();
                u.Username = userName;
                Database.AllUsers.Add(userName, u);
                return true;
            }
            return false;          
            //prilikom prvog poziva napraviti usera i dodati u dictionary
        }
    }
}
