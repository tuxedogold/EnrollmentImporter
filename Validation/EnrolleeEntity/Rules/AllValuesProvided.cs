using Model;
using Validation.EnrolleeEntity.RuleTypes;

namespace Validation.EnrolleeEntity.Rules
{
    public class AllValuesProvided : HaltRule<Enrollee> 
    {
        public override bool IsSatisfiedBy(Enrollee enrollee)
        {
            return enrollee.Args.Length == 5;
        }
    }
}
