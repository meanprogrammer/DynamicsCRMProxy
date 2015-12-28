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
        [DataMember]
        public Guid ID { get; set; }
        [DataMember]
        public DateTime? EffectiveStartDate { get; set; }
        [DataMember]
        public DateTime? EffectiveEndDate { get; set; }
        [DataMember]
        public string CovenantType { get; set; }
        [DataMember]
        public DateTime? DueDate { get; set; }
        [DataMember]
        public DateTime? CompliedDate { get; set; }
        [DataMember]
        public string Rating { get; set; }
        [DataMember]
        public string Remarks { get; set; }
        [DataMember]
        public int? ParagraphNo { get; set; }
        [DataMember]
        public double? AgreementSectionNo { get; set; }
        /*
        [DataMember]
        public List<Xrm.DynamicPropertyOptionSetItem> optionset { get; set; }*/
        [DataMember]
        public Xrm.new_covenants att { get; set; }
    }
}
