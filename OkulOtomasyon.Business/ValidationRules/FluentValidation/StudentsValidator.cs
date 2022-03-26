using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using OkulOtomasyon.Entities.Concrete;

namespace OkulOtomasyon.Business.ValidationRules.FluentValidation
{
    public class StudentsValidator : AbstractValidator<Students>
    {
        public StudentsValidator()
        {

            RuleFor(p => p.IdentityNumber).NotEmpty().WithMessage("T.C Kimlik Alanı Boş Geçilemez");
            When(p => p.IdentityNumber == null, () =>
            {
                RuleFor(p => p.IdentityNumber).NotEmpty().WithMessage("Aranan T.c Kimlikle İlgili Kayıt Bulunamamıştır");
            });
            
        }
    }
}
