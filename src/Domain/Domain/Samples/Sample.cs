using CleanArchitecture.Domain.Samples.Enums;
using CleanArchitecture.Domain.Samples.Events;
using CleanArchitecture.Domain.Samples.Rules;
using CleanArchitecture.Domain.BuildingBlocks.BaseTypes;

namespace CleanArchitecture.Domain.Samples
{
    public class Sample : DomainEntity<int>
    {
        #region Constructors

        private Sample()
        {

        }

        public Sample(string name, int actionUserId) : base(actionUserId)
        {
            CheckRule(new SampleNameRequiredRule(name));

            Name = name;
            Status = SampleStatus.Active;
        }

        #endregion

        #region Members

        public string Name { get; private set; }

        public SampleStatus Status { get; private set; }

        #endregion

        #region Behaviours

        /// <summary>
        /// Changes the name of the entity and logs the modification for auditing purposes.
        /// </summary>
        /// <param name="name">The new name of the entity.</param>
        /// <param name="actionUserId">The ID of the user who performed the name change.</param>
        public void ChangeName(string name, int actionUserId)
        {
            CheckRule(new SampleMustActiveRule(this));
            CheckRule(new SampleNameRequiredRule(name));

            Name = name;
            LogModification(actionUserId);

            AddDomainEvent(new SampleNameChangedEvent(this.Id));
        }

        #endregion

        #region Private Methods

        #endregion
    }
}
