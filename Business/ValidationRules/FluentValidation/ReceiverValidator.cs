using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ReceiverValidator : AbstractValidator<Receiver>
    {
        public ReceiverValidator()
        {
            RuleFor(p => p.EmployeeNumber).NotEmpty();
            RuleFor(p => p.NameSurname).NotEmpty();
            RuleFor(p => p.CardNumber).NotEmpty();
            RuleFor(p => p.Department).NotEmpty();
            RuleFor(p => p.Division).NotEmpty();
            RuleFor(p => p.Clothe).NotEmpty();
            RuleFor(p => p.Time).NotEmpty();
        }
    }
}
