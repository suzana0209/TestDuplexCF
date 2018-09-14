using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public interface IUpisiCallback1
    {
        [OperationContract(IsOneWay = true)]
        void OnCallback1(string message);
    }

    [ServiceContract(CallbackContract = typeof(IUpisiCallback1))]
    public interface IInsert
    {
        [OperationContract]
        void InsertInto(List<string> l);
    }
}
