using Model;

namespace Validation.EnrolleeEntity.RuleTypes
{
   public abstract class RejectEnrolleeRule : IRule<Enrollee>
    {
        public void FailureAction(Enrollee entity)
        {
            entity.ProcessingStatus = ProcessingStatus.Rejected;
        }
        public abstract bool IsSatisfiedBy(Enrollee entity);

    }
}
