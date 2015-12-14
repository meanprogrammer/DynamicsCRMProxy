using CRMProxyService.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Xrm;

namespace CRMProxyService.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AccountService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AccountService.svc or AccountService.svc.cs at the Solution Explorer and start debugging.
    public class AccountService : IAccountService
    {

        public List<ProxyAccount> GetAllAccounts()
        {
            var xrm = new XrmServiceContext("Xrm");
            return ObjectConverter.ConvertToProxyAccount(xrm.AccountSet.ToList());
        }


        public ProxyAccount GetOneAccount(Guid id)
        {
            var xrm = new XrmServiceContext("Xrm");
            Account ac = xrm.AccountSet.Where(x => x.Id == id).FirstOrDefault();
            return ObjectConverter.SingleConvertToProxyAccount(ac);
        }
    }
}
