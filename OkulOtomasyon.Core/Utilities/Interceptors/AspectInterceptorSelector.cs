using System;
using System.Linq;
using System.Reflection;
using Castle.DynamicProxy;
using OkulOtomasyon.Core.Aspects.PostSharp.ExceptionAspects;
using OkulOtomasyon.Core.CrossCuttingConcerns.Logging.Log4net.Loggers;

namespace OkulOtomasyon.Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector:IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);
            classAttributes.Add(new ExceptionLogAspect(typeof(DatabaseLogger)));

            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
