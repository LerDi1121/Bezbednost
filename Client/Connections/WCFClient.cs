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
                factory.changePassword(acc, newPassword, oldPassword);
                Console.WriteLine("success changePassword.");
                Logger.LogSuccessEvent("proba", "nesto");
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
                factory.deletePassword(acc, Password);
                Console.WriteLine("success deletePassword.");
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
                Console.WriteLine("success readPasswordFor.");
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
                factory.savePassword(acc, pass);
                Console.WriteLine("success savePassword.");
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
