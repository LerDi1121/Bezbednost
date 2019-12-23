using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCMService
{
    public class WCFServicePCM : IWCFServicePCM
    {
        public string getPassword(int numOfChar)
        {
            string userName = Formatter.ParseName(Thread.CurrentPrincipal.Identity.Name);
            int min= Int32.Parse(  Resource1.minLength);
            if (numOfChar < min)
            {
                Logger.GetRandomPasswordFailed(userName, "User is not signed up.");
                throw new ArgumentException("Minimum password length is 6 characters ");
            }
            const string validLower = "abcdefghijklmnopqrstuvwxyz";
            const string validUper = "ABCDEFGHIJKLMNOPQRSTUVWXY";
            const string validNumber = "Z1234567890";
            const string validSpecial = "`~!@#$%^&*()_+";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();


            int lengthUpper = numOfChar/5;
            int lengthNuber = numOfChar / 5;
            int lengthSpecial = numOfChar / 5;
            int lengthLower = numOfChar -(lengthUpper+ lengthNuber+ lengthSpecial);
            while (0 < lengthLower--)
            {
                res.Append(validLower[rnd.Next(validLower.Length)]);
            }

            while (0 < lengthUpper--)
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
            Logger.GetRandomPasswordSuccess(userName);

            return res.ToString();

        }

        public string getRndPassword()
        {
            //rnd pass of 8 character
            int def =int.Parse (Resource1.defaultLength);
            const string validLower = "abcdefghijklmnopqrstuvwxyz";
            const string validUper="ABCDEFGHIJKLMNOPQRSTUVWXY";
            const string validNumber = "Z1234567890";
           const string validSpecial="`~!@#$%^&()_+";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            int lengthUpper = def/5;
            int lengthNuber = def/5;
            int lengthSpecial = def / 5; 
            int lengthLower = def - (lengthUpper + lengthNuber + lengthSpecial);
            while (0 < lengthLower--)
            {
                res.Append(validLower[rnd.Next(validLower.Length)]);
            }

            while (0 < lengthUpper--)
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
            string userName = Formatter.ParseName(Thread.CurrentPrincipal.Identity.Name);
            Logger.GetRandomPasswordSuccess(userName);

            return res.ToString();
        }
    }
    }

