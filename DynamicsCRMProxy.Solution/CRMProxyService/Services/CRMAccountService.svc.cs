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
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(AddressFilterMode = AddressFilterMode.Any)]
    public class CRMAccountService : ICRMAccountService
    {
        // To use HTTP GET, add [WebGet] attribute. (Default ResponseFormat is WebMessageFormat.Json)
        // To create an operation that returns XML,
        //     add [WebGet(ResponseFormat=WebMessageFormat.Xml)],
        //     and include the following line in the operation body:
        //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";

        public List<ProxyAccount> GetAllAccounts()
        {
            CacheHelper.ClearCache();
            var xrm = new XrmServiceContext("Xrm");
            return ObjectConverter.ConvertToProxyAccount(xrm.AccountSet.ToList());
        }

        public List<ProxyAccount> GetAllIssuingBanks()
        {
            CacheHelper.ClearCache();
            var xrm = new XrmServiceContext("Xrm");
            return ObjectConverter.ConvertToProxyAccount(xrm.AccountSet.ToList().Where(c => c.new_AgencyRole == 100000014));
        }

        public List<ProxyAccount> GetAllConfirmingBanks()
        {
            CacheHelper.ClearCache();
            var xrm = new XrmServiceContext("Xrm");
            return ObjectConverter.ConvertToProxyAccount(xrm.AccountSet.ToList().Where(c => c.new_AgencyRole == 100000013));
        }

        public ProxyAccount GetOneAccount(Guid id)
        {
            CacheHelper.ClearCache();
            var xrm = new XrmServiceContext("Xrm");
            Account ac = xrm.AccountSet.Where(x => x.Id == id).FirstOrDefault();
            return ObjectConverter.SingleConvertToProxyAccount(ac);
        }


        public void UpdateOneAccount(ProxyAccount account)
        {

        }
    }
}
