using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OkulOtomasyon.Business.Abstract;
using OkulOtomasyon.DataAccess.Abstract;
using OkulOtomasyon.Entities.Concrete;

namespace OkulOtomasyon.Business.Concrete.Managers
{
    public class StudentsParentsDetailsService : IStudentsParentsDetailsService
    {
        private IStudentsParentsDetailsDal _studentsParents;

        public StudentsParentsDetailsService(IStudentsParentsDetailsDal studentsParents)
        {
            _studentsParents = studentsParents;
        }

        public List<Students> GettAll()
        {
            throw new NotImplementedException();
        }

        public Students addStudents(Students newStudents)
        {
            throw new NotImplementedException();
        }

        public StudentsParentsDetails updateStudents(StudentsParentsDetails updateStudents)
        {
            return _studentsParents.Update(updateStudents);
        }

        public Students getStudentsParents(string studentsIdentityNumber)
        {
            throw new NotImplementedException();
        }

        public void TransactionalOperation(Students students, Students students2)
        {
            throw new NotImplementedException();
        }
    }
}
