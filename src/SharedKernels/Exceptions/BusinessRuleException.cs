using CleanArchitecture.SharedKernels.Exceptions.Base;

namespace CleanArchitecture.SharedKernels.Exceptions
{
    public class BusinessRuleException : BaseException
    {
        public BusinessRuleException(string message) : base(message)
        {

        }

        public BusinessRuleException(string message, Exception innerException) : base(message, innerException)
        {

        }

        public override int ExceptionCode => 400;
    }
}
