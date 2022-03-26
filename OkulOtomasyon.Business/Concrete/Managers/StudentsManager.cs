using System;
using System.Collections.Generic;
using OkulOtomasyon.Business.Abstract;
using OkulOtomasyon.Business.ValidationRules.FluentValidation;
using OkulOtomasyon.DataAccess.Abstract;
using OkulOtomasyon.Entities.Concrete;
using System.Transactions;
using AutoMapper;
using OkulOtomasyon.Core.Aspects.PostSharp.AuthorizationAspects;
using OkulOtomasyon.Core.Aspects.PostSharp.CacheAspects;
using OkulOtomasyon.Core.Aspects.PostSharp.LogAspects;
using OkulOtomasyon.Core.Aspects.PostSharp.TransactionAspects;
using OkulOtomasyon.Core.Aspects.PostSharp.ValidationAspects;
using OkulOtomasyon.Core.CrossCuttingConcerns.Caching.Microsoft;
using OkulOtomasyon.Core.CrossCuttingConcerns.Logging.Log4net.Loggers;
using OkulOtomasyon.Core.CrossCuttingConcerns.Validation.FluentValidation;
using OkulOtomasyon.Core.Utilities.Mappings;

namespace OkulOtomasyon.Business.Concrete.Managers
{
    public class StudentsManager : IStudentsService
    {
        private readonly IStudentsDal _studentsDal;
        private readonly IMapper _mapper;

        public StudentsManager(IStudentsDal studentsDal, IMapper mapper)
        {
            _studentsDal = studentsDal;
            _mapper = mapper;
        }

        [FluentValidationAspects(typeof(StudentsValidator))]
        [CacheAspect(typeof(MemoryCasheManager),120)]
        [SecuredOperationAspect(Roles="Admin")]
        public List<Students> GettAll()
        {
            var studentsList = _mapper.Map<List<Students>>(_studentsDal.GetList());
            return studentsList;
        }
        [CacheRemoveAspect(typeof(MemoryCasheManager))]

        [FluentValidationAspects(typeof(StudentsValidator))]
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
        public Students getStudents(string studentsIdentityNumber)
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
