using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CRMProxyService.Entity
{
    [DataContract]
    public class ProxyAccount
    {
        [DataMember]
        public string AccountName { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public string Fax { get; set; }
        [DataMember]
        public string Website { get; set; }
        [DataMember]
        public string EntityRole { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public string Address { get; set; }
    }
}
