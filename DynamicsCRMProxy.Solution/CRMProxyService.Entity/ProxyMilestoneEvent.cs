using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CRMProxyService.Entity
{
    public class ProxyMilestoneEvent
    {
        [DataMember]
        public string PRFApproval { get; set; }
        [DataMember]
        public string CRPICM { get; set; }
        [DataMember]
        public string LetterOfNoObjection { get; set; }
        [DataMember]
        public string FinalReviewICM { get; set; }
        [DataMember]
        public string RRPApproval { get; set; }
        [DataMember]
        public string SigningDate { get; set; }
        [DataMember]
        public string EffectivenessDate { get; set; }
        [DataMember]
        public string XARRDate { get; set; }
        [DataMember]
        public string ProjectEndDate { get; set; }
    }
}
