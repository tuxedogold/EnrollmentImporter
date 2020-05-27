using Validation.FileSystem.Rules;

namespace Validation.FileSystem
{
    public class FileSystemValidator : Validator<string>
    {
        public override void BuildRuleSet() 
        {
            Add(new FileMustExistOnSystem());
        }

        public override void SuccessAction(string path)
        {
        }
        
    }
}
