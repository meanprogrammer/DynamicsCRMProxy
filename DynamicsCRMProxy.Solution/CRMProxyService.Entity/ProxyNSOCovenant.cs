using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CRMProxyService.Entity
{
    [DataContract]
    public class ProxyNSOCovenant
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
        [DataMember]
        public Guid ID { get; set; }
        [DataMember]
        public string CovenantType { get; set; }
        [DataMember]
        public string Reference { get; set; }
        [DataMember]
        public string FrequencyOfReview { get; set; }
        [DataMember]
        public string RemarksIssues { get; set; }
        [DataMember]
        public DateTime? DueDate { get; set; }
        [DataMember]
        public string CompliedWith { get; set; }
        [DataMember]
        public int? CompliedWithID { get; set; }
        [DataMember]
        public DateTime? SubmissionDate { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public int? StatusID { get; set; }
    }
}
