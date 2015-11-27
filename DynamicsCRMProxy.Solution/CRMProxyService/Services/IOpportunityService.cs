using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CRMProxyService.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IOpportunityService" in both code and config file together.
    [ServiceContract]
    public interface IOpportunityService
    {
        [OperationContract]
        CustomAccount GetOneAccount(Guid id);
        [OperationContract]
        List<CustomAccount> GetAllAccount();
        [OperationContract]
        List<CustomOpportunity> GetAllOpportunity();
        [OperationContract]
        CustomOpportunity GetOneOpportunity(Guid id);
        [OperationContract]
        bool UpdateOpportunity(Guid id, CustomOpportunity opp);
    }
}
