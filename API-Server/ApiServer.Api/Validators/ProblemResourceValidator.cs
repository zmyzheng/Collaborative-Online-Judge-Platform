using ApiServer.Api.Resources;
using FluentValidation;

namespace ApiServer.Api.Validators
{
    public class ProblemResourceValidator : AbstractValidator<ProblemResource>
    {
        public ProblemResourceValidator()
        {
            RuleFor(ProblemResource => ProblemResource.Name)
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage("Problem name cannot be empty or longer than 50");
        }
    }
}