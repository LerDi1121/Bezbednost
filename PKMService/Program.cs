using Contract;
using Contracts;
using PKMService.Connection;
using SecutityManager;
using System;
using System.Collections.Generic;
using System.IdentityModel.Policy;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PKMService
{
    class Program
    {
        static void Main(string[] args)
        {

            CryptoAlgorithms.GenerateKey();
            PKMServiceHost Pkm = new PKMServiceHost();

            Pkm.host.Open();

            string userName = Formatter.ParseName(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            Console.WriteLine(userName + "  server");
            Console.WriteLine("WCFService is opened. Press <enter> to finish...");
            Console.ReadLine();

            Pkm.host.Close();
        }
    }
}
