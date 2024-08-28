using CleanArchitecture.Application.BuildingBlocks.Contracts.Scheduler.Interfaces;
using CleanArchitecture.Domain.Samples.Interfaces;

namespace CleanArchitecture.Application.BackgroundJobs
{
    public class DeactiveExpiredSampleBackgroundJob(ISampleRepository sampleRepository) : IRecurringJob
    {
        public async Task Execute()
        {
            var activeSamples = await sampleRepository.ListAsync();
            _ = activeSamples.Count;

            // Actions Here 
        }
    }
}