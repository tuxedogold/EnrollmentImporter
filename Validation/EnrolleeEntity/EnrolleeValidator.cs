using Model;
using Validation.EnrolleeEntity.Rules;

namespace Validation.EnrolleeEntity
{
    public class EnrolleeValidator : Validator<Enrollee>
    {
        public override void BuildRuleSet()
        {
            Add(new AllValuesProvided());
            Add(new AllValuesNotNull<Enrollee>());
            Add(new ValidFormatForDOB());
            Add(new ValidFormatForEffectiveDate());
            Add(new ValidPlanType());

            Add(new EffectiveDateWithinThirtyDays());
            Add(new EnrolleeIsAdult());
        }
        public override void SuccessAction(Enrollee enrollee)
        {
            enrollee.ProcessingStatus = ProcessingStatus.Approved;
        }
    }
 }

