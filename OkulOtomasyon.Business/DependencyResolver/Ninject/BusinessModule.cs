using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using log4net;
using log4net.Core;
using OkulOtomasyon.Business.Abstract;
using OkulOtomasyon.Business.Concrete.Managers;
using OkulOtomasyon.Core.CrossCuttingConcerns.Logging.Log4net;
using OkulOtomasyon.Core.CrossCuttingConcerns.Logging.Log4net.Loggers;
using OkulOtomasyon.DataAccess.Abstract;
using OkulOtomasyon.DataAccess.Concrete;
using OkulOtomasyon.DataAccess.Concrete.EntityFramework;

namespace OkulOtomasyon.Business.DependencyResolver.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            
            Bind<IStudentsService>().To<StudentsManager>().InSingletonScope();
            Bind<IStudentsDal>().To<EfStudentsDal>().InSingletonScope();
    

            // Bind<LoggerService>().To<DatabaseLogger>().InSingletonScope();
           // Bind<LoggerService>().To<FileLogger>().InSingletonScope();

    
            Bind<IUsersService>().To<UsersManager>();
            Bind<IUsersDal>().To<EfUserDal>();
            
            // DbContext
            Bind<DbContext>().To<SchoolContext>().InSingletonScope();
        }
    }
}
