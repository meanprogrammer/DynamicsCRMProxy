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
                co.OpportunityId = orig.OpportunityId.HasValue ? orig.OpportunityId.Value : Guid.Empty;
                co.Name = orig.Name;
                co.Description = orig.Description;
                co.ProjectDescription = orig.new_ProjectDescription;
                co.ProjectRationale = orig.new_ProjectRationale;
                co.Country = EnsureValueFromOptionSet(orig, "new_country");
                co.Region = EnsureValueFromOptionSet(orig, "new_region");
                co.Sector = EnsureValueFromOptionSet(orig, "new_sector");
                co.SubSector = EnsureValueFromOptionSet(orig, "new_subsector");
                var selectedCurrency = context.TransactionCurrencySet.Where(x => x.TransactionCurrencyId == orig.TransactionCurrencyId.Id).FirstOrDefault();
                co.Currency = selectedCurrency.CurrencyName;
                //new_ApprovalLevel
                co.ApprovalLevel = EnsureValueFromOptionSet(orig, "new_approvallevel");
                //BudgetAmount
                co.BudgetAmount = orig.BudgetAmount.HasValue ? orig.BudgetAmount.Value : 0;
                //new_Guarantee
                co.Guarantee = orig.new_Guarantee.HasValue ? (orig.new_Guarantee.Value ? "Yes" : "No") : string.Empty;
                //new_Borrower
                co.Borrower = orig.new_Borrower;
                //new_CategoryType
                co.CategoryType = EnsureValueFromOptionSet(orig, "new_categorytype");
                //new_ModeofFinancialAssistance
                co.ModeOfFinancialAssistance = EnsureValueFromOptionSet(orig, "new_modeoffinancialassistance");
                //new_ProcessingCategory
                co.ProcessingCategory = EnsureValueFromOptionSet(orig, "new_processingcategory");
                //new_ProcessingScenario
                co.processingScenario = EnsureValueFromOptionSet(orig, "new_processingscenario");
                //new_ProjectStage
                co.ProjectStage = EnsureValueFromOptionSet(orig, "new_projectstage");
                //new_expectedapprovalyear
                co.ExpectedApprovalYear = EnsureValueFromOptionSet(orig, "new_expectedapprovalyear");
                //new_additionalfinancing
                co.AdditionalFinancing = orig.new_AdditionalFinancing.HasValue ? (orig.new_AdditionalFinancing.Value ? "Yes" : "No") : string.Empty;
                //statuscode
                co.ProjectStatus = EnsureValueFromOptionSet(orig, "statuscode");
                co.Department = orig.new_Department;
                co.ClosingDate = orig.EstimatedCloseDate.HasValue ? orig.EstimatedCloseDate.Value : DateTime.MinValue;
                co.Division = orig.new_Division;
                co.DivisionRole = EnsureValueFromOptionSet(orig, "new_divisionrole");

                //co.Agencies = ConvertToProxyAccount(orig.new_opportunity_account.ToList()).ToArray();

                //co.RealOpportunity = orig;
                //co.teams = orig.opportunity_Teams;

                //co.c1 = orig.opportunity_connections1;
                //co.c2 = orig.opportunity_connections2;
            }
            return co;

        }

        private static string EnsureValueFromOptionSet(Microsoft.Xrm.Client.CrmEntity entity, string key)
        {
            if (entity.FormattedValues.ContainsKey(key))
            {
                return entity.FormattedValues[key];
            }
            return string.Empty;
        }

        public static ProxyAccount SingleConvertToProxyAccount(Account account)
        {
            ProxyAccount acct = new ProxyAccount();
            acct.AccountName = account.Name;
            acct.EntityRole = EnsureValueFromOptionSet(account, "new_agencyrole");
            acct.ID = account.Id;
            acct.ParentID = (account.new_opportunity_account != null) ? account.new_opportunity_account.Id.ToString() : Guid.Empty.ToString();
            acct.IDstring = acct.ID.ToString();
            acct.Country = EnsureValueFromOptionSet(account, "new_agencycountry");

            return acct;

        }

        public static List<ProxyAccount> ConvertToProxyAccount(IEnumerable<Account> accounts)
        {
            List<ProxyAccount> results = new List<ProxyAccount>();
            foreach (Account item in accounts)
            {
                /*
                if (item.FormattedValues["new_agencyrole"] != "Executing Agency" && item.FormattedValues["new_agencyrole"] != "Implementing Agency")
                {
                    continue;
                }
                StringBuilder sb = new StringBuilder();
                foreach (var i in item.FormattedValues)
                {
                    sb.Append(string.Format("Key: {0} Value: {1}{2}", i.Key, i.Value, Environment.NewLine));
                }*/

                ProxyAccount acct = SingleConvertToProxyAccount(item);
                results.Add(acct);
            }
            return results;
        }

        public static List<ProxyConnection> ConvertToProxyConnection(IEnumerable<Xrm.Connection> connections)
        {
            List<ProxyConnection> result = new List<ProxyConnection>();
            foreach (Xrm.Connection c in connections)
            {
                ProxyConnection pc = SingleConvertToProxyConnection(c);
                result.Add(pc);
            }
            return result;
        }

        public static ProxyConnection SingleConvertToProxyConnection(Xrm.Connection connection)
        {
            ProxyConnection pc = null;
            if (connection != null)
            {
                pc = new ProxyConnection();
                pc.Name = connection.Name;
                pc.ID = connection.Id;
                pc.Role = connection.Record2RoleId != null ? connection.Record2RoleId.Name : string.Empty;
                pc.OpportunityId = connection.Record1Id != null ? connection.Record1Id.Id.ToString() : Guid.Empty.ToString();
            }
            return pc;
        }

        public static List<ProxyNSOCovenant> ConvertToNSOCovenant(IEnumerable<new_nsocovenant> list)
        {
            List<ProxyNSOCovenant> nsos = new List<ProxyNSOCovenant>();
            foreach (var c in list)
            {
                ProxyNSOCovenant cov = SingleConvertToNSOCovenant(c);
                nsos.Add(cov);
            }
            return nsos;
        }

        public static ProxyNSOCovenant SingleConvertToNSOCovenant(new_nsocovenant nso)
        {
            ProxyNSOCovenant proxyCovenant = new ProxyNSOCovenant();
            proxyCovenant.CovenantDescription = nso.new_Description;
            proxyCovenant.CovenantID = nso.new_nsocovenantId.Value;
            proxyCovenant.Name = nso.new_name;
            proxyCovenant.ParentID = (nso.new_opportunity_new_nsocovenant != null) ? nso.new_opportunity_new_nsocovenant.OpportunityId.Value : Guid.Empty;
            //"__bo4200"
            proxyCovenant.ParentIDString = string.Format("{0}{1}", string.Empty, proxyCovenant.ParentID.ToString());
            proxyCovenant.ID = nso.Id;


            /*
             * [DataMember]
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
        public DateTime SubmissionDate { get; set; }
        [DataMember]
        public string Status { get; set; }
             */
            proxyCovenant.CovenantType = EnsureValueFromOptionSet(nso, "new_type");
            proxyCovenant.Reference = nso.new_Reference;
            proxyCovenant.FrequencyOfReview = EnsureValueFromOptionSet(nso, "new_frequencyofreview");
            proxyCovenant.RemarksIssues = nso.new_RemarksIssues;
            proxyCovenant.DueDate = nso.new_DueDate;
            proxyCovenant.CompliedWith = EnsureValueFromOptionSet(nso, "new_compliedwith");
            proxyCovenant.SubmissionDate = nso.new_SubmissionDate;
            proxyCovenant.Status = EnsureValueFromOptionSet(nso, "new_status");
            return proxyCovenant;
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

        public static List<ProxySOVCovenant> ConvertToSOVCovenant(IEnumerable<new_covenants> covenantList)
        {
            List<ProxySOVCovenant> nsos = new List<ProxySOVCovenant>();
            foreach (var c in covenantList)
            {
                ProxySOVCovenant coventant = SingleConvertToSOVCovenant(c);
                nsos.Add(coventant);
            }
            return nsos;
        }

        public static ProxySOVCovenant SingleConvertToSOVCovenant(new_covenants covenant)
        {

            ProxySOVCovenant proxyCovenant = new ProxySOVCovenant();
            proxyCovenant.CovenantDescription = covenant.new_CovenantDescription;
            proxyCovenant.CovenantID = covenant.new_covenantsId != null ? covenant.new_covenantsId.Value : Guid.Empty;
            proxyCovenant.Name = covenant.new_name;
            proxyCovenant.ParentID = (covenant.new_opportunity_new_covenants != null) ? covenant.new_opportunity_new_covenants.Id : Guid.Empty;
            //"__bo4200"
            proxyCovenant.ParentIDString = string.Format("{0}{1}", string.Empty, proxyCovenant.ParentID.ToString());
            proxyCovenant.ID = covenant.Id;
            proxyCovenant.EffectiveStartDate = covenant.new_EffectiveStartDate;
            proxyCovenant.EffectiveEndDate = covenant.new_EffectiveEndDate;
            proxyCovenant.CovenantType = EnsureValueFromOptionSet(covenant,"new_covenanttype");
            proxyCovenant.DueDate = covenant.new_DueDate;
            proxyCovenant.CompliedDate = covenant.new_CompiledDate;
            proxyCovenant.Rating = covenant.new_Rating;
            proxyCovenant.Remarks = EnsureValueFromOptionSet(covenant, "new_remarks");
            proxyCovenant.ParagraphNo = covenant.new_ParagraphNo;
            proxyCovenant.AgreementSectionNo = covenant.new_AgreementSectionNo;


            return proxyCovenant;
        }
    }
}
