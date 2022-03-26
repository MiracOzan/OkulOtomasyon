using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OkulOtomasyon.Entities.Concrete;

namespace OkulOtomasyon.Business.Abstract
{
    public interface IStudentsParentsService
    {
        StudentsParents GetStudentsParents(int studentsId);
        StudentsParents addStudentsParents(StudentsParents newStudentsParents);
    }
}
