using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCMService
{
    public class WCFServicePCM : IWCFServicePCM
    {
        public string getPassword(int numOfChar)
        {
            Console.WriteLine("getPassword " +numOfChar);
            return "sadasda";
        }

        public string getRndPassword()
        {
            Console.WriteLine("getRndPassword");
            return "sadasda";
        }
    }
    }

