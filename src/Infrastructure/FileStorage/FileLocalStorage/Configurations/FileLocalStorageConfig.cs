using CleanArchitecture.SharedKernels.DependencyInjections;

namespace CleanArchitecture.Infrastructure.FileStorage.FileLocalStorage.Configurations
{
    public record FileLocalStorageConfig : IConfig
    {
        public string StoragePath { get; set; }

        public string JsonFileName => "FileLocalStorage";
    }
}
