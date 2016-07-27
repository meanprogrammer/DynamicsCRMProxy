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
    public interface IAjaxAccountService
    {
        [OperationContract]
        List<ProxyAccount> GetAllAccounts();

        [OperationContract]
        [WebGet(ResponseFormat=WebMessageFormat.Json)]
        List<ProxyAccount> GetAllIssuingBanks();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        List<ProxyAccount> GetAllConfirmingBanks();

        [OperationContract]
        ProxyAccount GetOneAccount(Guid id);

        [OperationContract]
        void UpdateOneAccount(ProxyAccount account);
    }
}
