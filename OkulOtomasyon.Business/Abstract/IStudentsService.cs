using System.Collections.Generic;
using System.ServiceModel;
using OkulOtomasyon.Entities.Concrete;

namespace OkulOtomasyon.Business.Abstract
{
    [ServiceContract]
    public interface IStudentsService
    {
        [OperationContract]
        List<Students> GettAll();
        [OperationContract]
        Students addStudents(Students newStudents);
        [OperationContract]
        Students updateStudents(Students updateStudents);
        [OperationContract]
        Students getStudents(int studentsIdentityNumber);
        [OperationContract]


        void TransactionalOperation(Students students, Students students2);
    }
}
