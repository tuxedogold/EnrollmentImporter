using Model;
using System;
using System.Globalization;
using Validation.EnrolleeEntity.RuleTypes;

namespace Validation.EnrolleeEntity.Rules
{
    public class ValidFormatForDOB : HaltRule<Enrollee> 
    {
        public override bool IsSatisfiedBy(Enrollee enrollee)
        {
            string[] formats = { Enrollee.DateFormat };
            return DateTime.TryParseExact(enrollee.Args[2], formats, new CultureInfo("en-US"),
                                        DateTimeStyles.None, out var expectedDate);   
        }
    }
}
