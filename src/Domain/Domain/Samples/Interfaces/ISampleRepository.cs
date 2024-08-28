using CleanArchitecture.Domain.BuildingBlocks.BaseTypes;
using CleanArchitecture.Domain.BuildingBlocks.Interfaces;

namespace CleanArchitecture.Domain.Samples.Interfaces
{
    public interface ISampleRepository : IBaseRepository<Sample, int>
    {
        /// <summary>
        /// Asynchronously check whether the name is already exist or not
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<bool> AnyNameExistAsync(string name);

        /// <summary>
        /// Asynchronously retrieves a paged list of active Sample objects.
        /// </summary>
        /// <returns></returns>
        Task<PageList<Sample>> PageListActiveAsync(int pageNumber, int pageSize);
    }
}
