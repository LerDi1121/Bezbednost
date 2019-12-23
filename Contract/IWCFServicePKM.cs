using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    [ServiceContract]
    public interface IWCFServicePKM
    {

        [OperationContract]
        bool SignUp();
     
        [OperationContract]
        bool savePassword(string acc, string pass);
        [OperationContract]
        string readAllPassword();
        [OperationContract]
        string readPasswordFor(string acc);
        [OperationContract]
        bool changePassword(string acc,string newPassword, string oldPassword);
        [OperationContract]
        bool deletePassword(string acc, string Password);
    }
}
