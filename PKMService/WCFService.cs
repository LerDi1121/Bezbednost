using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using Contracts;

namespace PKMService
{
    public class WCFService : IWCFServicePKM
    {
        [PrincipalPermission(SecurityAction.Demand, Role = "NekaDozvola")]

        public void sendMess(string mess)
        {
            Console.WriteLine(mess);
        }
    }
}
