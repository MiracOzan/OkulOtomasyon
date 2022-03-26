using System.Collections.Generic;
using OkulOtomasyon.Entities.Concrete;

namespace OkulOtomasyon.Business.Abstract
{
    public interface IStudentsService
    {
        List<Students> GettAll();
        Students addStudents(Students newStudents);
        Students updateStudents(Students updateStudents);
        Students getStudents(string studentsIdentityNumber);


        void TransactionalOperation(Students students, Students students2);
    }
}
