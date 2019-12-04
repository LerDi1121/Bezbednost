using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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

        public void sendMess(string mess)
        {
            try
            {
                factory.sendMess(mess);
                Console.WriteLine("Read allowed.");
            }
            catch
            {
                Console.WriteLine("Greska");
            }
         
        }
    }
}
