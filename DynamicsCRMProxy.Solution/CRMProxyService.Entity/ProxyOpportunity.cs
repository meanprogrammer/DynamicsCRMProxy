using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CRMProxyService.Entity
{
    [DataContract]
    public class ProxyOpportunity
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public Guid OpportunityId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string ProjectDescription { get; set; }
        [DataMember]
        public string ProjectRationale { get; set; }
        [DataMember]
        public string Region { get; set; }
        [DataMember]
        public string Sector { get; set; }
        [DataMember]
        public string SubSector { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public string Currency { get; set; }
        public List<ProxyNSOCovenant> NSOCovenants { get; set; }
        [DataMember]
        public List<ProxySOVCovenant> SOVCovenants { get; set; }
    }
}
