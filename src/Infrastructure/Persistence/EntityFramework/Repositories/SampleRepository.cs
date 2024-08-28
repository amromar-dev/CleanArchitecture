using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Domain.BuildingBlocks.BaseTypes;
using CleanArchitecture.Domain.Samples;
using CleanArchitecture.Domain.Samples.Enums;
using CleanArchitecture.Domain.Samples.Interfaces;
using CleanArchitecture.Infrastructure.Persistence.EntityFramework.Repositories.Base;

namespace CleanArchitecture.Infrastructure.Persistence.EntityFramework.Repositories
{
    public class SampleRepository(ApplicationDbContext dbContext) : BaseRepository<Sample, int>(dbContext), ISampleRepository
    {
        public Task<bool> AnyNameExistAsync(string name)
        {
            return dbSet.Where(s => s.Name == name).AnyAsync();
        }

        public Task<PageList<Sample>> PageListActiveAsync(int pageNumber, int pageSize)
        {
            IQueryable<Sample> query = dbSet.Where(s => s.Status == SampleStatus.Active).OrderBy(s => s.Auditing.CreatedAt);
            return GetPagedResultAsync(query, pageNumber, pageSize);
        }
    }
}
