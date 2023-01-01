using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validatio_Rules
{
    public class AdressValidator : AbstractValidator<Adress>
    {
        public AdressValidator()
        {
            RuleFor(x => x.Description1).NotEmpty().WithMessage("This are must to be filled.");
            RuleFor(x => x.Description2).NotEmpty().WithMessage("This are must to be filled.");
            RuleFor(x => x.Description3).NotEmpty().WithMessage("This are must to be filled.");
            RuleFor(x => x.Description4).NotEmpty().WithMessage("This are must to be filled.");
            RuleFor(x => x.Location).NotEmpty().WithMessage("This are must to be filled.");

            RuleFor(x => x.Description1).MaximumLength(25).WithMessage("This area cannot be larger than 25 characters. Please fix and try again.");
            RuleFor(x => x.Description2).MaximumLength(25).WithMessage("This area cannot be larger than 25 characters. Please fix and try again.");
            RuleFor(x => x.Description3).MaximumLength(25).WithMessage("This area cannot be larger than 25 characters. Please fix and try again.");
            RuleFor(x => x.Description4).MaximumLength(25).WithMessage("This area cannot be larger than 25 characters. Please fix and try again.");

        }
    }
}
