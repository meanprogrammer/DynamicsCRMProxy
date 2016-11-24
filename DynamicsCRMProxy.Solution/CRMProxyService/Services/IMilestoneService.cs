using CRMProxyService.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CRMProxyService.Services
{
    [ServiceContract]
    public interface IMilestoneService
    {
        IEnumerable<ProxyMilestoneEvent> GetAllMilestone();
    }
}
