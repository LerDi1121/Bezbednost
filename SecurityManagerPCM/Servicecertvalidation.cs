using Contract;
using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace SecurityManagerPCM
{
   
    public class Servicecertvalidation : X509CertificateValidator
    {
        public override void Validate(X509Certificate2 certificate)
        {
            X509Certificate2 srvCert = CertManager.GetCertificateFromStorage(StoreName.My, StoreLocation.LocalMachine, Formatter.ParseName(WindowsIdentity.GetCurrent().Name));

            if (!certificate.Issuer.Equals(srvCert.Issuer))// provera da li je izdat od istog licca od poverenja posto nam fali jedna validacija
            {
                throw new Exception("Certificate is not from the valid issuer.");
            }

          ///**
          ///U okviru subjectName ispitati da li su isti OU????
          ///


            //ispitivanje da li sertifikat vazi manje od 12 meseci 
            string date =certificate.GetExpirationDateString();
            string[] dates = date.Split('.');
            DateTime val = new DateTime(Int32.Parse(dates[2]), Int32.Parse(dates[1]), Int32.Parse(dates[0]));
            if(val < DateTime.Now.AddMonths(12))
            {
                throw new Exception("The certificate is valid for less than 12 months.");
            }
        }
    }
}
