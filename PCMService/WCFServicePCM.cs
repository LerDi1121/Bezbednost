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
            const string validLower = "abcdefghijklmnopqrstuvwxyz";
            const string validUper = "ABCDEFGHIJKLMNOPQRSTUVWXY";
            const string validNumber = "Z1234567890";
            const string validSpecial = "`~!@#$%^&*()_+";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();


            int lengthUpper = numOfChar/4;
        
            int lengthNuber = numOfChar / 4;
            int lengthSpecial = numOfChar / 4;
            int lengthLower = numOfChar -(lengthUpper+ lengthNuber+ lengthSpecial);
            while (0 < lengthUpper--)
            {
                res.Append(validLower[rnd.Next(validLower.Length)]);
            }

            while (0 < lengthLower--)
            {
                res.Append(validUper[rnd.Next(validUper.Length)]);
            }

            while (0 < lengthNuber--)
            {
                res.Append(validNumber[rnd.Next(validNumber.Length)]);
            }

            while (0 < lengthSpecial--)
            {
                res.Append(validSpecial[rnd.Next(validSpecial.Length)]);
            }

            return res.ToString();

        }

        public string getRndPassword()
        {
            //rnd pass of 6 character
            const string validLower = "abcdefghijklmnopqrstuvwxyz";
            const string validUper="ABCDEFGHIJKLMNOPQRSTUVWXY";
            const string validNumber = "Z1234567890";
           const string validSpecial="`~!@#$%^&*()_+";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            int lengthUpper = 1;
            int lengthLower = 3;
            int lengthNuber = 1;
            int lengthSpecial = 1;
            while (0 < lengthUpper--)
            {
                res.Append(validLower[rnd.Next(validLower.Length)]);
            }

            while (0 < lengthLower--)
            {
                res.Append(validUper[rnd.Next(validUper.Length)]);
            }

            while (0 < lengthNuber--)
            {
                res.Append(validNumber[rnd.Next(validNumber.Length)]);
            }

            while (0 < lengthSpecial--)
            {
                res.Append(validSpecial[rnd.Next(validSpecial.Length)]);
            }

            return res.ToString();
        }
    }
    }

