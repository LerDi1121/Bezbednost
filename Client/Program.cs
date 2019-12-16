using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            NetTcpBinding binding = new NetTcpBinding();
            string address = "net.tcp://localhost:9999/WCFServicePKM";

            using (WCFClient proxy = new WCFClient(binding, new EndpointAddress(new Uri(address))))
            {   proxy.SingUp();
                    proxy.SingIn();
                    proxy.savePassword("facebook", "nesto");
                    proxy.deletePassword("facebook", "nesto");
                    proxy.changePassword("facebook", "nesto", "nesto");
                    proxy.readAllPassword();
                    proxy.readPasswordFor("facebook");


            }

            Console.ReadLine();
        }
    }
}
