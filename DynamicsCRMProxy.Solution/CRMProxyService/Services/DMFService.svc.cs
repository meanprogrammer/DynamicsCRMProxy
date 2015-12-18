using CRMProxyService.Entity;
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

        public IEnumerable<ProxyNSOImpact> GetAllNSOImpact()
        {
            IEnumerable<ProxyNSOImpact> list = new List<ProxyNSOImpact>();
            using (Xrm.XrmServiceContext context = new Xrm.XrmServiceContext("Xrm"))
            {
                list = ObjectConverter.ConvertToProxyNSOImpact(context.new_nsoimpactSet);
            }
            return list;
        }

        public Entity.ProxyNSOImpact GetOneNSOImpact(Guid id)
        {
            ProxyNSOImpact proxy = null;
            using (Xrm.XrmServiceContext context = new Xrm.XrmServiceContext("Xrm"))
            {
                var p = context.new_nsoimpactSet.Where(c => c.Id == id).FirstOrDefault();
                if (p != null)
                {
                    proxy = ObjectConverter.SingleConvertToProxyNSOImpact(p);
                }
            }
            return proxy;
        }

        public IEnumerable<ProxyNSOOutcome> GetAllNSOOutcome()
        {
            ProxyNSOOutcome proxy = null;
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
