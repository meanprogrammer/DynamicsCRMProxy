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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ConnectionService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ConnectionService.svc or ConnectionService.svc.cs at the Solution Explorer and start debugging.
    public class MilestoneService : IMilestoneService
    {
        private Xrm.XrmServiceContext xrm = null;
        public MilestoneService()
        {
            this.xrm = new Xrm.XrmServiceContext("Xrm");
        }

        public IEnumerable<ProxyMilestoneEvent> GetAllMilestone()
        {
            return null; // this.xrm.new_milestoneeventSet.ToList();
        }
    }
}
