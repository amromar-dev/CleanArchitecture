using CleanArchitecture.SharedKernels.Exceptions.Base;

namespace CleanArchitecture.SharedKernels.Exceptions
{
    public class BadRequestException : BaseException
    {
        public BadRequestException(string message) : base(message)
        {

        }

        public BadRequestException(string message, Exception innerException) : base(message, innerException)
        {

        }

        public override int ExceptionCode => 400;
    }
}
