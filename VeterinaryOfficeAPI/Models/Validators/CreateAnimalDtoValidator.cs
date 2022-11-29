using FluentValidation;
using FluentValidation.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinaryOfficeAPI.Models.Validators
{
    public class CreateAnimalDtoValidator : AbstractValidator<CreateAnimalDto>
    {
        private const string PhoneNumberValidator = @"^(\+48)?[0-9]{9}$";

        public CreateAnimalDtoValidator()
        {
            RuleFor(x => x.Species)
                .NotEmpty()
                .MaximumLength(54);
            RuleFor(x => x.Breed)
                .NotEmpty()
                .MaximumLength(54);
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(60);
            RuleFor(x => x.Size)
                .NotEmpty();
            RuleFor(x => x.DateOfBirth)
                .LessThanOrEqualTo(DateTime.Now);
            RuleFor(x => x.Weight)
                .NotEmpty()
                .ScalePrecision(2, 6, false);
            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .Matches(PhoneNumberValidator);
            RuleFor(x => x.FirstVisit)
                .LessThanOrEqualTo(DateTime.Now)
                .LessThanOrEqualTo(x => x.LastVisit);
            RuleFor(x => x.LastVisit)
                .LessThanOrEqualTo(DateTime.Now)
                .GreaterThanOrEqualTo(x => x.FirstVisit);
        }
    }
}
