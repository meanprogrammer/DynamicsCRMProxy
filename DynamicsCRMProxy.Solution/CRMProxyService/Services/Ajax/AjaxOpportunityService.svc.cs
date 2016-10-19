using CRMProxyService.Entity;
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
    public class AjaxOpportunityService : IAjaxOpportunityService
    {
        // To use HTTP GET, add [WebGet] attribute. (Default ResponseFormat is WebMessageFormat.Json)
        // To create an operation that returns XML,
        //     add [WebGet(ResponseFormat=WebMessageFormat.Xml)],
        //     and include the following line in the operation body:
        //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
        private XrmServiceContext xrm = null;
        public AjaxOpportunityService()
        {
            xrm = new XrmServiceContext("Xrm");
        }


        public List<Entity.ProxyOpportunity> GetAllOpportunity()
        {
            List<ProxyOpportunity> accs = new List<ProxyOpportunity>();
            //using (var xrm = new XrmServiceContext("Xrm"))
            //{
            var all = xrm.OpportunitySet;
            foreach (Opportunity item in all)
            {
                ProxyOpportunity converted = ObjectConverter.ConvertToReadableOpportunity(item, this.xrm);
                accs.Add(converted);
            }
            //}
            return accs;
        }

        public Entity.ProxyOpportunity GetOneOpportunity(Guid id)
        {
            //var xrm = new XrmServiceContext("Xrm");
            //return 
            Opportunity orig = this.xrm.OpportunitySet.Where(c => c.Id == id).FirstOrDefault();

            return ObjectConverter.ConvertToReadableOpportunity(orig, this.xrm);
        }

        public bool UpdateOpportunity(Guid id, Entity.ProxyOpportunity opp)
        {
            //var xrm = new XrmServiceContext("Xrm");
            Xrm.Opportunity orig = this.xrm.OpportunitySet.Where(c => c.Id == id).FirstOrDefault();
            orig.Description = opp.Description;
            xrm.Update(orig);
            return true;
        }
    }
}
