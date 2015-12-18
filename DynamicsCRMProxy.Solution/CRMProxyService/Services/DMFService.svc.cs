using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CRMProxyService.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DMFService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DMFService.svc or DMFService.svc.cs at the Solution Explorer and start debugging.
    public class DMFService : IDMFService
    {

        public IEnumerable<Entity.ProxyNSOImpact> GetAllNSOImpact()
        {
            using (Xrm.XrmServiceContext context = new Xrm.XrmServiceContext("Xrm"))
            { 
            }
            return null;
        }

        public Entity.ProxyNSOImpact GetOneNSOImpact(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Entity.ProxyNSOOutcome> GetAllNSOOutcome()
        {
            using (Xrm.XrmServiceContext context = new Xrm.XrmServiceContext("Xrm"))
            {
            }
            return null;
        }

        public Entity.ProxyNSOOutcome GetOneNSOOutcome(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Entity.ProxyNSOOutput> GetAllNSOOutput()
        {
            using (Xrm.XrmServiceContext context = new Xrm.XrmServiceContext("Xrm"))
            {
            }
            return null;
        }

        public Entity.ProxyNSOOutput GetOneNSOOutput(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
