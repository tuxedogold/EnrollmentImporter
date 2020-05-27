using Model;
using System;
using Validation.EnrolleeEntity.RuleTypes;

namespace Validation.EnrolleeEntity.Rules
{
    public class EnrolleeIsAdult : RejectEnrolleeRule 
    {
        public override bool IsSatisfiedBy(Enrollee enrollee)
        {
            var age = DateTime.Today.Year - enrollee.DateOfBirth.Year;
            return age > 17;
        }
    }
}
