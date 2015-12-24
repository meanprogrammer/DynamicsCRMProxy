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
        public Guid ID { get; set; }
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
        public string InvolvementInProject { get; set; }

        [DataMember]
        public string Address1_Street1 { get; set; }
        [DataMember]
        public string Address1_Street2 { get; set; }
        [DataMember]
        public string Address1_Street3 { get; set; }
        [DataMember]
        public string Address1_City { get; set; }
        [DataMember]
        public string Address1_StateProvince { get; set; }
        [DataMember]
        public string Address1_ZipCode { get; set; }
        [DataMember]
        public string Address1_CountryRegion { get; set; }

        [DataMember]
        public String ParentID { get; set; }
        [DataMember]
        public String IDstring { get; set; }
    }
}
