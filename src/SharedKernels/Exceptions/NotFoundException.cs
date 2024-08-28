using CleanArchitecture.SharedKernels.Exceptions.Base;

namespace CleanArchitecture.SharedKernels.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(string message) : base(message)
        {

        }

        public NotFoundException(string message, Exception innerException) : base(message, innerException)
        {

        }

        public override int ExceptionCode => 404;
    }
}
