using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ClotheValidator : AbstractValidator<Clothe>
    {
        public ClotheValidator()
        {
            RuleFor(c => c.Type).NotEmpty();
        }
    }
}