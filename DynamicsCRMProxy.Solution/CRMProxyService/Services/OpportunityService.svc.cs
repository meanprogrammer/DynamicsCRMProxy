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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "OpportunityService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select OpportunityService.svc or OpportunityService.svc.cs at the Solution Explorer and start debugging.
    public class OpportunityService : IOpportunityService
    {

        public List<ProxyOpportunity> GetAllOpportunity()
        {
            var xrm = new XrmServiceContext("Xrm");
            var all = xrm.OpportunitySet.ToList();

            List<ProxyOpportunity> accs = new List<ProxyOpportunity>();
            foreach (Opportunity item in all)
            {
                CustomOpportunity converted = ObjectConverter.ConvertToReadableOpportunity(item);
                accs.Add(converted);
            }
            return accs;
        }

        public ProxyOpportunity GetOneOpportunity(Guid id)
        {
            var xrm = new XrmServiceContext("Xrm");
            //return 
            Opportunity orig = xrm.OpportunitySet.Where(c => c.Id == id).FirstOrDefault();

            return ObjectConverter.ConvertToReadableOpportunity(orig);
        }

        public bool UpdateOpportunity(Guid id, CustomOpportunity opp)
        {
            var xrm = new XrmServiceContext("Xrm");
            Xrm.Opportunity orig = xrm.OpportunitySet.Where(c => c.Id == id).FirstOrDefault();
            orig.Description = opp.Description;
            xrm.Update(orig);
            return true;
        }
    }
}
