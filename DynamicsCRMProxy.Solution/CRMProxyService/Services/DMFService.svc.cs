using CRMProxyService.Entity;
using CRMProxyService.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CRMProxyService.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DMFService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DMFService.svc or DMFService.svc.cs at the Solution Explorer and start debugging.
    public class DMFService : IDMFService
    {
        private Xrm.XrmServiceContext xrm = null;

        public DMFService()
        {
            this.xrm = new Xrm.XrmServiceContext("Xrm");
        }

        public IEnumerable<ProxyNSOImpact> GetAllNSOImpact()
        {
            CacheHelper.ClearCache();
            IEnumerable<ProxyNSOImpact> list = new List<ProxyNSOImpact>();
            //using (Xrm.XrmServiceContext context = new Xrm.XrmServiceContext("Xrm"))
            //{
            list = ObjectConverter.ConvertToProxyNSOImpact(this.xrm.new_nsoimpactSet);
            //}
            return list;
        }

        public Entity.ProxyNSOImpact GetOneNSOImpact(Guid id)
        {
            CacheHelper.ClearCache();
            ProxyNSOImpact proxy = null;
            //using (Xrm.XrmServiceContext context = new Xrm.XrmServiceContext("Xrm"))
            //{
            var p = this.xrm.new_nsoimpactSet.Where(c => c.Id == id).FirstOrDefault();
                if (p != null)
                {
                    proxy = ObjectConverter.SingleConvertToProxyNSOImpact(p);
                }
            //}
            return proxy;
        }

        public IEnumerable<ProxyNSOOutcome> GetAllNSOOutcome()
        {
            CacheHelper.ClearCache();
            IEnumerable<ProxyNSOOutcome> list = new List<ProxyNSOOutcome>();
            //using (Xrm.XrmServiceContext context = new Xrm.XrmServiceContext("Xrm"))
            //{
            list = ObjectConverter.ConvertToProxyNSOOutcome(this.xrm.new_nsooutcomeSet);
            //}
            return list;
        }

        public Entity.ProxyNSOOutcome GetOneNSOOutcome(Guid id)
        {
            CacheHelper.ClearCache();
            ProxyNSOOutcome proxy = null;
            using (Xrm.XrmServiceContext context = new Xrm.XrmServiceContext("Xrm"))
            {
                var o = context.new_nsooutcomeSet.Where(c => c.Id == id).FirstOrDefault();
                if (o != null)
                {
                    proxy = ObjectConverter.SingleConvertToProxyNSOOutcome(o);
                }
            }
            return proxy;
        }

        public IEnumerable<Entity.ProxyNSOOutput> GetAllNSOOutput()
        {
            CacheHelper.ClearCache();
            IEnumerable<ProxyNSOOutput> list = new List<ProxyNSOOutput>();
            //using (Xrm.XrmServiceContext context = new Xrm.XrmServiceContext("Xrm"))
            //{
            list = ObjectConverter.ConvertToProxyNSOOutput(this.xrm.new_nsooutputSet);
            //}
            return list;
        }

        public Entity.ProxyNSOOutput GetOneNSOOutput(Guid id)
        {
            CacheHelper.ClearCache();
            ProxyNSOOutput proxy = null;
            //using (Xrm.XrmServiceContext context = new Xrm.XrmServiceContext("Xrm"))
            //{
            var o = this.xrm.new_nsooutputSet.Where(c => c.Id == id).FirstOrDefault();
                if (o != null)
                {
                    proxy = ObjectConverter.SingleConvertToProxyNSOOutput(o);
                }
            //}
            return proxy;
        }


        public void UpdateNSOImpact(ProxyNSOImpact impact)
        {
            CacheHelper.ClearCache();
            //using (Xrm.XrmServiceContext context = new Xrm.XrmServiceContext("Xrm"))
            //{
            var i = (from s in this.xrm.new_nsoimpactSet
                         where s.Id == impact.ID
                         select s).FirstOrDefault();
                if (i != null)
                {
                    i.new_Imp_ProgressStatus = impact.ProgressStatus;
                    i.new_Imp_Assumptions = impact.Assumptions;
                    i.new_Imp_Risks = impact.Risks;
                    i.new_Imp_AssessmentofCurrentStatus = impact.AssessmentOfCurrentStatus;
                    i.new_Imp_RisksAssessmentofCurrentStatus = impact.RiskAssessmentOfCurrentStatus;

                    i.new_Imp_Problems = impact.Problems;
                    i.new_Imp_ProposedActionTaken = impact.ActionTaken;
                    i.new_Imp_RecentDevelopment = impact.RecentDevelopment;
                    i.new_Imp_Date = impact.Date;



                    this.xrm.UpdateObject(i);
                    this.xrm.SaveChanges();
                }
            //}
        }

        public void UpdateNSOOutcome(ProxyNSOOutcome outcome)
        {
            CacheHelper.ClearCache();
            //using (Xrm.XrmServiceContext context = new Xrm.XrmServiceContext("Xrm"))
            //{
            var o = (from s in this.xrm.new_nsooutcomeSet
                     where s.Id == outcome.ID
                     select s).FirstOrDefault();
            if (o != null)
            {

                o.new_Out_ProgressStatus = outcome.ProgressStatus;
                o.new_Out_Assumptions = outcome.Assumptions;
                o.new_Out_Risks = outcome.Risks;
                o.new_Out_AssessmentofCurrentStatus = outcome.AssessmentOfCurrentStatus;
                o.new_Out_RisksAssessmentofCurrentStatus = outcome.RiskAssessmentOfCurrentStatus;

                o.new_Out_Problems = outcome.Problems;
                o.new_Out_ProposedActionTaken = outcome.ActionTaken;
                o.new_Out_RecentDevelopment = outcome.RecentDevelopment;
                o.new_Out_Date = outcome.Date;

                this.xrm.UpdateObject(o);
                this.xrm.SaveChanges();
            }
            //}
        }

        public void UpdateNSOOutput(ProxyNSOOutput output)
        {
            CacheHelper.ClearCache();
            //using (Xrm.XrmServiceContext context = new Xrm.XrmServiceContext("Xrm"))
            //{
            var o = (from s in this.xrm.new_nsooutputSet
                     where s.Id == output.ID
                     select s).FirstOrDefault();
            if (o != null)
            {
                o.new_Outp_ProgressStatus = output.ProgressStatus;
                o.new_Outp_Assumptions = output.Assumptions;
                o.new_Outp_Risks = output.Risks;
                o.new_Outp_AssessmentofCurrentStatus = output.AssessmentOfCurrentStatus;
                o.new_Outp_RisksAssessmentofCurrentStatus = output.RiskAssessmentOfCurrentStatus;

                o.new_Outp_Problems = output.Problems;
                o.new_Outp_ProposedActionTaken = output.ActionTaken;
                o.new_Outp_RecentDevelopment = output.RecentDevelopment;
                o.new_Outp_Date = output.Date;

                this.xrm.UpdateObject(o);
                this.xrm.SaveChanges();
            }
            //}
        }
    }
}
