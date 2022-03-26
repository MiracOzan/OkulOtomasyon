using System.Collections.Generic;
using System.ServiceModel;
using OkulOtomasyon.Core.Utilities.Results;
using OkulOtomasyon.Entities.Concrete;

namespace OkulOtomasyon.Business.Abstract
{
    [ServiceContract]
    public interface IStudentsService
    {
        [OperationContract]
        List<Students> GettAll();

        [OperationContract]
        IResult Add(Students students);
        [OperationContract]
        Students updateStudents(Students updateStudents);
        [OperationContract]
        Students getStudents(string studentsIdentityNumber);
        [OperationContract]


        void TransactionalOperation(Students students, Students students2);
    }
}
