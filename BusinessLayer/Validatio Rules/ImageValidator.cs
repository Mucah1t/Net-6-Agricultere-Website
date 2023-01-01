using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validatio_Rules
{
    public class ImageValidator : AbstractValidator<Image>
    {
        public ImageValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("This area has to be filled.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("This area has to be filled.");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("This area has to be filled.");

            RuleFor(x => x.Title).MaximumLength(20).WithMessage("Title cannot be larger than 20 characters.");
            RuleFor(x => x.Description).MaximumLength(40).WithMessage("Title cannot be larger than 40 characters.");

        }
    }
}
