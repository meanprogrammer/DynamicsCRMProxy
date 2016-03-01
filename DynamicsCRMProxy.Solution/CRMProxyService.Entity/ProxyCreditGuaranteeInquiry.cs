using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Xrm;

namespace CRMProxyService.Entity
{
    public class ProxyCreditGuaranteeInquiry
    {
        [DataMember]
        public string InquiryReferenceNo { get; set; }
        [DataMember]
        public string IssuingBankName { get; set; }
        [DataMember]
        public string ConfirmingBankName { get; set; }
        [DataMember]
        public string TypeOfTradeTransaction { get; set; }
        [DataMember]
        public int? TypeOfTradeTransactionID { get; set; }
        [DataMember]
        public string ApplicantName { get; set; }
        [DataMember]
        public string BeneficiaryName { get; set; }
        [DataMember]
        public string Tenor { get; set; }
        [DataMember]
        public string Goods { get; set; }
        [DataMember]
        public double? TotalTransactionValue { get; set; }
        [DataMember]
        public double? ADBAmountCovered { get; set; }
        [DataMember]
        public Guid ID { get; set; }
    }
}
