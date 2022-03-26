using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OkulOtomasyon.Business.Abstract;
using OkulOtomasyon.Business.DependencyResolver.Ninject;
using OkulOtomasyon.Entities.Concrete;

/// <summary>
/// Summary description for StudentsService
/// </summary>
public class StudentsService : IStudentsService
{
    public StudentsService()
    {
        
    }

    private IStudentsService _studentsService = InstanceFactory.GetInstance<IStudentsService>();
    public List<Students> GettAll()
    {
        return _studentsService.GettAll();
    }

    public Students addStudents(Students newStudents)
    {
        return _studentsService.addStudents(newStudents);
    }

    public Students updateStudents(Students updateStudents)
    {
        return _studentsService.updateStudents(updateStudents);
    }

    public Students getStudents(string studentsIdentityNumber)
    {
        return _studentsService.getStudents(studentsIdentityNumber);
    }

    public void TransactionalOperation(Students students, Students students2)
    {
         _studentsService.TransactionalOperation(students, students2);
    }

}