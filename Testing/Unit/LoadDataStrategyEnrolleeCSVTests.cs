using DataStrategy.LoadDataStrategy;
using Moq;
using NUnit.Framework;
using System.Linq;

namespace Testing.Unit
{
    public class LoadDataStrategyEnrolleeCSVTests
    {
        MockRepository MockRepository;
        
        [SetUp]
        public void Setup()
        {
            MockRepository = new MockRepository(MockBehavior.Strict) { DefaultValue = DefaultValue.Empty };
        }
        [TearDown]
        public void TearDown()
        {
            MockRepository.VerifyAll();
        }

        [Test]
        [TestCase("", 0)]
        [TestCase( "1,2,3,4,5", 1)]
        [TestCase( "1,2,3,4,5\n1,2,3,4,5",2)]
        public void LoadDataStrategyEnrolleeCSV_Load_Succeeds(string data,int expectedNumberOfRecords)
        {
            var loader = new LoadDataStrategyEnrolleeCSV();
            var entities = loader.Load(data);
            Assert.AreEqual(expectedNumberOfRecords, entities.Count);
            if (expectedNumberOfRecords > 0) Assert.IsNotNull(entities.First().FirstName);
        }
    }
}