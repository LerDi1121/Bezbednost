using Contract;
using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class WCFClient : ChannelFactory<IWCFServicePKM>, IWCFServicePKM, IDisposable
    {
        IWCFServicePKM factory;

        public WCFClient(NetTcpBinding binding, EndpointAddress address)
            : base(binding, address)
        {
            factory = this.CreateChannel();
        }

        public bool changePassword(string acc, string newPassword, string oldPassword)
        {

            try
            {
               
                if (factory.changePassword(acc, newPassword, oldPassword))
                {
                    Console.WriteLine("password successfully changed");
                }
                else
                {
                    Console.WriteLine("password didn't change successfully");
                }
              //  Logger.LogSuccessEvent("proba", "nesto");
                return true;
            }
            catch (SecurityAccessDeniedException e)
            {
                Console.WriteLine("Error while trying to changePassword. Error message : {0}", e.Message);
            }
            return false;

           
        }

        public bool deletePassword(string acc, string Password)
        {
            try
            {
                
                if(factory.deletePassword(acc, Password))
                {
                    Console.WriteLine("Password deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Password wasn't deleted successfully.");
                }
                return true;
            }

            catch (SecurityAccessDeniedException e)
            {
                Console.WriteLine("Error while trying to deletePassword. Error message : {0}", e.Message);
            }
            return false;
           
        }

        public string readAllPassword()
        {
            string pass = null;
            try
            {
                pass = factory.readAllPassword();
                Console.WriteLine("success readAllPassword.");
                string[] accPass = pass.Split('/');
                foreach (var item in accPass)
                {
                    if (item == "")
                        break;
                    Console.WriteLine("Acc: " + item.Split('*')[0] +" -> " + item.Split('*')[1]);
                }
                return pass;
            }
            catch (SecurityAccessDeniedException e)
            {
                Console.WriteLine("Error while trying to readAllPassword. Error message : {0}", e.Message);
            }
            return pass;
           
        }

        public string readPasswordFor(string acc)
        {
            string pass= null;
            try
            {
                pass=factory.readPasswordFor(acc);
                if(pass =="")
                {
                    return "";
                }
                Console.WriteLine("Pass for "+acc+" : " +pass);
                return pass;
            }
            catch (SecurityAccessDeniedException e)
            {
                Console.WriteLine("Error while trying to readPasswordFor. Error message : {0}", e.Message);
            }
            return pass;


            
        }

        public bool savePassword(string acc, string pass)
        {
             
            try
            {
                if (factory.savePassword(acc, pass))
                {
                    Console.WriteLine("New password saved successfully.");
                }
                else
                {
                    Console.WriteLine("New password wasn't saved successfully.");
                }
               
                return true;
            }
            catch (SecurityAccessDeniedException e)
            {
                Console.WriteLine("Error while trying to savePassword. Error message : {0}", e.Message);
            }
            return false;
        }


        public bool SingIn()
        {
            try
            {
                factory.SingIn();
                Console.WriteLine("success singin.");
                return true;
            }
            catch (SecurityAccessDeniedException e)
            {
                Console.WriteLine("Error while trying to singin. Error message : {0}", e.Message);
            }
            return false;
        }

        public bool SingUp()
        {
           
            try
            {
                factory.SingUp();
                Console.WriteLine("success singup.");
           //     Logger.AuthenticationSuccess("Client");
                return true;
            }
            catch (SecurityAccessDeniedException e)
            {
                Console.WriteLine("Error while trying to singup. Error message : {0}", e.Message);
            }
            return false;
        }
    }
}
