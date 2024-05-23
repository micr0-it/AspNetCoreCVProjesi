using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class PortfolioValidator : AbstractValidator<Portfolio>
    {
        public PortfolioValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Proje ismi boş geçilemez").NotNull().WithMessage("Proje ismi boş geçilemez");
            RuleFor(p => p.ImgUrl).NotEmpty().WithMessage("Görsel boş geçilemez").NotNull().WithMessage("Görsel boş geçilemez");
            RuleFor(p => p.BigImgUrl).NotEmpty().WithMessage("Görsel boş geçilemez").NotNull().WithMessage("Görsel boş geçilemez");
            RuleFor(p => p.ProjectUrl).NotEmpty().WithMessage("Proje bağlantısı boş geçilemez").NotNull().WithMessage("Proje bağlantısı boş geçilemez");
            RuleFor(p => p.Name).MinimumLength(5).WithMessage("Proje ismi en az 5 karakter olmalıdır.");
            RuleFor(p => p.Name).MaximumLength(75).WithMessage("Proje ismi en fazla 75 karakter olmalıdır.");
        }
    }
}
