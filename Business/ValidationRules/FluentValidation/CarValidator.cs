using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(p => p.Description).MinimumLength(2).WithMessage("Açıklama en az 2 harf içermelidir");
            RuleFor(p => p.Description).NotEmpty().WithMessage("Açıklama boş olamaz");
            RuleFor(p =>p.DailyPrice).NotEmpty().WithMessage("Günlük ücret boş bırakılamaz");
            RuleFor(p => p.DailyPrice).GreaterThan(100).WithMessage("Günlük ücret 100 den düşük olamaz");   
            RuleFor(p => p.ModelYear).GreaterThanOrEqualTo("2022").When(p=>p.BrandId==5).WithMessage("Description");

        }
    }
}
