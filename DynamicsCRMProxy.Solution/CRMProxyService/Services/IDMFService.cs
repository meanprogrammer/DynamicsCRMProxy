using CRMProxyService.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CRMProxyService.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDMFService" in both code and config file together.
    [ServiceContract]
    public interface IDMFService
    {
        [OperationContract]
        IEnumerable<ProxyNSOImpact> GetAllNSOImpact();

        [OperationContract]
        ProxyNSOImpact GetOneNSOImpact(Guid id);

        [OperationContract]
        void UpdateNSOImpact(ProxyNSOImpact impact);

        [OperationContract]
        IEnumerable<ProxyNSOOutcome> GetAllNSOOutcome();

        [OperationContract]
        ProxyNSOOutcome GetOneNSOOutcome(Guid id);

        [OperationContract]
        void UpdateNSOOutcome(ProxyNSOOutcome outcome);

        [OperationContract]
        IEnumerable<ProxyNSOOutput> GetAllNSOOutput();

        [OperationContract]
        ProxyNSOOutput GetOneNSOOutput(Guid id);

        [OperationContract]
        void UpdateNSOOutput(ProxyNSOOutput output);
    }
}
