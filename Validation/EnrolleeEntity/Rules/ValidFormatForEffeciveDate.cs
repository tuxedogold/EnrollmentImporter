using Model;
using System;
using System.Globalization;
using Validation.EnrolleeEntity.RuleTypes;

namespace Validation.EnrolleeEntity.Rules
{
    public class ValidFormatForEffectiveDate : HaltRule<Enrollee> 
    {
        public override bool IsSatisfiedBy(Enrollee enrollee)
        {
            string[] formats = { Enrollee.DateFormat };
            var parsed = 
             DateTime.TryParseExact(enrollee.Args[4], formats, new CultureInfo("en-US"),
                                        DateTimeStyles.None, out var expectedDate);
            return parsed;
        }
    }
}
