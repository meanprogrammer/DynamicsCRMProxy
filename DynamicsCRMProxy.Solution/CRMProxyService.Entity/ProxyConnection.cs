using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CRMProxyService.Entity
{
    [DataContract]
    public class ProxyConnection
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string OpportunityId { get; set; }

        [DataMember]
        public Guid ID { get; set; }

        [DataMember]
        public string Role { get; set; }
    }
}
