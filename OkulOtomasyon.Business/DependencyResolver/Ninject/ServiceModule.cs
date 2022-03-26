using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using OkulOtomasyon.Business.Abstract;
using OkulOtomasyon.Core.Utilities.Common;

namespace OkulOtomasyon.Business.DependencyResolver.Ninject
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IStudentsService>().ToConstant(WcfProxy<IStudentsService>.CreateChannel());
        }
    }
}
