using System;
using System.Collections.Generic;
using OkulOtomasyon.Business.Abstract;
using OkulOtomasyon.Business.ValidationRules.FluentValidation;
using OkulOtomasyon.DataAccess.Abstract;
using OkulOtomasyon.Entities.Concrete;
using System.Transactions;
using AutoMapper;
using log4net;
using OkulOtomasyon.Core.Aspects.PostSharp.AuthorizationAspects;
using OkulOtomasyon.Core.Aspects.PostSharp.CacheAspects;
using OkulOtomasyon.Core.Aspects.PostSharp.LogAspects;
using OkulOtomasyon.Core.Aspects.PostSharp.TransactionAspects;
using OkulOtomasyon.Core.Aspects.PostSharp.ValidationAspects;
using OkulOtomasyon.Core.CrossCuttingConcerns.Caching.Microsoft;
using OkulOtomasyon.Core.CrossCuttingConcerns.Logging.Log4net.Loggers;
using OkulOtomasyon.Core.CrossCuttingConcerns.Validation.FluentValidation;
using OkulOtomasyon.Core.Utilities.Mappings;
using log4net.Core;
using OkulOtomasyon.Core.CrossCuttingConcerns.Logging.Log4net;

namespace OkulOtomasyon.Business.Concrete.Managers
{
    public class StudentsManager : IStudentsService
    {
        private readonly IStudentsDal _studentsDal;
        private readonly IMapper _mapper;
        public LoggerService logger;

        public StudentsManager(IStudentsDal studentsDal, IMapper mapper)
        {
            _studentsDal = studentsDal;
            _mapper = mapper;
          
        }
        

        [FluentValidationAspects(typeof(StudentsValidator))]
        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [CacheAspect(typeof(MemoryCasheManager),120)]
        //[SecuredOperationAspect(Roles="Admin")]
        public List<Students> GettAll()
        {
            var studentsList = _mapper.Map<List<Students>>(_studentsDal.GetList());
            return studentsList;
        }
        [CacheRemoveAspect(typeof(MemoryCasheManager))]

        [FluentValidationAspects(typeof(StudentsValidator))]
        [LogAspect(typeof(DatabaseLogger))]
        public Students addStudents(Students newStudents)
        {
            return _studentsDal.Add(newStudents);
        }

        [FluentValidationAspects(typeof(StudentsValidator))]
        public Students updateStudents(Students updateStudents)
        {
            return _studentsDal.Update(updateStudents);
        }

        [FluentValidationAspects(typeof(StudentsValidator))]
        [CacheAspect(typeof(MemoryCasheManager), 120)]
        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        public Students getStudents(int studentsIdentityNumber)
        {
            return _studentsDal.Get(p => p.IdentityNumber == studentsIdentityNumber);
        }

        [TransactionScopeAspects]
        public void TransactionalOperation(Students students, Students students2)
        {
            _studentsDal.Add(students);
            
            _studentsDal.Update(students2);
        }

     
    }
}
