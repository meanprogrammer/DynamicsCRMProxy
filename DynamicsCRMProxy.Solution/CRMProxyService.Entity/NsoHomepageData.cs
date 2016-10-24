using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CRMProxyService.Entity
{
    [DataContract]
    public class NsoHomepageData
    {
        [DataMember]
        public ProxyOpportunity Project { get; set; }

        [DataMember]
        public IEnumerable<ProxyAccount> Agencies { get; set; }

        [DataMember]
        public IEnumerable<ProxyAccount> CSO { get; set; }

        [DataMember]
        public IEnumerable<ProxyConnection> ProjectTeam { get; set; }

    }
}
