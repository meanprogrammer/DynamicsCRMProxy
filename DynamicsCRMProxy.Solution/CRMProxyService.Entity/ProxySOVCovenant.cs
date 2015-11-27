using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CRMProxyService.Entity
{
    [DataContract]
    public class ProxySOVCovenant
    {
            [DataMember]
            public string CovenantDescription { get; set; }
            [DataMember]
            public Guid CovenantID { get; set; }
            [DataMember]
            public string Name { get; set; }
            [DataMember]
            public Guid ParentID { get; set; }
            [DataMember]
            public string ParentIDString { get; set; }
    }
}
