using CleanArchitecture.SharedKernels.DependencyInjections;

namespace CleanArchitecture.Infrastructure.Email.Smtp.Configurations
{
    public record SmtpConfig : IConfig
    {
        public string EmailSmtpHost { get; set; }

        public int EmailSmtpPort { get; set; }

        public string EmailAddressFrom { get; set; }

        public string EmailFromPassword { get; set; }

        public bool EnableSSL { get; set; }

        public bool IgnoreSslErrors { get; set; }

        public string JsonFileName => "Smtp";
    }
}
