using Contract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PKMService
{
    public class Database
    {
      //  public static Dictionary<string, User> AllUsers { get; set; }
        //static string Datapath = (@"Data.xml");

        public static User ReadData( string user)
        {
            User TempUser = null;
            string path = @user + ".xml";
            if (File.Exists(path))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(User));
        
                using (StreamReader sr = new StreamReader(path))
                {
                    
                    TempUser = (User)xmlSerializer.Deserialize(sr);
                    Logger.ServiceReadDataFromDB("PKMService");
                }
               
              
            } //citanje iz neke baze
           
            return TempUser;
        }
        public static void WriteData(User u)
        {
            string path = @u.Username + ".xml";
            if (u != null)
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(User));
                using (StreamWriter sw = new StreamWriter(path))
                {
                    xmlSerializer.Serialize(sw, u);
                    Logger.ServiceWriteDataInDB("PKMService");
                }
            }
            //pisanje u neku bazu
        }
    }
}
