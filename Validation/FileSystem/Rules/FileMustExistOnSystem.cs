using System.IO;

namespace Validation.FileSystem.Rules
{
    class FileMustExistOnSystem : IRule<string>
    {
        public void FailureAction(string path)
        {
            throw new FileNotFoundException($"The following supplied path does not exist or cannot be accessed on the file system {path}");
        }

        public bool IsSatisfiedBy(string path) => File.Exists(path);
    }
}
