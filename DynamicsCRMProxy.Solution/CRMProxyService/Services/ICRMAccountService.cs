using CRMProxyService.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace CRMProxyService.Services
{
    [ServiceContract]
    public interface ICRMAccountService
    {
        [OperationContract]
        List<ProxyAccount> GetAllAccounts();

        [OperationContract]
        [WebGet]
        List<ProxyAccount> GetAllIssuingBanks();

        [OperationContract]
        List<ProxyAccount> GetAllConfirmingBanks();

        [OperationContract]
        ProxyAccount GetOneAccount(Guid id);

        [OperationContract]
        void UpdateOneAccount(ProxyAccount account);
    }
}
