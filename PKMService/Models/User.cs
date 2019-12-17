using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKMService
{
    public class User
    {
        public string Username { get; set; }
        public Dictionary<string,string> AccountAndPassword { get; set; }
        public User()
        {
            AccountAndPassword = new Dictionary<string, string>();
        }

    }
}
