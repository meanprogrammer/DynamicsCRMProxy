using CRMProxyService.Entity;
using CRMProxyService.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using Xrm;

namespace CRMProxyService.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AccountService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AccountService.svc or AccountService.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class AccountService : IAccountService
    {
        private XrmServiceContext xrm = null;
        public AccountService()
        {
            xrm = new XrmServiceContext("Xrm");
        }

        public List<ProxyAccount> GetAllAccounts()
        {
            CacheHelper.ClearCache();
            return ObjectConverter.ConvertToProxyAccount(this.xrm.AccountSet);
        }

        public List<ProxyAccount> GetAllIssuingBanks()
        {
            CacheHelper.ClearCache();
            return ObjectConverter.ConvertToProxyAccount(this.xrm.AccountSet.Where(c => c.new_AgencyRole == 100000014));
        }

        public List<ProxyAccount> GetAllConfirmingBanks()
        {
            CacheHelper.ClearCache();
            return ObjectConverter.ConvertToProxyAccount(this.xrm.AccountSet.Where(c => c.new_AgencyRole == 100000013));
        }

        public ProxyAccount GetOneAccount(Guid id)
        {
            CacheHelper.ClearCache();
            Account ac = this.xrm.AccountSet.Where(x => x.Id == id).FirstOrDefault();
            return ObjectConverter.SingleConvertToProxyAccount(ac);
        }


        public void UpdateOneAccount(ProxyAccount account)
        {
           
        }
    }
}
