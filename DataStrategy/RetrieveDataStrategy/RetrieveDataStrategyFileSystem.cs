using System.IO;

namespace EnrollmentImporter.RetrieveDataStrategy
{
    public class RetrieveDataStrategyFileSystem : IRetrieveDataStrategy
    {
        public string Retrieve(string path)
        {
           var csvData = File.ReadAllText(path);
            return csvData;
        }
    }
}
