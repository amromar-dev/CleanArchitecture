using CleanArchitecture.Domain.BuildingBlocks.Interfaces;
using CleanArchitecture.SharedKernels.Localizations;

namespace CleanArchitecture.Domain.Samples.Rules
{
    public record SampleNameRequiredRule(string Name) : IBusinessRule
    {
        public string Message => Localization.NameIsRequired;

        public bool IsBroken() => string.IsNullOrEmpty(Name);
    }
}