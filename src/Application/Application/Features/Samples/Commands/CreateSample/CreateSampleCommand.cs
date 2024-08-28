using CleanArchitecture.Application.BuildingBlocks.Executions.Commands;

namespace CleanArchitecture.Application.Features.Samples.Commands
{
    public class CreateSampleCommand : ICommand<int>
    {
        public string Name { get; set; }
    }
}
