using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using Validation;

namespace Testing.Unit
{
    public class ValidatorTests
    {
        MockRepository MockRepository;
        Mock<Validator<object>> mockValidator;
        Mock<IRule<object>> mockRule;
        object entity;

        [SetUp]
        public void Setup()
        {
            entity = null;
            MockRepository = new MockRepository(MockBehavior.Loose) { DefaultValue = DefaultValue.Mock };
            mockRule = MockRepository.Create<IRule<object>>();

            mockValidator = MockRepository.Create<Validator<object>>
                (new List<IRule<object>>{ mockRule.Object });
            mockValidator.CallBase = true;
        }
        [TearDown]
        public void TearDown()
        {
            MockRepository.VerifyAll();
        }

        #region Validate
        [Test]
        public void Validator_Validate_Success()
        {
            mockValidator.Setup(e => e.SuccessAction(entity)).Verifiable();
            mockRule.Setup(e => e.IsSatisfiedBy(entity)).Returns(true);
            var valid = mockValidator.Object.ValidateRule(entity);
            Assert.IsTrue(valid); 
        }

        [Test]
        public void Validator_Validate_InvalidRule()
        {
            mockRule.Setup(e => e.IsSatisfiedBy(entity)).Returns(false);
            mockRule.Setup(e => e.FailureAction(entity)).Verifiable();
            
            var valid = mockValidator.Object.ValidateRule(entity);
            Assert.IsFalse(valid);
        }
        #endregion

        #region validator_ValidateAll
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void Validator_ValidateAll(bool succeeds)
        {
            List<object> entities = new List<object>();
            entities.Add(entity);
            mockValidator.Setup(e => e.ValidateRule(entity)).Returns(succeeds);
            var valid = mockValidator.Object.ValidateAll(entities);

            Assert.AreEqual(succeeds,valid);
        }
        #endregion

    }
}