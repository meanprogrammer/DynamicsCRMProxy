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
            CacheHelper.ClearCache();
            IEnumerable<ProxyNSOOutcome> list = new List<ProxyNSOOutcome>();
            using (Xrm.XrmServiceContext context = new Xrm.XrmServiceContext("Xrm"))
            {
                list = ObjectConverter.ConvertToProxyNSOOutcome(context.new_nsooutcomeSet.ToList());
            }
            return list;
        }

        public Entity.ProxyNSOOutcome GetOneNSOOutcome(Guid id)
        {
            CacheHelper.ClearCache();
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
            CacheHelper.ClearCache();
            IEnumerable<ProxyNSOOutput> list = new List<ProxyNSOOutput>();
            using (Xrm.XrmServiceContext context = new Xrm.XrmServiceContext("Xrm"))
            {
                list = ObjectConverter.ConvertToProxyNSOOutput(context.new_nsooutputSet.ToList());
            }
            return list;
        }

        public Entity.ProxyNSOOutput GetOneNSOOutput(Guid id)
        {
            CacheHelper.ClearCache();
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


        public void UpdateNSOImpact(ProxyNSOImpact impact)
        {
            CacheHelper.ClearCache();
            using (Xrm.XrmServiceContext context = new Xrm.XrmServiceContext("Xrm"))
            {
                var i = (from s in context.new_nsoimpactSet
                         where s.Id == impact.ID
                         select s).FirstOrDefault();
                if (i != null)
                {
                    context.UpdateObject(i);
                    context.SaveChanges();
                }
            }
        }

        public void UpdateNSOOutcome(ProxyNSOOutcome outcome)
        {
            CacheHelper.ClearCache();
            using (Xrm.XrmServiceContext context = new Xrm.XrmServiceContext("Xrm"))
            {
                var o = (from s in context.new_nsooutcomeSet
                         where s.Id == outcome.ID
                         select s).FirstOrDefault();
                if (o != null)
                {
                    context.UpdateObject(o);
                    context.SaveChanges();
                }
            }
        }

        public void UpdateNSOOutput(ProxyNSOOutput output)
        {
            CacheHelper.ClearCache();
            using (Xrm.XrmServiceContext context = new Xrm.XrmServiceContext("Xrm"))
            {
                var o = (from s in context.new_nsooutputSet
                         where s.Id == output.ID
                         select s).FirstOrDefault();
                if (o != null)
                {
                    context.UpdateObject(o);
                    context.SaveChanges();
                }
            }
        }
    }
}
