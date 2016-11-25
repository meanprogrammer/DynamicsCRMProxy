using CRMProxyService.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CRMProxyService.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CofinancingService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CofinancingService.svc or CofinancingService.svc.cs at the Solution Explorer and start debugging.
    public class CofinancingService : ICofinancingService
    {
        Xrm.XrmServiceContext context = null;

        public CofinancingService()
        {
            context = new Xrm.XrmServiceContext();
        }

        public IEnumerable<Entity.ProxyCommercialCofinancing> GetCommercialCofinancing(Guid id)
        {
            return ObjectConverter.ConverToProxyCommercialCofinancing(context.new_commercialcofinancignSet.ToList());
        }
    }
}
