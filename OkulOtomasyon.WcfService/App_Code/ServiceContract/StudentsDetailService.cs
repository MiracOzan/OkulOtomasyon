using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using OkulOtomasyon.Business.Abstract;
using OkulOtomasyon.Business.DependencyResolver.Ninject;
using OkulOtomasyon.Business.ServiceContracts.Wcf;
using OkulOtomasyon.Entities.Concrete;

/// <summary>
/// Summary description for IStudentsDetailService
/// </summary>


public class StudentsDetailService : IStudentsDetailService
{
  
    private IStudentsService _studentsService = InstanceFactory.GetInstance<StudentsService>();
    
    public List<Students> GettAll()
    {
        return _studentsService.GettAll();
    }
}