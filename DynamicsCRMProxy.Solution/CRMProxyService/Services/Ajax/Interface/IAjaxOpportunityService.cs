using CRMProxyService.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CRMProxyService.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IOpportunityService" in both code and config file together.
    [ServiceContract]
    public interface IAjaxOpportunityService
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        List<ProxyOpportunity> GetAllOpportunity();
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        ProxyOpportunity GetOneOpportunity(Guid id);
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        bool UpdateOpportunity(Guid id, ProxyOpportunity opp);
    }
}
