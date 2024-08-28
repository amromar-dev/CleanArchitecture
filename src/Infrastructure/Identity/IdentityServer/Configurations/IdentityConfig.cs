using CleanArchitecture.SharedKernels.DependencyInjections;

namespace CleanArchitecture.Infrastructure.Identity.IdentityServer.Configurations
{
    public class IdentityConfig : IConfig
    {
        public string Authority { get; set; }
        
        public string Audience { get; set; }
        
        public string JsonFileName => "IdentityServer";
    }
}
