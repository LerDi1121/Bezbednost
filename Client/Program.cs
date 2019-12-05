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
            string address = "net.tcp://localhost:9999/WCFService";

            using (WCFClient proxy = new WCFClient(binding, new EndpointAddress(new Uri(address))))
            {
                while(true)
                {
                    Console.WriteLine("Unesite poruku: \n ");
                    proxy.sendMess( Console.ReadLine());
                    Console.WriteLine("Poruka poslata \n\n");
                }
            }

            Console.ReadLine();
        }
    }
}
