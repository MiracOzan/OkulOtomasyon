using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CSharpTest.Net.Interfaces;
using Microsoft.AspNetCore.Mvc;
using OkulOtomasyon.Business.Abstract;
using OkulOtomasyon.Business.Concrete.Managers;
using OkulOtomasyon.Business.DependencyResolver.Ninject;
using OkulOtomasyon.Entities.Concrete;

namespace OkulOtomasyon.WebApi.Controllers
{
    public class StudentsController : ControllersBase
    {
        private IStudentsService _studentsService;

        public StudentsController(IStudentsService studentsService)
        {
            _studentsService = studentsService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _studentsService.GettAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);

        }
    }
}
