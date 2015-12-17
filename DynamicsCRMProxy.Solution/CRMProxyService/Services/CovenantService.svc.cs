using CRMProxyService.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CRMProxyService.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CovenantService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CovenantService.svc or CovenantService.svc.cs at the Solution Explorer and start debugging.
    public class CovenantService : ICovenantService
    {
        public IEnumerable<Entity.ProxySOVCovenant> GetAllSOVCovenant()
        {
            IEnumerable<ProxySOVCovenant> list = new List<ProxySOVCovenant>();
            using (Xrm.XrmServiceContext context = new Xrm.XrmServiceContext("Xrm"))
            {
                list = ObjectConverter.ConvertToSOVCovenant(context.new_covenantsSet.ToList());
            }
            return list;
        }

        public Entity.ProxySOVCovenant GetOneSOVCovenant(Guid id)
        {
            ProxySOVCovenant covenant = null;
            using (Xrm.XrmServiceContext context = new Xrm.XrmServiceContext("Xrm"))
            {
                var c = context.new_covenantsSet.Where(i => i.Id == id).FirstOrDefault();
                if (c != null)
                {
                    covenant = ObjectConverter.SingleConvertToSOVCovenant(c);
                }
            }
            return covenant;
        }

        public IEnumerable<Entity.ProxyNSOCovenant> GetAllNSOCovenant()
        {
            IEnumerable<ProxyNSOCovenant> list = new List<ProxyNSOCovenant>();
            using (Xrm.XrmServiceContext context = new Xrm.XrmServiceContext("Xrm"))
            {
                list = ObjectConverter.ConvertToNSOCovenant(context.new_nsocovenantSet.ToList());
            }
            return list;
        }

        public Entity.ProxyNSOCovenant GetOneNSOCovenant(Guid id)
        {
            ProxyNSOCovenant covenant = null;
            using (Xrm.XrmServiceContext context = new Xrm.XrmServiceContext("Xrm"))
            {
                var c = context.new_nsocovenantSet.Where(i => i.Id == id).FirstOrDefault();
                if (c != null)
                {
                    covenant = ObjectConverter.SingleConvertToNSOCovenant(c);
                }
            }
            return covenant;
        }
    }
}
