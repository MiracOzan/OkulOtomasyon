using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Ninject.Modules;
using OkulOtomasyon.Business.ValidationRules.FluentValidation;
using OkulOtomasyon.Entities.Concrete;

namespace OkulOtomasyon.Business.DependencyResolver.Ninject
{
    public class ValidationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IValidator<Students>>().To<StudentsValidator>().InSingletonScope();
        }
    }
}
