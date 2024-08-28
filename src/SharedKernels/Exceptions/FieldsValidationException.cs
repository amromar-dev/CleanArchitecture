using CleanArchitecture.SharedKernels.Exceptions.Base;

namespace CleanArchitecture.SharedKernels.Exceptions
{
    public class FieldsValidationException(List<string> validations) : BaseException("One or more validation errors occurred.")
    {
        public override int ExceptionCode => 400;

        public List<string> Validations { get; } = validations;
    }
}
