using CRMProxyService.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CRMProxyService.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICovenantService" in both code and config file together.
    [ServiceContract]
    public interface ICovenantService
    {
        [OperationContract]
        IEnumerable<ProxySOVCovenant> GetAllSOVCovenant();

        [OperationContract]
        ProxySOVCovenant GetOneSOVCovenant(Guid id);

        [OperationContract]
        void UpdateSOVCovenant(ProxySOVCovenant covenant);

        [OperationContract]
        IEnumerable<ProxyNSOCovenant> GetAllNSOCovenant();

        [OperationContract]
        ProxyNSOCovenant GetOneNSOCovenant(Guid id);

        [OperationContract]
        void UpdateNSOCovenant(ProxyNSOCovenant covenant);
    }
}
