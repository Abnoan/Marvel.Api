using FluentValidation;
using Marvel.Application.Commands.Create;

namespace Marvel.Application.Validators
{
    public class CreateHeroCommandValidator : AbstractValidator<CreateHeroCommand>
    {
        public CreateHeroCommandValidator()
        {
            RuleFor(p => p.Name)
             .NotNull()
             .NotEmpty()
             .WithMessage("Name can't be null or empty");

            RuleFor(p => p.AttackPower)
            .NotNull()
            .WithMessage("You need to provide a AttackPower.");

            RuleFor(p => p.DefensePower)
             .NotNull()
             .WithMessage("You need to provide a DefensePower.");

            RuleFor(p => p.AttackPower)
            .GreaterThan(0)
            .LessThanOrEqualTo(100)
            .WithMessage("Attack Power needs to be between 0 and 100.");

            RuleFor(p => p.DefensePower)
            .GreaterThan(0)
            .LessThanOrEqualTo(100)
            .WithMessage("Defense Power needs to be between 0 and 100.");

            RuleFor(p => p.HP)
            .NotNull()
            .NotEmpty()
            .WithMessage("You need to provide HP.");

            RuleFor(p => p.HP)
           .GreaterThan(0)
           .LessThanOrEqualTo(500)
           .WithMessage("Hp needs to be between 0 and 500.");
        }
    }
}
