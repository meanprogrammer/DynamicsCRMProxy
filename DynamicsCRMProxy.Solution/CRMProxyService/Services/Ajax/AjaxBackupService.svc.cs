using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace CRMProxyService.Services
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class AjaxBackupService : IAjaxBackupService
    {
        private Xrm.XrmServiceContext xrm = null;

        public AjaxBackupService() 
        {
            xrm = new Xrm.XrmServiceContext("Xrm");
        }


        public List<Xrm.Opportunity> AllOpportunity()
        {
            return xrm.OpportunitySet.ToList();
        }

        public List<Xrm.Account> AllAccount()
        {
            return xrm.AccountSet.ToList();
        }

        public List<Xrm.Contact> AllContact()
        {
            return xrm.ContactSet.ToList();
        }

        public List<Xrm.AccountLeads> AllAccountLeads()
        {
            return xrm.AccountLeadsSet.ToList();
        }

        public List<Xrm.new_baselineprojections> AllBaselineProjections()
        {
            return xrm.new_baselineprojectionsSet.ToList();
        }

        public List<Xrm.new_createnewrecord> AllCreateProject()
        {
            return xrm.new_createnewrecordSet.ToList();
        }

        public List<Xrm.new_disbursementplan> AllDisbursementPlan()
        {
            return xrm.new_disbursementplanSet.ToList();
        }

        public List<Xrm.new_submitdisbursementvoucher> AllDisbursementRequest()
        {
            return xrm.new_submitdisbursementvoucherSet.ToList();
        }

        public List<Xrm.Invoice> AllInvoice()
        {
            return xrm.InvoiceSet.ToList();
        }

        public List<Xrm.new_milestoneevent> AllMilestoneEvent()
        {
            return xrm.new_milestoneeventSet.ToList();
        }

        public List<Xrm.new_nonsovcovenants> AllNonSovCovenant()
        {
            return xrm.new_nonsovcovenantsSet.ToList();
        }

        public List<Xrm.new_nsocovenant> AllNSOCovenant()
        {
            return xrm.new_nsocovenantSet.ToList();
        }

        public List<Xrm.new_nsodmf> AllNSODMF()
        {
            return xrm.new_nsodmfSet.ToList();
        }

        public List<Xrm.new_nsoimpact> AllNSOImpact()
        {
            return xrm.new_nsoimpactSet.ToList();
        }

        public List<Xrm.new_nsooutcome> AllNSOOutcome()
        {
            return xrm.new_nsooutcomeSet.ToList();
        }

        public List<Xrm.new_nsooutput> AllNSOOutput()
        {
            return xrm.new_nsooutputSet.ToList();
        }

        public List<Xrm.new_product> AllNSOProduct()
        {
            return xrm.new_productSet.ToList();
        }

        public List<Xrm.new_pipelineproject> AllPipelineProject()
        {
            return xrm.new_pipelineprojectSet.ToList();
        }

        public List<Xrm.new_pipelineprojectfeedback> AllPipelineProjectFeedback()
        {
            return xrm.new_pipelineprojectfeedbackSet.ToList();
        }

        public List<Xrm.new_covenants> AllSOVCovenant()
        {
            return xrm.new_covenantsSet.ToList();
        }

        public List<Xrm.new_sovdmf> AllSOVDMF()
        {
            return xrm.new_sovdmfSet.ToList();
        }

        public List<Xrm.new_sovimpact> AllSOVImpact()
        {
            return xrm.new_sovimpactSet.ToList();
        }

        public List<Xrm.new_sovoutcome> AllSOVOutcome()
        {
            return xrm.new_sovoutcomeSet.ToList();
        }

        public List<Xrm.new_sovoutput> AllSOVOutput()
        {
            return xrm.new_sovoutputSet.ToList();
        }

        public List<Xrm.new_creditguaranteerequest> AllTFPCGGuarantee()
        {
            return xrm.new_creditguaranteerequestSet.ToList();
        }

        public List<Xrm.new_tfp_issuanceofcreditguarantee> AllTFPIssuanceOfCreditGuarantee()
        {
            return xrm.new_tfp_issuanceofcreditguaranteeSet.ToList();
        }

        public List<Xrm.new_tfp_requestforconsent> AllTFPRequestForConsent()
        {
            return xrm.new_tfp_requestforconsentSet.ToList();
        }
    }
}
