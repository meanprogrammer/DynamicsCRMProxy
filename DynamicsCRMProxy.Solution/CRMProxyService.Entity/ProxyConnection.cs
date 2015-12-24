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
        [DataMember]
        public string Fullname { get; set; }
        [DataMember]
        public string JobTitle { get; set; }
        [DataMember]
        public string AccountName { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string BusinessPhone { get; set; }
        [DataMember]
        public string MobilePhone { get; set; }
        [DataMember]
        public string Fax { get; set; }
        [DataMember]
        public string PreferedMethodofContact { get; set; }
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
    }
}
