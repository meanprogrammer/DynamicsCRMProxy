using CRMProxyService.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace CRMProxyService.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAccountService" in both code and config file together.
    [ServiceContract]
    public interface IAccountService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        List<ProxyAccount> GetAllAccounts();

        [OperationContract]
        List<ProxyAccount> GetAllIssuingBanks();

        [OperationContract]
        List<ProxyAccount> GetAllConfirmingBanks();

        [OperationContract]
        ProxyAccount GetOneAccount(Guid id);

        [OperationContract]
        void UpdateOneAccount(ProxyAccount account);

        
    }
}
