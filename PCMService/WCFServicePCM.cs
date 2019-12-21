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
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890`~!@#$%^&*()_+";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < numOfChar--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
            return numOfChar.ToString();
        }

        public string getRndPassword()
        {
            //StringBuilder builder = new StringBuilder();
            //Random random = new Random();
            //char ch;
            //for (int i = 0; i < 6; i++)
            //{
            //    ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
            //    builder.Append(ch);
            //} 
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXY";
            const string valid2 = "Z1234567890`~!@#$%^&*()_+";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            int length = 4;
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            int length2 = 4;
            while (0 < length2--)
            {
                res.Append(valid2[rnd.Next(valid2.Length)]);
            }
            return res.ToString();
         
        }
    }
    }

