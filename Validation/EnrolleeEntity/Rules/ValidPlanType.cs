using Model;
using Validation.EnrolleeEntity.RuleTypes;

namespace Validation.EnrolleeEntity.Rules
{
    public class ValidPlanType : HaltRule<Enrollee> 
    {
        public override bool IsSatisfiedBy(Enrollee entity)
        {
            return entity.PlanType != PlanType.Invalid;
        }
    }
}