using CRMProxyService.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CRMProxyService.Services
{
    [ServiceContract]
    public interface IAjaxAccountService
    {
        [OperationContract]
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
