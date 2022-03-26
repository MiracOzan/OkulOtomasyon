using System;
using System.Linq;
using FluentValidation;
using OkulOtomasyon.Core.CrossCuttingConcerns.Validation.FluentValidation;
using PostSharp.Aspects;

namespace OkulOtomasyon.Core.Aspects.PostSharp.ValidationAspects
{
    [Serializable]
    public class FluentValidationAspects : OnMethodBoundaryAspect
    {
        Type _validatorType;

        public FluentValidationAspects(Type validatorType)
        {
            _validatorType = validatorType;
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entitytype = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = args.Arguments.Where(t => t.GetType() == entitytype);

            foreach (var entity in entities)
            {
                ValidatorTool.FluentValidate(validator, entity);
            }
        }
    }
}
