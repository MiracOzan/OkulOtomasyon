using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OkulOtomasyon.Business.Abstract;
using OkulOtomasyon.Business.Concrete.Managers;
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

            Bind<IUsersService>().To<UsersManager>();
            Bind<IUsersDal>().To<EfUserDal>();
            
            // DbContext
            Bind<DbContext>().To<SchoolContext>().InSingletonScope();
        }
    }
}
