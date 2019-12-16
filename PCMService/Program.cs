using PCMService.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCMService
{
    class Program
    {
        static void Main(string[] args)
        {
            PCMServiceHost Pkm = new PCMServiceHost();

            Pkm.host.Open();
            Console.WriteLine("WCFService is opened. Press <enter> to finish...");
            Console.ReadLine();

            Pkm.host.Close();
        }
    }
}
