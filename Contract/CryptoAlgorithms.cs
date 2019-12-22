using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public class CryptoAlgorithms
    {
        static string secretKey = "";
        public static void GenerateKey()
        {
            SymmetricAlgorithm symmAlgorithm = DESCryptoServiceProvider.Create();
            secretKey = ASCIIEncoding.ASCII.GetString(symmAlgorithm.Key);
           FileStream fOutput = new FileStream("../../../Key.txt", FileMode.Create, FileAccess.Write);
            byte[] buffer = Encoding.ASCII.GetBytes(secretKey);

            try
            {
                fOutput.Write(buffer, 0, buffer.Length);
            }
            catch (Exception e)
            {
                Console.WriteLine("SecretKeys.StoreKey:: ERROR {0}", e.Message);
            }
            finally
            {
                fOutput.Close();
            }
        }
        public static void EncryptString(string inString, out string  outString)
        {

            FileStream fInput = new FileStream("../../../Key.txt", FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[(int)fInput.Length];

            try
            {
                fInput.Read(buffer, 0, (int)fInput.Length);
            }
            catch (Exception e)
            {
                Console.WriteLine("SecretKeys.LoadKey:: ERROR {0}", e.Message);
            }
            finally
            {
                fInput.Close();
            }
            secretKey = ASCIIEncoding.ASCII.GetString(buffer);
            UTF8Encoding utf8 = new UTF8Encoding();

            byte[] body = utf8.GetBytes(inString.ToCharArray(), 0, inString.Length); //inString.ToArray<byte>();     //image body to be encrypted
            byte[] encrypted = null;

           

            DESCryptoServiceProvider desCrypto = new DESCryptoServiceProvider();
            desCrypto.Key = ASCIIEncoding.ASCII.GetBytes(secretKey);
            desCrypto.Mode = CipherMode.CBC;
           

            
                desCrypto.GenerateIV();

                ICryptoTransform desEncrypt = desCrypto.CreateEncryptor();
            encrypted =desEncrypt.TransformFinalBlock(body, 0, body.Length);



            outString = BitConverter.ToString(encrypted);
        }
        public static void DecryptString(string inString,out  string outString)
        {
            FileStream fInput = new FileStream("../../../Key.txt", FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[(int)fInput.Length];

            try
            {
                fInput.Read(buffer, 0, (int)fInput.Length);
            }
            catch (Exception e)
            {
                Console.WriteLine("SecretKeys.LoadKey:: ERROR {0}", e.Message);
            }
            finally
            {
                fInput.Close();
            }
            secretKey = ASCIIEncoding.ASCII.GetString(buffer);
            UTF8Encoding utf8 = new UTF8Encoding();
            byte[] decrypted = null;
            byte[] body = utf8.GetBytes(inString.ToCharArray(), 0, inString.Length);
       

            DESCryptoServiceProvider desCrypto = new DESCryptoServiceProvider();
            desCrypto.Key = ASCIIEncoding.ASCII.GetBytes(secretKey);
            desCrypto.Mode = CipherMode.CBC;
           // desCrypto.Padding = PaddingMode.None;

         
                desCrypto.IV = body.Take(desCrypto.BlockSize / 8).ToArray();                // take the iv off the beginning of the ciphertext message			

                ICryptoTransform desDecrypt = desCrypto.CreateDecryptor();
            outString =utf8.GetString( desDecrypt.TransformFinalBlock(body, 0, body.Length));
            /***
             *  System.Security.Cryptography.CryptographicException: Length of the data to decrypt is invalid.
                 at System.Security.Cryptography.CryptoAPITransform.TransformFinalBlock(Byte[] inputBuffer, Int32 inputOffset, Int32 inputCount)
                at Contract.CryptoAlgorithms.DecryptString(String inString, String& outString) in 
                D:\4Godina\Bezbednost_Sigurnost\BezbednostProjekat27\Contract\CryptoAlgorithms.cs:line 107
             * 
             * 
             * */

        }



    }
}
