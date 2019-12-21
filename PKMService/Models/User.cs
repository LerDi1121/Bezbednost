using PKMService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKMService
{
    [Serializable]
    public class User
    {
        public string Username { get; set; }
        public List<AccAndPass> AccountAndPassword { get; set; }
        public User()
        {
            AccountAndPassword = new List<AccAndPass>();
        }

    }
}
