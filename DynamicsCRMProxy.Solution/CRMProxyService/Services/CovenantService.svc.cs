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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CovenantService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CovenantService.svc or CovenantService.svc.cs at the Solution Explorer and start debugging.
    public class CovenantService : ICovenantService
    {
        private Xrm.XrmServiceContext xrm = null;
        public CovenantService()
        {
            this.xrm = new Xrm.XrmServiceContext("Xrm");
        }
        public IEnumerable<Entity.ProxySOVCovenant> GetAllSOVCovenant()
        {
            CacheHelper.ClearCache();
            IEnumerable<ProxySOVCovenant> list = new List<ProxySOVCovenant>();
            //using (Xrm.XrmServiceContext context = new Xrm.XrmServiceContext("Xrm"))
            //{
            list = ObjectConverter.ConvertToSOVCovenant(this.xrm.new_covenantsSet);
            //}
            return list;
        }

        public Entity.ProxySOVCovenant GetOneSOVCovenant(Guid id)
        {
            CacheHelper.ClearCache();
            ProxySOVCovenant covenant = null;
            //using (Xrm.XrmServiceContext context = new Xrm.XrmServiceContext("Xrm"))
            //{
            var c = this.xrm.new_covenantsSet.Where(i => i.Id == id).FirstOrDefault();
            if (c != null)
            {
                covenant = ObjectConverter.SingleConvertToSOVCovenant(c);
            }
            //}
            return covenant;
        }

        public IEnumerable<Entity.ProxyNSOCovenant> GetAllNSOCovenant()
        {
            CacheHelper.ClearCache();
            IEnumerable<ProxyNSOCovenant> list = new List<ProxyNSOCovenant>();
            //using (Xrm.XrmServiceContext context = new Xrm.XrmServiceContext("Xrm"))
            //{
            list = ObjectConverter.ConvertToNSOCovenant(this.xrm.new_nsocovenantSet);
            //}
            return list;
        }

        public Entity.ProxyNSOCovenant GetOneNSOCovenant(Guid id)
        {
            CacheHelper.ClearCache();
            ProxyNSOCovenant covenant = null;
            //using (Xrm.XrmServiceContext context = new Xrm.XrmServiceContext("Xrm"))
            //{
            var c = this.xrm.new_nsocovenantSet.Where(i => i.Id == id).FirstOrDefault();
            if (c != null)
            {
                covenant = ObjectConverter.SingleConvertToNSOCovenant(c);
            }
            //}
            return covenant;
        }


        public void UpdateSOVCovenant(ProxySOVCovenant covenant)
        {
            CacheHelper.ClearCache();
            //using (Xrm.XrmServiceContext context = new Xrm.XrmServiceContext("Xrm"))
            //{
            var c = (from s in this.xrm.new_covenantsSet
                     where s.Id == covenant.ID
                     select s).FirstOrDefault();
            if (c != null)
            {
                c.new_CompiledDate = covenant.CompliedDate;
                c.new_Rating = covenant.Rating;
                //c.new_Remarks = covenant.Remarks;
                c.new_ParagraphNo = covenant.ParagraphNo;
                c.new_AgreementSectionNo = covenant.AgreementSectionNo;

                this.xrm.UpdateObject(c);
                this.xrm.SaveChanges();
            }
            //}
        }

        public void UpdateNSOCovenant(ProxyNSOCovenant covenant)
        {
            CacheHelper.ClearCache();
            //using (Xrm.XrmServiceContext context = new Xrm.XrmServiceContext("Xrm"))
            //{
            var c = (from s in this.xrm.new_nsocovenantSet
                     where s.Id == covenant.ID
                     select s).FirstOrDefault();
            if (c != null)
            {
                //c.new_Status = covenant.Status;
                //c.new_CompliedWith = Convert.ToInt32(covenant.CompliedWith);


                //c.new_Description = covenant.CovenantDescription;
                //c.new_CovenantType = covenant.CovenantType;
                c.new_CompliedWith = covenant.CompliedWithID;
                c.new_Status = covenant.StatusID;
                c.new_DueDate = covenant.DueDate;
                //c.new_FrequencyofReview = covenant.FrequencyOfReview;
                //c.new_name = covenant.Name;
                //covenant.
                c.new_SubmissionDate = covenant.SubmissionDate;

                this.xrm.UpdateObject(c);
                this.xrm.SaveChanges();
            }
            //}
        }
    }
}
