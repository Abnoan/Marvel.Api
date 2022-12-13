using FluentValidation;
using Marvel.Application.Commands.Update;

namespace Marvel.Application.Validators
{
    public class UpdateHeroCommandValidator : AbstractValidator<UpdateHeroCommand>
    {
        public UpdateHeroCommandValidator()
        {
            RuleFor(p => p.Id)
               .NotNull()
               .NotEmpty()
               .WithMessage("You need to provide a Id");
        }
    }
}
