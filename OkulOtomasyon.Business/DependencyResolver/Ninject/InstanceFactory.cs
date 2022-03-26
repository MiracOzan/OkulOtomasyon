using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Core;
using Microsoft.Extensions.Logging;
using Ninject;
using OkulOtomasyon.Core.CrossCuttingConcerns.Logging.Log4net;
using ILogger = log4net.Core.ILogger;

namespace OkulOtomasyon.Business.DependencyResolver.Ninject
{
    public class InstanceFactory
    {
        public static T GetInstance<T>()
        {
            var kernel = new StandardKernel(new BusinessModule(), new AutoMapperModule());
            return kernel.Get<T>();
        }
    }
}
