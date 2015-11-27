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
        public List<CustomAccount> GetAllAccount()
        {
            var xrm = new XrmServiceContext("Xrm");
            var all = xrm.AccountSet.ToList();

            List<CustomAccount> accs = new List<CustomAccount>();
            foreach (Xrm.Account item in all)
            {
                CustomAccount converted = ObjectConverter.ConvertToReadableAccount(item);
                accs.Add(converted);
            }
            return accs;
        }

        public CustomAccount GetOneAccount(Guid id)
        {
            var xrm = new XrmServiceContext("Xrm");
            //return 
            Xrm.Account orig = xrm.AccountSet.Where(c => c.Id == id).FirstOrDefault();

            return ObjectConverter.ConvertToReadableAccount(orig);
        }

        public List<CustomOpportunity> GetAllOpportunity()
        {
            var xrm = new XrmServiceContext("Xrm");
            var all = xrm.OpportunitySet.ToList();

            List<CustomOpportunity> accs = new List<CustomOpportunity>();
            foreach (Xrm.Opportunity item in all)
            {
                CustomOpportunity converted = ObjectConverter.ConvertToReadableOpportunity(item);
                accs.Add(converted);
            }
            return accs;
        }

        public CustomOpportunity GetOneOpportunity(Guid id)
        {
            var xrm = new XrmServiceContext("Xrm");
            //return 
            Xrm.Opportunity orig = xrm.OpportunitySet.Where(c => c.Id == id).FirstOrDefault();

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
