using CleanArchitecture.Application.BuildingBlocks.Executions.Commands;
using CleanArchitecture.Application.BuildingBlocks.Executions.Results;
using CleanArchitecture.Domain.Samples;
using CleanArchitecture.Domain.Samples.Interfaces;
using CleanArchitecture.Domain.BuildingBlocks.Interfaces;
using CleanArchitecture.SharedKernels.Exceptions;
using CleanArchitecture.SharedKernels.Localizations;
using CleanArchitecture.Application.BuildingBlocks.Contracts.Identity;

namespace CleanArchitecture.Application.Features.Samples.Commands
{
    public class CreateSampleCommandHandler(ISampleRepository sampleRepository, IUnitOfWork unitOfWork, IIdentityContext context) : CommandHandler<CreateSampleCommand, int>
    {
        public override async Task<IRequestResult<int>> Handle(CreateSampleCommand request, CancellationToken cancellationToken)
        {
            await GuardDuplicatedName(request.Name);

            Sample sample = new (request.Name, context.GetUserId());
            sampleRepository.Add(sample);

            await unitOfWork.CommitAsync(cancellationToken);

            return Result(sample.Id);
        }

        #region Private Methods
        
        private async Task GuardDuplicatedName(string name)
        {
            bool nameAlreadyExist = await sampleRepository.AnyNameExistAsync(name);
            if (nameAlreadyExist)
                throw new BusinessRuleException(Localization.NameAlreadyExist);
        } 

        #endregion
    }
}
