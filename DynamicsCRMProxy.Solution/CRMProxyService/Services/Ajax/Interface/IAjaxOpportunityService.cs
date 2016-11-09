using CRMProxyService.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Xrm;

namespace CRMProxyService.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IOpportunityService" in both code and config file together.
    [ServiceContract]
    public interface IAjaxOpportunityService
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        List<ProxyOpportunity> GetAllOpportunity();
        [WebGet(ResponseFormat = WebMessageFormat.Xml)]
        List<Opportunity> GetAllOpportunityRaw();
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetOneOpportunity/{id}")]
        ProxyOpportunity GetOneOpportunity(string id);

        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetNSOHomepageData/{id}")]
        NsoHomepageData GetNSOHomepageData(string id);
        //[OperationContract]
        //[WebGet(ResponseFormat = WebMessageFormat.Json)]
        //bool UpdateOpportunity(Guid id, ProxyOpportunity opp);
    }
}
