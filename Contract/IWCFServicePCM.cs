using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public interface IWCFServicePCM
    {
        [OperationContract]
        string getRndPassword();
        [OperationContract]
        string getPassword(int numOfChar);
    }
}
