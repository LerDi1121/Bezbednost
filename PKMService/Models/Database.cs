using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKMService
{
    public class Database
    {
        public static Dictionary<string, User> AllUsers { get; set; }

        
        public void ReadData()
        {
            //citanje iz neke baze
        }
        public void WriteData()
        {
            //pisanje u neku bazu
        }
    }
}
