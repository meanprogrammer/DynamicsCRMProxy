using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CRMProxyService.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TradeFinanceService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TradeFinanceService.svc or TradeFinanceService.svc.cs at the Solution Explorer and start debugging.
    public class TradeFinanceService : ITradeFinanceService
    {

        public void AddTradeFinance(Entity.ProxyTradeFinance entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Entity.ProxyTradeFinance> GetAllTradeFinanace()
        {
            throw new NotImplementedException();
        }

        public Entity.ProxyTradeFinance GetOneTradeFinance()
        {
            throw new NotImplementedException();
        }

        public void UpdateTradeFinance(Entity.ProxyTradeFinance eneity)
        {
            throw new NotImplementedException();
        }
    }
}
