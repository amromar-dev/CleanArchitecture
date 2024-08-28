using CleanArchitecture.Domain.Samples.Enums;
using CleanArchitecture.SharedKernels.Localizations;
using CleanArchitecture.Domain.BuildingBlocks.Interfaces;

namespace CleanArchitecture.Domain.Samples.Rules
{
    public class SampleMustActiveRule(Sample sample) : IBusinessRule
    {
        public bool IsBroken() => sample.Status != SampleStatus.Active;

        public string Message => Localization.SampleMustBeActive;
    }
}
