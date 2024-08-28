using CleanArchitecture.Infrastructure.FileStorage.FileLocalStorage.Configurations;
using Microsoft.AspNetCore.Http;
using CleanArchitecture.Application.BuildingBlocks.Contracts.FileStorage.Enums;
using CleanArchitecture.Application.BuildingBlocks.Contracts.FileStorage.Interfaces;
using CleanArchitecture.SharedKernels.Exceptions;
using CleanArchitecture.SharedKernels.Localizations;

namespace CleanArchitecture.Infrastructure.FileStorage.FileLocalStorage
{
    public class FileLocalStorageService : IFileStorage
    {
        private readonly FileLocalStorageConfig config;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        public FileLocalStorageService(FileLocalStorageConfig config)
        {
            this.config = config ?? throw new ArgumentNullException(nameof(config));
        }

        /// <summary>
        /// Asynchronously stores a file from a file in the specified file category.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains the stored file's identifier or path.</returns>
        public async Task<string> StoreAsync(FileCategory fileCategory, IFormFile file, string fileName = default)
        {
            ArgumentNullException.ThrowIfNull(file);

            var storeFileName = fileName;
            if (string.IsNullOrEmpty(storeFileName))
                storeFileName = $"{Guid.NewGuid:N}_{Path.GetExtension(file.FileName)}";

            var storeFolder = GetOrCreateFolder(fileCategory);
            var storeFilePath = Path.Combine(storeFolder, storeFileName);

            using var fileStream = new FileStream(storeFilePath, FileMode.Create);
            await file.CopyToAsync(fileStream);

            return storeFileName;
        }

        /// <summary>
        /// Asynchronously deletes a file from the specified file category.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public Task DeleteAsync(FileCategory fileCategory, string fileName)
        {
            ArgumentException.ThrowIfNullOrEmpty(fileName);

            var storeFolder = GetOrCreateFolder(fileCategory);
            var storeFile = Path.Combine(storeFolder, fileName);

            if (File.Exists(storeFile))
                File.Delete(storeFile);

            return Task.CompletedTask;
        }

        #region Private Methods

        private string GetOrCreateFolder(FileCategory fileCategory)
        {
            var folderPath = Path.Combine(config.StoragePath, fileCategory.ToString());

            try
            {
                Directory.CreateDirectory(folderPath);
                return folderPath;
            }
            catch
            {
                throw new BadRequestException(Localization.ErrorCreatingFolder);
            }
        }

        #endregion
    }
}
