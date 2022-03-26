using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OkulOtomasyon.Business.Abstract;
using OkulOtomasyon.Entities.Concrete;


namespace OkulOtomasyon.WebApi.Controllers
{
    public class StudentsController : ApiController
    {
        private IStudentsService _studentsService;

        public StudentsController(IStudentsService studentsService)
        {
            _studentsService = studentsService;
        }

        public List<Students> GetAlList()
        {
            return _studentsService.GettAll();
        }
    }
}
