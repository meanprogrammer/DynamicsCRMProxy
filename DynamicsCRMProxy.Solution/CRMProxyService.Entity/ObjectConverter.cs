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
        public static ProxyOpportunity ConvertToReadableOpportunity(Opportunity orig, XrmServiceContext context)
        {
            ProxyOpportunity co = new ProxyOpportunity();
            //using (Xrm.XrmServiceContext context = new XrmServiceContext("Xrm"))
            //{

                co.Id = orig.Id;
                co.OpportunityId = orig.OpportunityId;
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
                co.BudgetAmount = orig.BudgetAmount; // ? orig.BudgetAmount.Value : 0;
                //new_Guarantee
                co.Guarantee =  orig.new_Guarantee.HasValue ? (orig.new_Guarantee.Value ? "Yes" : "No") : string.Empty;
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
                co.TaskStatus = EnsureValueFromOptionSet(orig, "new_taskstatus");
                co.Department = orig.new_Department;
                co.ClosingDate = orig.EstimatedCloseDate;
                co.Division = EnsureValueFromOptionSet(orig, "new_division"); // orig.new_Division;
                co.DivisionRole = EnsureValueFromOptionSet(orig, "new_divisionrole");

                co.NSProjectType = EnsureValueFromOptionSet(orig, "new_nsprojecttype");
                co.NSCoreSector = EnsureValueFromOptionSet(orig, "new_nscoresector");

                co.NSOProcessingCategory = EnsureValueFromOptionSet(orig, "new_nsoprocessingcategory");//co.NSOProcessingCategory; //EnsureValueFromOptionSet(orig, "new_nsoprocessingcategory");
                co.ProjectNo = orig.new_ProjectNumber;
                //co.Agencies = ConvertToProxyAccount(orig.new_opportunity_account.ToList()).ToArray();

                //co.RealOpportunity = orig;
                //co.teams = orig.opportunity_Teams;

                //co.c1 = orig.opportunity_connections1;
                //co.c2 = orig.opportunity_connections2;

                co.PRFApproval = orig.new_PRFApproval.HasValue ? orig.new_PRFApproval.Value.ToString() : string.Empty;
                co.CRPICM = orig.new_CRPICM.HasValue ? orig.new_CRPICM.ToString() : string.Empty;
                co.LetterOfNoObjection = orig.new_LetterofNoObjection.HasValue ? orig.new_LetterofNoObjection.Value.ToString() : string.Empty;
                co.FinalReviewICM = orig.new_FinalReviewICM.HasValue ? orig.new_FinalReviewICM.Value.ToString() : string.Empty;
                co.RRPApproval = orig.new_RRPApproval.HasValue ? orig.new_RRPApproval.Value.ToString() : string.Empty;
                co.SigningDate = orig.new_SigningDate.HasValue ? orig.new_SigningDate.Value.ToString() : string.Empty;
                co.EffectivenessDate = orig.new_EffectivenessDate.HasValue ? orig.new_EffectivenessDate.Value.ToString() : string.Empty;
                co.XARRDate = orig.new_XARR.HasValue ? orig.new_XARR.Value.ToString() : string.Empty;
                co.ProjectEndDate = orig.new_ProjectEndDate.HasValue ? orig.new_ProjectEndDate.Value.ToString() : string.Empty;
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
            ProxyAccount proxy = new ProxyAccount();
            proxy.AccountName = account.Name;
            proxy.EntityRole = EnsureValueFromOptionSet(account, "new_agencyrole");
            proxy.ID = account.Id;
            proxy.ParentID = (account.new_opportunity_account != null) ? account.new_opportunity_account.Id.ToString() : Guid.Empty.ToString();
            proxy.IDstring = proxy.ID.ToString();
            proxy.Country = EnsureValueFromOptionSet(account, "new_agencycountry");
            proxy.InvolvementInProject = EnsureValueFromOptionSet(account, "new_involvementinproject"); //account.new_InvolvementinProject

            proxy.Address1_Street1 = account.Address1_Line1; //EnsureValueFromOptionSet(account, "address1_line1");
            proxy.Address1_Street2 = account.Address1_Line2; //EnsureValueFromOptionSet(account, "address1_line2");
            proxy.Address1_Street3 = account.Address1_Line3; //EnsureValueFromOptionSet(account, "address1_line3");
            proxy.Address1_City = account.Address1_City; //EnsureValueFromOptionSet(account, "address1_city");
            proxy.Address1_StateProvince = account.Address1_StateOrProvince; //EnsureValueFromOptionSet(account, "address1_stateorprovince");
            proxy.Address1_ZipCode = account.Address1_PostalCode; //EnsureValueFromOptionSet(account, "address1_postalcode");
            proxy.Address1_CountryRegion = account.Address1_Country; //EnsureValueFromOptionSet(account, "address1_country");
            
            return proxy;

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

        public static List<ProxyConnection> ConvertToProxyConnection(IEnumerable<Xrm.Connection> connections, XrmServiceContext context)
        {
            List<ProxyConnection> result = new List<ProxyConnection>();
            foreach (Xrm.Connection c in connections)
            {
                ProxyConnection pc = SingleConvertToProxyConnection(c, context);
                result.Add(pc);
            }
            return result;
        }

        public static ProxyConnection SingleConvertToProxyConnection(Xrm.Connection connection, XrmServiceContext context)
        {
            ProxyConnection pc = null;
            if (connection != null)
            {
                pc = new ProxyConnection();
                pc.Name = connection.Name;
                pc.ID = connection.Id;
                pc.Role = connection.Record2RoleId != null ? connection.Record2RoleId.Name : string.Empty;
                pc.OpportunityId = connection.Record1Id != null ? connection.Record1Id.Id.ToString() : Guid.Empty.ToString();
                
                if ((connection.Record2Id != null) && (!string.IsNullOrEmpty(connection.Record2Id.LogicalName)))
                {
                    if (connection.Record2Id.LogicalName.Equals("contact", StringComparison.InvariantCultureIgnoreCase))
                    {
                        //using (Xrm.XrmServiceContext context = new XrmServiceContext("Xrm"))
                        //{
                            var contact = context.ContactSet.Where(c => c.Id == connection.Record2Id.Id).FirstOrDefault();
                            if (contact != null)
                            {
                                pc.Fullname = contact.FullName;
                                pc.JobTitle = contact.JobTitle;
                                pc.AccountName = contact.contact_customer_accounts != null ? contact.contact_customer_accounts.Name : string.Empty;
                                pc.Email = contact.EMailAddress1;
                                pc.BusinessPhone = contact.Telephone1;
                                pc.MobilePhone = contact.MobilePhone;
                                pc.Fax = contact.Fax;
                                pc.PreferedMethodofContact = EnsureValueFromOptionSet(contact, "preferredcontactmethodcode"); // contact.PreferredContactMethodCode
                                pc.Address1_Street1 = contact.Address1_Line1;
                                pc.Address1_Street2 = contact.Address1_Line2;
                                pc.Address1_Street3 = contact.Address1_Line3;
                                pc.Address1_City = contact.Address1_City;
                                pc.Address1_StateProvince = contact.Address1_StateOrProvince;
                                pc.Address1_ZipCode = contact.Address1_PostalCode;
                                pc.Address1_CountryRegion = contact.Address1_Country;
                            }
                        //}
                    }
                }
                 

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
            proxyCovenant.CompliedWithID = nso.new_CompliedWith;
            proxyCovenant.SubmissionDate = nso.new_SubmissionDate;
            proxyCovenant.Status = EnsureValueFromOptionSet(nso, "new_status");
            proxyCovenant.StatusID = nso.new_Status;
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
            proxyCovenant.Remarks = covenant.new_Remarks; //EnsureValueFromOptionSet(covenant, "new_remarks");
            proxyCovenant.ParagraphNo = covenant.new_ParagraphNo;
            proxyCovenant.AgreementSectionNo = covenant.new_AgreementSectionNo;


            return proxyCovenant;
        }

        //Proxy NSO Impact
        public static ProxyNSOImpact SingleConvertToProxyNSOImpact(new_nsoimpact nsoImpact)
        {
            ProxyNSOImpact proxy = new ProxyNSOImpact();
            proxy.AchievedByYear = EnsureValueFromOptionSet(nsoImpact, "new_achievedbyyear");
            proxy.ActionTaken = nsoImpact.new_Imp_ProposedActionTaken;
            proxy.AssessmentOfCurrentStatus = nsoImpact.new_Imp_AssessmentofCurrentStatus;
            proxy.Assumptions = nsoImpact.new_Imp_Assumptions;
            proxy.BaselineValue = nsoImpact.new_Imp_BaselineValue;
            proxy.BaselineYear = EnsureValueFromOptionSet(nsoImpact, "new_baselineyear");
            proxy.Classification = EnsureValueFromOptionSet(nsoImpact, "new_imp_classification");
            proxy.AchievementValue = nsoImpact.new_Imp_AchievementValue;
            proxy.CumulativeValue = nsoImpact.new_Imp_CumulativeValue;
            proxy.Date = nsoImpact.new_Imp_Date;
            proxy.ID = nsoImpact.Id;
            proxy.ImpactNo = nsoImpact.new_name;
            proxy.ImpactStatement = nsoImpact.new_ImpactStatement;
            proxy.Indicators = nsoImpact.new_Imp_Indicators;
            proxy.ModifiedOn = nsoImpact.ModifiedOn;
            proxy.PerformanceTargets = nsoImpact.new_Imp_PerformanceTargets;
            proxy.Problems = nsoImpact.new_Imp_Problems;
            proxy.ProgressStatus = nsoImpact.new_Imp_ProgressStatus; //EnsureValueFromOptionSet(nsoImpact, "new_imp_progressstatus");//new_imp_progressstatus
            proxy.RecentDevelopment = nsoImpact.new_Imp_RecentDevelopment;
            proxy.ReportingEndDate = nsoImpact.new_Imp_ReportingEndDate;
            proxy.ReportingStartDate = nsoImpact.new_Imp_ReportingStartDate;
            proxy.RiskAssessmentOfCurrentStatus = nsoImpact.new_Imp_RisksAssessmentofCurrentStatus;
            proxy.Risks = nsoImpact.new_Imp_Risks;
            proxy.UnitOfMeasurement = EnsureValueFromOptionSet(nsoImpact, "new_imp_unitofmeasurement");
            proxy.Value = nsoImpact.new_Imp_Value;
            proxy.OpportunityID = nsoImpact.new_opportunity_new_nsoimpact != null ? nsoImpact.new_opportunity_new_nsoimpact.Id : Guid.Empty;
            proxy.OpportunityIDString = proxy.OpportunityID.ToString();
            return proxy;
        }

        public static IEnumerable<ProxyNSOImpact> ConvertToProxyNSOImpact(IEnumerable<new_nsoimpact> nso)
        {
            List<ProxyNSOImpact> list = new List<ProxyNSOImpact>();
            foreach (new_nsoimpact n in nso)
            {
                ProxyNSOImpact proxy = SingleConvertToProxyNSOImpact(n);
                list.Add(proxy);
            }
            return list;
        }

        //Proxy NSO Outcome
        public static ProxyNSOOutcome SingleConvertToProxyNSOOutcome(new_nsooutcome outcome)
        {
            ProxyNSOOutcome proxy = new ProxyNSOOutcome();
            proxy.AchievedByYear = EnsureValueFromOptionSet(outcome, "new_achievedbyyear");
            proxy.ActionTaken = outcome.new_Out_ProposedActionTaken;
            proxy.AssessmentOfCurrentStatus = outcome.new_Out_AssessmentofCurrentStatus;
            proxy.Assumptions = outcome.new_Out_Assumptions;
            proxy.BaselineValue = outcome.new_BaselineYear;
            proxy.BaselineYear = EnsureValueFromOptionSet(outcome, "new_baselineyear");
            proxy.Classification = EnsureValueFromOptionSet(outcome, "new_out_classification");
            proxy.AchievementValue = outcome.new_Out_AchievementValue;
            proxy.CumulativeValue = outcome.new_Out_CumulativeValue;
            proxy.Date = outcome.new_Out_Date;
            proxy.ID = outcome.Id;
            proxy.OutcomeNo = outcome.new_name;
            proxy.OutcomeStatement = outcome.new_OutcomeStatement;
            proxy.Indicators = outcome.new_Out_Indicators;
            proxy.ModifiedOn = outcome.ModifiedOn;
            proxy.PerformanceTargets = outcome.new_Out_PerformanceTargets;
            proxy.Problems = outcome.new_Out_Problems;
            proxy.ProgressStatus = outcome.new_Out_ProgressStatus;
            proxy.RecentDevelopment = outcome.new_Out_RecentDevelopment;
            proxy.ReportingEndDate = outcome.new_Out_ReportingEndDate;
            proxy.ReportingStartDate = outcome.new_Out_ReportingStartDate;
            proxy.RiskAssessmentOfCurrentStatus = outcome.new_Out_RisksAssessmentofCurrentStatus;
            proxy.Risks = outcome.new_Out_Risks;
            proxy.UnitOfMeasurement = EnsureValueFromOptionSet(outcome, "new_out_unitofmeasurement");
            proxy.Value = outcome.new_Out_Value;
            proxy.OpportunityID = outcome.new_opportunity_new_nsooutcome != null ? outcome.new_opportunity_new_nsooutcome.Id : Guid.Empty;
            proxy.OpportunityIDString = proxy.OpportunityID.ToString();
            return proxy;
        }

        public static IEnumerable<ProxyNSOOutcome> ConvertToProxyNSOOutcome(IEnumerable<new_nsooutcome> outcomelist)
        {
            List<ProxyNSOOutcome> list = new List<ProxyNSOOutcome>();
            foreach (new_nsooutcome o in outcomelist)
            {
                ProxyNSOOutcome proxy = SingleConvertToProxyNSOOutcome(o);
                list.Add(proxy);
            }
            return list;
        }

        //Proxy NSO Output
        public static ProxyNSOOutput SingleConvertToProxyNSOOutput(new_nsooutput output)
        {
            ProxyNSOOutput proxy = new ProxyNSOOutput();
            proxy.AchievedByYear = EnsureValueFromOptionSet(output, "new_achievedbyyear");
            proxy.ActionTaken = output.new_Outp_ProposedActionTaken;
            proxy.AssessmentOfCurrentStatus = output.new_Outp_AssessmentofCurrentStatus;
            proxy.Assumptions = output.new_Outp_Assumptions;
            proxy.BaselineValue = output.new_Outp_BaselineValue;
            proxy.BaselineYear = EnsureValueFromOptionSet(output, "new_baselineyear");
            proxy.Classification = EnsureValueFromOptionSet(output, "new_outp_classification");
            proxy.AchievementValue = output.new_Outp_AchievementValue;
            proxy.CumulativeValue = output.new_Outp_CumulativeValue;
            proxy.Date = output.new_Outp_Date;
            proxy.ID = output.Id;
            proxy.OutputNo = output.new_name;
            proxy.OutputStatement = output.new_OutputStatement;
            proxy.Indicators = output.new_Outp_Indicators;
            proxy.ModifiedOn = output.ModifiedOn;
            proxy.PerformanceTargets = output.new_Outp_PerformanceTargets;
            proxy.Problems = output.new_Outp_Problems;
            proxy.ProgressStatus = output.new_Outp_ProgressStatus;
            proxy.RecentDevelopment = output.new_Outp_RecentDevelopment;
            proxy.ReportingEndDate = output.new_Outp_ReportingEndDate;
            proxy.ReportingStartDate = output.new_Outp_ReportingStartDate;
            proxy.RiskAssessmentOfCurrentStatus = output.new_Outp_RisksAssessmentofCurrentStatus;
            proxy.Risks = output.new_Outp_Risks;
            proxy.UnitOfMeasurement = EnsureValueFromOptionSet(output, "new_outp_unitofmeasurement");
            proxy.Value = output.new_Outp_Value;
            proxy.OpportunityID = output.new_opportunity_new_nsooutput != null ? output.new_opportunity_new_nsooutput.Id : Guid.Empty;
            proxy.OpportunityIDString = proxy.OpportunityID.ToString();
            return proxy;
        }

        public static IEnumerable<ProxyNSOOutput> ConvertToProxyNSOOutput(IEnumerable<new_nsooutput> outputlist)
        {
            List<ProxyNSOOutput> list = new List<ProxyNSOOutput>();
            foreach (new_nsooutput o in outputlist)
            {
                ProxyNSOOutput proxy = SingleConvertToProxyNSOOutput(o);
                list.Add(proxy);
            }
            return list;
        }

        public static ProxyCreditGuaranteeInquiry SingleConvertToProxyCreditGuaranteeInquiry(new_creditguaranteerequest credit)
        {
            ProxyCreditGuaranteeInquiry proxy = new ProxyCreditGuaranteeInquiry();
            proxy.InquiryReferenceNo = credit.new_name; //EnsureValueFromOptionSet(credit, "new_name");
            proxy.IssuingBankName = credit.new_account_new_creditguaranteerequest_IssuingBankName.Name;
            proxy.ConfirmingBankName = credit.new_account_new_creditguaranteerequest_ConfirmingBankName.Name;
            proxy.TypeOfTradeTransaction = EnsureValueFromOptionSet(credit, "new_typeoftradetransaction");
            proxy.TypeOfTradeTransactionID = credit.new_TypeofTradeTransaction;
            proxy.ApplicantName = credit.new_ApplicantName;
            proxy.BeneficiaryName = credit.new_BeneficiaryName;
            proxy.Tenor = credit.new_Tenor;
            proxy.Goods = credit.new_Goods;
            proxy.TotalTransactionValue = credit.new_TotalTransactionValue;
            proxy.ADBAmountCovered = credit.new_AmountofADBCoverRequested;
            proxy.ClientEmail = credit.new_ClientEmailAddress;
            proxy.ClientName = credit.new_ClientName;
            proxy.ID = credit.Id;
            return proxy;
        }

        public static IEnumerable<ProxyCreditGuaranteeInquiry> ConvertToProxyCreditGuaranteeInquiry(IEnumerable<new_creditguaranteerequest> creditList)
        {
            List<ProxyCreditGuaranteeInquiry> list = new List<ProxyCreditGuaranteeInquiry>();
            foreach (new_creditguaranteerequest c in creditList)
            {
                ProxyCreditGuaranteeInquiry proxy = SingleConvertToProxyCreditGuaranteeInquiry(c);
                list.Add(proxy);
            }
            return list;
        }

        public static new_creditguaranteerequest CreateFromProxy(ProxyCreditGuaranteeInquiry credit)
        {
            new_creditguaranteerequest result = new new_creditguaranteerequest();
            result.new_name = credit.InquiryReferenceNo;
            result.new_IssuingBankName = new Microsoft.Xrm.Client.CrmEntityReference("account", Guid.Parse(credit.IssuingBankNameIDString));
            result.new_ConfirmingBankName = new Microsoft.Xrm.Client.CrmEntityReference("account", Guid.Parse(credit.ConfirmingBankNameIDString));
            result.new_TypeofTradeTransaction = credit.TypeOfTradeTransactionID.Value;
            //credit.TypeOfTradeTransaction = EnsureValueFromOptionSet(credit, "new_typeoftradetransaction");
            
            result.new_ApplicantName = credit.ApplicantName;
            result.new_BeneficiaryName = credit.BeneficiaryName;
            result.new_Tenor = credit.Tenor;
            result.new_Goods = credit.Goods;
            result.new_TotalTransactionValue = credit.TotalTransactionValue;
            result.new_AmountofADBCoverRequested = credit.ADBAmountCovered;//credit.ADBAmountCovered;
            result.Id = credit.ID;
            result.new_ClientName = credit.ClientName;
            result.new_ClientEmailAddress = credit.ClientEmail;
            return result;
        }

        //INCOMPLETE
        public static ProxyMilestoneEvent SingleConvertToProxyMilestoneEvent(new_milestoneevent ev)
        {
            ProxyMilestoneEvent result = new ProxyMilestoneEvent();

            //result.CRPICM = ev.cr

            return result;
        }
    }
}
