using Microsoft.AspNetCore.Http;
using CleanArchitecture.Application.BuildingBlocks.Contracts.FileStorage.Enums;

namespace CleanArchitecture.Application.BuildingBlocks.Contracts.FileStorage.Interfaces
{
    public interface IFileStorage
    {
        /// <summary>
        /// Asynchronously stores a file from a file in the specified file category.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains the stored file's identifier or path.</returns>
        Task<string> StoreAsync(FileCategory fileCategory, IFormFile file, string fileName = default);

        /// <summary>
        /// Asynchronously deletes a file from the specified file category.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task DeleteAsync(FileCategory fileCategory, string fileName);
    }
}
