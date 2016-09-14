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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ConnectionService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ConnectionService.svc or ConnectionService.svc.cs at the Solution Explorer and start debugging.
    public class ConnectionService : IConnectionService
    {
        private Xrm.XrmServiceContext xrm = null;
        public ConnectionService()
        {
            this.xrm = new Xrm.XrmServiceContext("Xrm");
        }

        public List<ProxyConnection> GetAllConnection()
        {
            CacheHelper.ClearCache();
            List<ProxyConnection> proxies = new List<ProxyConnection>();
            //using (Xrm.XrmServiceContext context = new Xrm.XrmServiceContext("Xrm"))
            //{
                proxies = ObjectConverter.ConvertToProxyConnection(this.xrm.ConnectionSet, this.xrm);
            //}
            return proxies;
        }

        public Entity.ProxyConnection GetOneConnection(Guid id)
        {
            CacheHelper.ClearCache();
            ProxyConnection conn = null;
            //using (Xrm.XrmServiceContext context = new Xrm.XrmServiceContext("Xrm"))
            //{ 
                Xrm.Connection c = this.xrm.ConnectionSet.Where(i=>i.Id == id).FirstOrDefault();
                if(c != null)
                {
                    conn = ObjectConverter.SingleConvertToProxyConnection(c, this.xrm);
                }
            //}
            return conn;
        }


        public void UpdateOneConnection(ProxyConnection c)
        {
            
        }
    }
}
