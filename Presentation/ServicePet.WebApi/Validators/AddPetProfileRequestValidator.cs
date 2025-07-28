using FluentValidation;
using ServicePet.WebApi.Models.Requests;

namespace ServicePet.WebApi.Validators
{
    public class AddPetProfileRequestValidator : AbstractValidator<AddPetProfileRequest>
    {
        public AddPetProfileRequestValidator()
        {
            RuleFor(x => x.ProfileId)
                .NotEmpty()
                .WithMessage("ProfileId не заполнен.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name не заполнен.");

            RuleFor(x => x.Type)
                .NotEmpty()
                .WithMessage("Type не заполнен.");

            RuleFor(x => x.Gender)
                .NotEmpty()
                .WithMessage("Gender is required.");

            RuleFor(x => x.Age)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Age не может быть отрицательным.")
                .LessThanOrEqualTo(30)
                .WithMessage("Age не может превышать 30.");
        }
    }
}
