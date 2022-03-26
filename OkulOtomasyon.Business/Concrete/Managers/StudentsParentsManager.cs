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
    public class StudentsParentsManager : IStudentsParentsService
    {
        private readonly IStudentsParentsDal _parentsDal;

        public StudentsParentsManager(IStudentsParentsDal parentsDal)
        {
            _parentsDal = parentsDal;
        }

     

        public StudentsParents addStudentsParents(StudentsParents newStudentsParents)
        {
            return _parentsDal.Add(newStudentsParents);
        }

        public StudentsParents GetStudentsParents(int studentsId)
        {
            return _parentsDal.Get(p => p.StudentsIdentityNumber == studentsId);
        }
    }
}
