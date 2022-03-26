using System.Collections.Generic;
using System.Linq;
using OkulOtomasyon.Business.Abstract;
using OkulOtomasyon.Business.ValidationRules.FluentValidation;
using OkulOtomasyon.DataAccess.Abstract;
using OkulOtomasyon.Entities.Concrete;
using AutoMapper;
using log4net;
using OkulOtomasyon.Business.Constants;
using OkulOtomasyon.Core.Aspects.Autofac.Caching;
using OkulOtomasyon.Core.Aspects.Autofac.Logging;
using OkulOtomasyon.Core.Aspects.Autofac.Validation;
using OkulOtomasyon.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using OkulOtomasyon.Core.Utilities.Business;
using OkulOtomasyon.Core.Utilities.Results;
using OkulOtomasyon.Core.CrossCuttingConcerns.Caching.Microsoft;

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
        

        [ValidationAspect(typeof(StudentsValidator))]
        //[LogAspect(typeof(DatabaseLogger))]
        //[LogAspect(typeof(FileLogger))]
        [CacheAspect(typeof(MemoryCacheManager),120)]
        //[SecuredOperationAspect(Roles="Admin")]
        public List<Students> GettAll()
        {
            var studentsList = _mapper.Map<List<Students>>(_studentsDal.GetList());
            return studentsList;
        }
        [CacheRemoveAspect(typeof(MemoryCasheManager))]

        [FluentValidationAspects(typeof(StudentsValidator))]
        [LogAspect(typeof(DatabaseLogger))]

        public IResult Add(Students students)
        {
            IResult result = BusinessRules.Run(CheckIfProductNameExists(students.IdentityNumber));

            if (result != null)
            {
                return result;
            }
            _studentsDal.Add(students);
            return new SuccessResult(Message.StudentsFound);
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
        private IResult CheckIfProductNameExists(string IdenitityNumber)
        {

            var result = _studentsDal.GetList(p => p.IdentityNumber == IdenitityNumber).Any();
            if (result)
            {
                return new ErrorResult(Message.ProductNameAlreadyExists);
            }

            return new SuccessResult();
        }

    }
}
