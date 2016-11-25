using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMProxyService.Entity
{
    public class ProxyCommercialCofinancing
    {
        public string RelatedFacility { get; set; }
        public string CofinancingCategory { get; set; }
        public string ConfinancingSubCategory { get; set; }
        public string CofinancingType { get; set; }
        public string CofinanceSource { get; set; }
        public int Amount { get; set; }
        public string Status { get; set; }
    }
}
