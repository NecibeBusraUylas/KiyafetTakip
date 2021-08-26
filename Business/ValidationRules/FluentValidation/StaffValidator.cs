using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class StaffValidator : AbstractValidator<Staff>
    {
        public StaffValidator()
        {
            RuleFor(p => p.EmployeeNumber).NotEmpty();
            RuleFor(p => p.NameSurname).NotEmpty();
            RuleFor(p => p.CardNumber).NotEmpty();
        }
    }
}