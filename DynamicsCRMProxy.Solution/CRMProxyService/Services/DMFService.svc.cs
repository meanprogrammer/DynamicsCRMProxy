using CRMProxyService.Entity;
using CRMProxyService.Helper;
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
            CacheHelper.ClearCache();
            IEnumerable<ProxyNSOImpact> list = new List<ProxyNSOImpact>();
            using (Xrm.XrmServiceContext context = new Xrm.XrmServiceContext("Xrm"))
            {
                list = ObjectConverter.ConvertToProxyNSOImpact(context.new_nsoimpactSet);
            }
            return list;
        }

        public Entity.ProxyNSOImpact GetOneNSOImpact(Guid id)
        {
            CacheHelper.ClearCache();
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
            IEnumerable<ProxyNSOOutcome> list = new List<ProxyNSOOutcome>();
            using (Xrm.XrmServiceContext context = new Xrm.XrmServiceContext("Xrm"))
            {
                list = ObjectConverter.ConvertToProxyNSOOutcome(context.new_nsooutcomeSet.ToList());
            }
            return list;
        }

        public Entity.ProxyNSOOutcome GetOneNSOOutcome(Guid id)
        {
            ProxyNSOOutcome proxy = null;
            using (Xrm.XrmServiceContext context = new Xrm.XrmServiceContext("Xrm"))
            {
                var o = context.new_nsooutcomeSet.Where(c => c.Id == id).FirstOrDefault();
                if (o != null)
                {
                    proxy = ObjectConverter.SingleConvertToProxyNSOOutcome(o);
                }
            }
            return proxy;
        }

        public IEnumerable<Entity.ProxyNSOOutput> GetAllNSOOutput()
        {
            IEnumerable<ProxyNSOOutput> list = new List<ProxyNSOOutput>();
            using (Xrm.XrmServiceContext context = new Xrm.XrmServiceContext("Xrm"))
            {
                list = ObjectConverter.ConvertToProxyNSOOutput(context.new_nsooutputSet.ToList());
            }
            return list;
        }

        public Entity.ProxyNSOOutput GetOneNSOOutput(Guid id)
        {
            ProxyNSOOutput proxy = null;
            using (Xrm.XrmServiceContext context = new Xrm.XrmServiceContext("Xrm"))
            {
                var o = context.new_nsooutputSet.Where(c => c.Id == id).FirstOrDefault();
                if (o != null)
                {
                    proxy = ObjectConverter.SingleConvertToProxyNSOOutput(o);
                }
            }
            return proxy;
        }
    }
}
