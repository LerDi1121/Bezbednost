using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;

namespace Client.Connections
{
    class WCFClientPCM : ChannelFactory<IWCFServicePCM>, IWCFServicePCM, IDisposable
    {
        IWCFServicePCM factory;

        public WCFClientPCM(NetTcpBinding binding, EndpointAddress address)
            : base(binding, address)
        {
            factory = this.CreateChannel();
        }

        public string getPassword(int numOfChar)
        {
            string str= null;
            try
            {
                str=factory.getPassword(9);
                Console.WriteLine("success changePassword.");
               
            }
            catch (SecurityAccessDeniedException e)
            {
                Console.WriteLine("Error while trying to changePassword. Error message : {0}", e.Message);
            }
            return str;
        }

        public string getRndPassword()
        {
            string str = null;
            try
            {
                str = factory.getRndPassword();
                Console.WriteLine("success changePassword.");

            }
            catch (SecurityAccessDeniedException e)
            {
                Console.WriteLine("Error while trying to changePassword. Error message : {0}", e.Message);
            }
            return str;
        }
    }
}
