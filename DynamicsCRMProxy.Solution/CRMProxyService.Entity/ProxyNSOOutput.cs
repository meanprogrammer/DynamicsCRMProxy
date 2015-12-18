using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CRMProxyService.Entity
{
    [DataContract]
    public class ProxyNSOOutput
    {
        [DataMember]
        public Guid ID { get; set; }
        [DataMember]
        public string OutputNo { get; set; }
        [DataMember]
        public string OutputStatement { get; set; }
        [DataMember]
        public string Indicators { get; set; }
        [DataMember]
        public string UnitOfMeasurement { get; set; }
        [DataMember]
        public string BaselineYear { get; set; }
        [DataMember]
        public int BaselineValue { get; set; }
        [DataMember]
        public string AchievedByYear { get; set; }
        [DataMember]
        public double PerformanceTargets { get; set; }
        [DataMember]
        public string Classification { get; set; }
        [DataMember]
        public string AchievementValue { get; set; }
        [DataMember]
        public bool CumulativeValue { get; set; }
        [DataMember]
        public DateTime? ReportingStartDate { get; set; }
        [DataMember]
        public DateTime? ReportingEndDate { get; set; }
        [DataMember]
        public double Value { get; set; }
        [DataMember]
        public string ProgressStatus { get; set; }
        [DataMember]
        public string Assumptions { get; set; }
        [DataMember]
        public string Risks { get; set; }
        [DataMember]
        public DateTime? ModifiedOn { get; set; }
        [DataMember]
        public string RiskAssessmentOfCurrentStatus { get; set; }
        [DataMember]
        public string AssessmentOfCurrentStatus { get; set; }
        /*
        [DataMember]
        public string Problems { get; set; }
        [DataMember]
        public string ActionTaken { get; set; }
        [DataMember]
        public string RecentDevelopment { get; set; }
        [DataMember]
        public DateTime? Date { get; set; }
         */
    }
}
