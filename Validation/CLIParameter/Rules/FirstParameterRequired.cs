using System;

namespace Validation.CLIParameter.Rules
{
    public class FirstParameterRequired : IRule<string[]>
    {
        public void FailureAction(string[] args)
        {
            throw new ArgumentException(@"Failure to provide path to required file as first argument to the execution. 
 Supply the full path to the expected file to process.
e.g.
EnrollemntImporter.exe C:\importroster.csv
");
        }

        public bool IsSatisfiedBy(string[] args)
        {
            return args != null && args.Length > 0 && !string.IsNullOrEmpty(args[0]);
        }
    }
}
