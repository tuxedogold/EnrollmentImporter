using Validation.CLIParameter.Rules;

namespace Validation.CLIParameter
{
    public class CLIArgumentValidator : Validator<string[]>
    {   
        public override void BuildRuleSet()
        {
            Add(new FirstParameterRequired());
        }

        public override void SuccessAction(string[] args)
        {
        }
    }
}
