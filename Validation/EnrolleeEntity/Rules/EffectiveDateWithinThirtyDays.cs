using Model;
using System;
using Validation.EnrolleeEntity.RuleTypes;

namespace Validation.EnrolleeEntity.Rules
{
    public class EffectiveDateWithinThirtyDays : RejectEnrolleeRule 
    {
        public override bool IsSatisfiedBy(Enrollee enrollee)
        {
            const int maxDays = 30;
            return enrollee.EffectiveDate < DateTime.Today.AddDays(maxDays);
        }
    }
}
