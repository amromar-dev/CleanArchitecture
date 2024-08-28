using FluentValidation;

namespace CleanArchitecture.Application.Features.Samples.Commands
{
    public class CreateSampleValidator : AbstractValidator<CreateSampleCommand>
    {
        public CreateSampleValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}
