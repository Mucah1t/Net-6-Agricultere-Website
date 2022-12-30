using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace BusinessLayer.Validatio_Rules
{
    public class TeamValidator : AbstractValidator<Team>
    {
        public TeamValidator() //To use validation you need to construct
        {
            RuleFor(x => x.PersonName).NotEmpty().WithMessage("This area has to be filled.");
            RuleFor(x=>x.PersonDuty).NotEmpty().WithMessage("This area has to be filled.");

            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("This area has to be filled.");

            RuleFor(x => x.PersonName).MaximumLength(50).WithMessage("Person Name cannot be larger than 50 characters.");
            RuleFor(x => x.PersonName).MinimumLength(5).WithMessage("Person Name cannot be smaller than 5 characters.");

            RuleFor(x => x.PersonDuty).MaximumLength(50).WithMessage("Person's duty cannot be larger than 50 characters.");

        }
    }
}
