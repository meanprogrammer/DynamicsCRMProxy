using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CRMProxyService.Entity
{
    [DataContract]
    public class ProxyBaselineProjection
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Year { get; set; }
        [DataMember]
        public Guid ParentID { get; set; }
        [DataMember]
        public string ParentIDString { get; set; }

        [DataMember]
        public double CA_Q1_P { get; set; }
        [DataMember]
        public double CA_Q1_A { get; set; }
        [DataMember]
        public double CA_Q2_P { get; set; }
        [DataMember]
        public double CA_Q2_A { get; set; }
        [DataMember]
        public double CA_Q3_P { get; set; }
        [DataMember]
        public double CA_Q3_A { get; set; }
        [DataMember]
        public double CA_Q4_P { get; set; }
        [DataMember]
        public double CA_Q4_A { get; set; }
        [DataMember]
        public double Total_CA_Per_Year_P { get; set; }
        [DataMember]
        public double Total_CA_Per_Year_A { get; set; }


        [DataMember]
        public double DB_Q1_P { get; set; }
        [DataMember]
        public double DB_Q1_A { get; set; }
        [DataMember]
        public double DB_Q2_P { get; set; }
        [DataMember]
        public double DB_Q2_A { get; set; }
        [DataMember]
        public double DB_Q3_P { get; set; }
        [DataMember]
        public double DB_Q3_A { get; set; }
        [DataMember]
        public double DB_Q4_P { get; set; }
        [DataMember]
        public double DB_Q4_A { get; set; }
        [DataMember]
        public double Total_DB_Per_Year_P { get; set; }
        [DataMember]
        public double Total_DB_Per_Year_A { get; set; }
    }
}
