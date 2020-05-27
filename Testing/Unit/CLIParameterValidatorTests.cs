using Moq;
using NUnit.Framework;

namespace Testing.Unit
{
    public class CLIParameterValidatorTests
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
        [TestCase(new string[] { "dat" }, true)]
        [TestCase(new string[] { "" },false)]
        [TestCase(new string[] { }, false)]
        [TestCase(new string[] {null }, false)]
        [TestCase(null,false)]
        public void CLIParameterValidator_FirstParameterRequired(string[] args,bool succeeds)
        {
            var rule = new Validation.CLIParameter.Rules.FirstParameterRequired();

            Assert.AreEqual(succeeds, rule.IsSatisfiedBy(args));
        }
    }
}