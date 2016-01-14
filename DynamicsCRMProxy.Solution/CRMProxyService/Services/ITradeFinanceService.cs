using CRMProxyService.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CRMProxyService.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITradeFinanceService" in both code and config file together.
    [ServiceContract]
    public interface ITradeFinanceService
    {
        void AddTradeFinance(ProxyTradeFinance entity);
        IEnumerable<ProxyTradeFinance> GetAllTradeFinanace();
        ProxyTradeFinance GetOneTradeFinance();
        void UpdateTradeFinance(ProxyTradeFinance eneity);
    }
}
