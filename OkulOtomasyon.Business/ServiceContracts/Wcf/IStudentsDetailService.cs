using System.Collections.Generic;
using System.ServiceModel;
using OkulOtomasyon.Entities.Concrete;

namespace OkulOtomasyon.Business.ServiceContracts.Wcf
{
    /// <summary>
    /// Summary description for IStudentsDetailService
    /// </summary>

    [ServiceContract]
    public interface IStudentsDetailService
    {
        [OperationContract]
        List<Students> GettAll();
    }
}