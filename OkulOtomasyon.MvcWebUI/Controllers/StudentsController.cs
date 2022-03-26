using OkulOtomasyon.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OkulOtomasyon.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using OkulOtomasyon.Core.Aspects.PostSharp.AuthorizationAspects;
using OkulOtomasyon.Core.CrossCuttingConcerns.Security.Web;
using PostSharp.Extensibility;

namespace OkulOtomasyon.MvcWebUI.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentsService _studentsService;
        public StudentsController(IStudentsService studentsService)
        {
            _studentsService = studentsService;
        }

        public ActionResult List()
        {
            var model = new StudentsListViewModel
            {
                Students = _studentsService.GettAll()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(Students students)
        {
            var model = new StudentsAddViewModel
            {
                Students = _studentsService.addStudents(students)
            };
            return View(model);
        }

        public ActionResult Detail(string Id)
        {

            var model = new StudentsDetailsViewModel
            {
                Students = _studentsService.getStudents(Id)
            };
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(string Id)
        {
            var model = new StudentsEditViewModel
            {
                Students = _studentsService.getStudents(Id)
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Students students)
        {
            var model = new StudentsEditViewModel
            {
                Students = _studentsService.updateStudents(students)
            };
            return View(model);
        }
    }
}