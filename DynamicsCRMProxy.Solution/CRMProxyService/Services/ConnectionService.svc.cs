using CRMProxyService.Entity;
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
        public List<ProxyConnection> GetAllConnection()
        {
            List<ProxyConnection> proxies = new List<ProxyConnection>();
            using (Xrm.XrmServiceContext context = new Xrm.XrmServiceContext("Xrm"))
            {
                proxies = ObjectConverter.ConvertToProxyConnection(context.ConnectionSet.ToList());
            }
            return proxies;
        }

        public Entity.ProxyConnection GetOneConnection(Guid id)
        {
            ProxyConnection conn = null;
            using (Xrm.XrmServiceContext context = new Xrm.XrmServiceContext("Xrm"))
            { 
                Xrm.Connection c = context.ConnectionSet.Where(i=>i.Id == id).FirstOrDefault();
                if(c != null)
                {
                    conn = ObjectConverter.SingleConvertToProxyConnection(c);
                }
            }
            return conn;
        }


        public void UpdateOneConnection(ProxyConnection c)
        {
            
        }
    }
}
