using CRMProxyService.Entity;
using CRMProxyService.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.UI;
using Xrm;

namespace CRMProxyService.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TradeFinanceService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TradeFinanceService.svc or TradeFinanceService.svc.cs at the Solution Explorer and start debugging.
    public class TradeFinanceService : ITradeFinanceService
    {

        public void AddTradeFinance(Entity.ProxyCreditGuaranteeInquiry entity)
        {
            //CacheHelper.ClearCache();
            using (var context = new Xrm.XrmServiceContext("Xrm"))
            {
                new_creditguaranteerequest payload = CRMProxyService.Entity.ObjectConverter.CreateFromProxy(entity);
                context.AddObject(payload);
                context.SaveChanges();
            }
        }

        public IEnumerable<Entity.ProxyCreditGuaranteeInquiry> GetAllTradeFinanace()
        {
            CacheHelper.ClearCache();
            IEnumerable<ProxyCreditGuaranteeInquiry> list = new List<ProxyCreditGuaranteeInquiry>();
            using (Xrm.XrmServiceContext context = new Xrm.XrmServiceContext("Xrm"))
            {
                list = CRMProxyService.Entity.ObjectConverter.ConvertToProxyCreditGuaranteeInquiry(context.new_creditguaranteerequestSet.ToList());
            }
            return list;
        }

        public Entity.ProxyCreditGuaranteeInquiry GetOneTradeFinance(Guid id)
        {
            CacheHelper.ClearCache();
            ProxyCreditGuaranteeInquiry covenant = null;
            using (Xrm.XrmServiceContext context = new Xrm.XrmServiceContext("Xrm"))
            {
                var c = context.new_creditguaranteerequestSet.Where(i => i.Id == id).FirstOrDefault();
                if (c != null)
                {
                    covenant = CRMProxyService.Entity.ObjectConverter.SingleConvertToProxyCreditGuaranteeInquiry(c);
                }
            }
            return covenant;
        }

        public void UpdateTradeFinance(Entity.ProxyCreditGuaranteeInquiry entity)
        {
            
        }
    }
}
