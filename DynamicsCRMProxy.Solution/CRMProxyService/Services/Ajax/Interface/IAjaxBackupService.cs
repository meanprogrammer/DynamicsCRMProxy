using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using Xrm;

namespace CRMProxyService.Services
{
    [ServiceContract]
    interface IAjaxBackupService
    {
        [WebGet(ResponseFormat = WebMessageFormat.Xml)]
        List<Opportunity> AllOpportunity();

        [WebGet(ResponseFormat = WebMessageFormat.Xml)]
        List<Account> AllAccount();

        [WebGet(ResponseFormat = WebMessageFormat.Xml)]
        List<Contact> AllContact();

        [WebGet(ResponseFormat = WebMessageFormat.Xml)]
        List<AccountLeads> AllAccountLeads();

        [WebGet(ResponseFormat = WebMessageFormat.Xml)]
        List<new_baselineprojections> AllBaselineProjections();

        [WebGet(ResponseFormat = WebMessageFormat.Xml)]
        List<new_createnewrecord> AllCreateProject();

        [WebGet(ResponseFormat = WebMessageFormat.Xml)]
        List<new_disbursementplan> AllDisbursementPlan();

        [WebGet(ResponseFormat = WebMessageFormat.Xml)]
        List<new_submitdisbursementvoucher> AllDisbursementRequest();

        [WebGet(ResponseFormat = WebMessageFormat.Xml)]
        List<Invoice> AllInvoice();

        [WebGet(ResponseFormat = WebMessageFormat.Xml)]
        List<new_milestoneevent> AllMilestoneEvent();

        [WebGet(ResponseFormat = WebMessageFormat.Xml)]
        List<new_nonsovcovenants> AllNonSovCovenant();

        [WebGet(ResponseFormat = WebMessageFormat.Xml)]
        List<new_nsocovenant> AllNSOCovenant();

        [WebGet(ResponseFormat = WebMessageFormat.Xml)]
        List<new_nsodmf> AllNSODMF();

        [WebGet(ResponseFormat = WebMessageFormat.Xml)]
        List<new_nsoimpact> AllNSOImpact();

        [WebGet(ResponseFormat = WebMessageFormat.Xml)]
        List<new_nsooutcome> AllNSOOutcome();

        [WebGet(ResponseFormat = WebMessageFormat.Xml)]
        List<new_nsooutput> AllNSOOutput();

        [WebGet(ResponseFormat = WebMessageFormat.Xml)]
        List<new_product> AllNSOProduct();

        [WebGet(ResponseFormat = WebMessageFormat.Xml)]
        List<new_pipelineproject> AllPipelineProject();

        [WebGet(ResponseFormat = WebMessageFormat.Xml)]
        List<new_pipelineprojectfeedback> AllPipelineProjectFeedback();

        [WebGet(ResponseFormat = WebMessageFormat.Xml)]
        List<new_covenants> AllSOVCovenant();

        [WebGet(ResponseFormat = WebMessageFormat.Xml)]
        List<new_sovdmf> AllSOVDMF();

        [WebGet(ResponseFormat = WebMessageFormat.Xml)]
        List<new_sovimpact> AllSOVImpact();

        [WebGet(ResponseFormat = WebMessageFormat.Xml)]
        List<new_sovoutcome> AllSOVOutcome();

        [WebGet(ResponseFormat = WebMessageFormat.Xml)]
        List<new_sovoutput> AllSOVOutput();

        [WebGet(ResponseFormat = WebMessageFormat.Xml)]
        List<new_creditguaranteerequest> AllTFPCGGuarantee();

        [WebGet(ResponseFormat = WebMessageFormat.Xml)]
        List<new_tfp_issuanceofcreditguarantee> AllTFPIssuanceOfCreditGuarantee();

        [WebGet(ResponseFormat = WebMessageFormat.Xml)]
        List<new_tfp_requestforconsent> AllTFPRequestForConsent();
        

    }
}
