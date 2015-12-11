using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xrm;

namespace CRMProxyService.Entity
{
    public static class ObjectConverter
    {

        public static ProxyOpportunity ConvertToReadableOpportunity(Opportunity orig)
        {
            ProxyOpportunity co = new ProxyOpportunity();
            using (Xrm.XrmServiceContext context = new XrmServiceContext("Xrm"))
            {

                co.Id = orig.Id;
                co.OpportunityId = orig.OpportunityId.Value;
                co.Name = orig.Name;
                co.Description = orig.Description;
                co.ProjectDescription = orig.new_ProjectDescription;
                co.ProjectRationale = orig.new_ProjectRationale;
                co.Country = orig.FormattedValues["new_country"];
                co.Region = orig.FormattedValues["new_region"];
                //co.Sector = orig.FormattedValues["new_Sector"];
                //co.SubSector = orig.FormattedValues["new_subsector"];
                
                var selectedCurrency = context.TransactionCurrencySet.Where(x => x.TransactionCurrencyId == orig.TransactionCurrencyId.Id).FirstOrDefault();
                co.Currency = selectedCurrency.CurrencyName;
                //new_ApprovalLevel
                //TransactionCurrencyId - LU
                //BudgetAmount
                //new_Guarantee
                //new_Borrower
                //new_CategoryType
                //new_ModeofFinancialAssistance
                //new_ProcessingCategory
                //new_ProcessingScenario
                //new_ProjectStage
                //new_expectedapprovalyear
                //new_additionalfinancing
                //statuscode

            }
            return co;

        }

        public static List<ProxyNSOCovenant> ConvertToNSOCovenant(IEnumerable<new_nsocovenant> list)
        {
            List<ProxyNSOCovenant> nsos = new List<ProxyNSOCovenant>();
            foreach (var item in list)
            {
                ProxyNSOCovenant cov = new ProxyNSOCovenant();
                cov.CovenantDescription = item.new_Description;
                cov.CovenantID = item.new_nsocovenantId.Value;
                cov.Name = item.new_name;
                cov.ParentID = (item.new_opportunity_new_nsocovenant != null) ? item.new_opportunity_new_nsocovenant.OpportunityId.Value : Guid.Empty;
                cov.ParentIDString = string.Format("{0}{1}", "__bo4200", cov.ParentID.ToString());
                nsos.Add(cov);
            }
            return nsos;
        }

        public static List<ProxyBaselineProjection> ConvertToBaselineProjection(IEnumerable<new_baselineprojections> list)
        {
            List<ProxyBaselineProjection> bps = new List<ProxyBaselineProjection>();
            foreach (new_baselineprojections item in list)
            {
                ProxyBaselineProjection projection = new ProxyBaselineProjection();
                projection.Id = item.Id;
                projection.Name = item.new_name;
                projection.Year = item.new_Year.Value;
                projection.CA_Q1_A = (double)item.new_CA_Q1Actual;
                projection.CA_Q1_P = (double)item.new_Q1_ca;
                projection.CA_Q2_A = (double)item.new_CA_Q2Actual;
                projection.CA_Q2_P = (double)item.new_Q2_ca;
                projection.CA_Q3_A = (double)item.new_CA_Q3Actual;
                projection.CA_Q3_P = (double)item.new_Q3_ca;
                projection.CA_Q4_A = (double)item.new_CA_Q4Actual;
                projection.CA_Q4_P = (double)item.new_Q4_ca;
                projection.Total_CA_Per_Year_A = (double)item.new_TotalCAperYearActual;
                projection.Total_CA_Per_Year_P = (double)item.new_TotalCAperYear;

                projection.DB_Q1_A = (double)item.new_DB_Q1Actual;
                projection.DB_Q1_P = (double)item.new_Q1_db;
                projection.DB_Q2_A = (double)item.new_DB_Q2Actual;
                projection.DB_Q2_P = (double)item.new_Q2_db;
                projection.DB_Q3_A = (double)item.new_DB_Q3Actual;
                projection.DB_Q3_P = (double)item.new_Q3_db;
                projection.DB_Q4_A = (double)item.new_DB_Q4Actual;
                projection.DB_Q4_P = (double)item.new_Q4_db;
                projection.Total_DB_Per_Year_A = (double)item.new_TotalDisbPerYearActual;
                projection.Total_DB_Per_Year_P = (double)item.new_TotalDisbPerYear;

                projection.ParentID = (item.new_opportunity_new_baselineprojections == null) ? Guid.Empty : item.new_opportunity_new_baselineprojections.Id;
                projection.ParentIDString = string.Format("{0}{1}", "__bo4200", projection.ParentID.ToString());

                bps.Add(projection);
            }
            return bps;
        }

        public static List<ProxySOVCovenant> ConvertToSOVCovenant(IEnumerable<new_covenants> list)
        {
            List<ProxySOVCovenant> nsos = new List<ProxySOVCovenant>();
            foreach (var item in list)
            {
                ProxySOVCovenant cov = new ProxySOVCovenant();
                cov.CovenantDescription = item.new_CovenantDescription;
                cov.CovenantID = item.new_covenantsId.Value;
                cov.Name = item.new_name;
                cov.ParentID = (item.new_opportunity_new_covenants != null) ? item.new_opportunity_new_covenants.Id : Guid.Empty;
                cov.ParentIDString = string.Format("{0}{1}", "__bo4200", cov.ParentID.ToString());
                nsos.Add(cov);
            }
            return nsos;
        }
    }
}
