using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Contract;
using Contracts;
using PKMService.Models;
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
            User TempUser = Database.ReadData(userName);
            if (TempUser == null)
            {
                throw new FieldAccessException("Please sign up");
            }

            foreach(AccAndPass ap in TempUser.AccountAndPassword)
            {
                if(ap.Key.Equals(acc) && ap.Value.Equals(oldPassword))
                {
                    TempUser.AccountAndPassword.Remove(ap);
                    ap.Value = newPassword;
                    TempUser.AccountAndPassword.Add(ap);
                    Database.WriteData(TempUser);
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
            User TempUser = Database.ReadData(userName);
            if (TempUser == null)
            {
                throw new FieldAccessException("Please sign up");
            }

            foreach (AccAndPass ap in TempUser.AccountAndPassword)
            {
                if (ap.Key.Equals(acc) && ap.Value.Equals(Password))
                {
                    TempUser.AccountAndPassword.Remove(ap);
                 
                    Database.WriteData(TempUser);
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
            User TempUser = Database.ReadData(userName);
            if (TempUser == null)
            {
                throw new FieldAccessException("Please sign up");
            }

            foreach (var s in TempUser.AccountAndPassword)
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

            User TempUser = Database.ReadData(userName);
            if (TempUser == null)
            {
                throw new FieldAccessException("Please sign up");
            }

            foreach (AccAndPass ap in TempUser.AccountAndPassword)
            {
                if (ap.Key.Equals(acc))
                
                    return ap.Value ;

                
            } 

             return "";
            

            //procitati sifru za taj acc
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "Add")]
        public bool savePassword(string acc, string pass)
        {
            string userName = Formatter.ParseName(Thread.CurrentPrincipal.Identity.Name);
            Console.WriteLine(userName + " -> savePassword");

            User TempUser = Database.ReadData(userName);
            if (TempUser == null)
            {
                throw new FieldAccessException("Please sign up");
            }


            foreach (AccAndPass ap in TempUser.AccountAndPassword)
            {
                if (ap.Key.Equals(acc))
                    return false;
            }
            AccAndPass temp = new AccAndPass();
            temp.Key = acc;
            temp.Value = pass;
            TempUser.AccountAndPassword.Add(temp);

            Database.WriteData(TempUser);
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
            User u = Database.ReadData(userName);
            if(u==null)
            {
                u = new User();
                u.Username = userName;
                Database.WriteData(u);
                return true;
            }
          
            return false;          
            //prilikom prvog poziva napraviti usera i dodati u dictionary
        }
    }
}
