using CleanArchitecture.Application.BuildingBlocks.Contracts.Email.Models;

namespace CleanArchitecture.Application.BuildingBlocks.Contracts.Email.Interfaces
{
    public interface IEmailService
    {
        Task<bool> SendEmailAysnc(EmailReceiver receiver, string subject, string body);
    }
}
