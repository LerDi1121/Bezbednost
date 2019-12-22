using Contract;
using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class ClientCertVerification : X509CertificateValidator
    {
        public override void Validate(X509Certificate2 certificate)
        {
            X509Certificate2 srvCert = CertManager.GetCertificateFromStorage(StoreName.My, StoreLocation.LocalMachine,"wcfservice");

            if (!certificate.Issuer.Equals(srvCert.Issuer))// provera da li je izdalo isto lice od poverenja 
            {
                Logger.ClientCertVerificationFailed(certificate.SubjectName.Name,srvCert.SubjectName.Name);
                throw new Exception("Certificate is not from the valid issuer.");
            }
            Logger.ClientCertVerificationSuccess(certificate.SubjectName.Name, srvCert.SubjectName.Name);
        }

    }
}
