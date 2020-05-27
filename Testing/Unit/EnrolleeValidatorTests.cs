using Model;
using Moq;
using NUnit.Framework;
using System;
using Validation.EnrolleeEntity;
using Validation.EnrolleeEntity.Rules;

namespace Testing.Unit
{
    public class EnrolleeValidatorTests
    {
        MockRepository MockRepository;
        Enrollee enrollee;
        EnrolleeValidator enrolleeValidator;

        [SetUp]
        public void Setup()
        {
            MockRepository = new MockRepository(MockBehavior.Strict) { DefaultValue = DefaultValue.Empty };
            enrollee = new Enrollee
            {
                DateOfBirth = DateTime.Today.AddYears(-20),
                EffectiveDate = DateTime.Today.AddDays(20),
                FirstName = "Mickey",
                LastName = "Mouse",
                PlanType = PlanType.HSA
            };
            enrolleeValidator = new EnrolleeValidator();

        }
        [TearDown]
        public void TearDown()
        {
            MockRepository.VerifyAll();
        }


        #region Rules
        #region AllValuesAreNull

        [Test]        
        public void EnrolleeValidator_AllValuesNotNull_Succeeds()
        {
            var rule = new AllValuesNotNull<Enrollee>();
            Assert.IsTrue(rule.IsSatisfiedBy(enrollee));
        }
        [Test]
        public void EnrolleeValidator_AllValuesNotNull_SinglePropertyNull()
        {
            enrollee.FirstName = null;
            var rule = new AllValuesNotNull<Enrollee>();

            Assert.IsFalse(rule.IsSatisfiedBy(enrollee));
        }
        [Test]
        public void EnrolleeValidator_AllValuesNotNull_AllNull()
        {
            var rule = new AllValuesNotNull<Enrollee>();
            Assert.IsFalse(rule.IsSatisfiedBy(enrollee));
        }
        #endregion
        
        #region AllValuesProvided

        [Test]
        public void EnrolleeValidator_AllValuesProvided_Succeeds()
        {
            var rule = new AllValuesProvided();
            Assert.IsTrue(rule.IsSatisfiedBy(enrollee));
        }
        [Test]
        public void EnrolleeValidator_AllValuesProvided_OneValueMissing()
        {
            var rule = new AllValuesProvided();
            enrollee = new Enrollee(new string[4] { "Element 1", "Element 2", "Element 3", "Element 4" });
            Assert.IsFalse(rule.IsSatisfiedBy(enrollee));
        }
        [Test]
        public void EnrolleeValidator_AllValuesProvided_AllMissing()
        {
            var rule = new AllValuesProvided();
            enrollee = new Enrollee(new string[0] { });
            Assert.IsFalse(rule.IsSatisfiedBy(enrollee));
        }
        #endregion

        #region EffectiveDateExceedsMax
        [Test]
        public void EnrolleeValidator_EffectiveDateWithinThirtyDays_Succeeds()
        {
            var rule = new EffectiveDateWithinThirtyDays();
            Assert.IsTrue(rule.IsSatisfiedBy(enrollee));
        }
        [Test]
        public void EnrolleeValidator_EffectiveDateWithinThirtyDays_Exceeds()
        {
            var rule = new EffectiveDateWithinThirtyDays();

            enrollee.EffectiveDate = DateTime.Today.AddDays(31);
            Assert.IsFalse(rule.IsSatisfiedBy(enrollee));
        }
        #endregion

        #region EnrolleeIsAdult
        [Test]
        public void EnrolleeValidator_EnrolleeIsAdult_Succeeds()
        {
            var rule = new EnrolleeIsAdult();

            Assert.IsTrue(rule.IsSatisfiedBy(enrollee));
        }
        [Test]
        public void EnrolleeValidator_EnrolleeIsAdult_IsChild()
        {
            var rule = new EnrolleeIsAdult();

            enrollee.DateOfBirth = DateTime.Today.AddYears(-16);
            Assert.IsFalse(rule.IsSatisfiedBy(enrollee));
        }
        #endregion

        #region ValidFormatForDOB
        [Test]
        public void EnrolleeValidator_ValidFormatForDOB_Succeeds()
        {
            var rule = new ValidFormatForDOB();
            Assert.IsTrue(rule.IsSatisfiedBy(enrollee));
        }
        [Test]

        public void EnrolleeValidator_ValidFormatForDOB_WrongFormat()
        {
            var rule = new ValidFormatForDOB();

            enrollee.Args[2] = "19860103";
            Assert.IsFalse(rule.IsSatisfiedBy(enrollee));
        }
        [Test]
        public void EnrolleeValidator_ValidFormatForDOB_NotADateTime()
        {
            var rule = new ValidFormatForDOB();

            enrollee.Args[2] = "abcdefg";
            Assert.IsFalse(rule.IsSatisfiedBy(enrollee));
        }

        #endregion

        #region ValidFormatForEffectiveDate
        [Test]
        public void EnrolleeValidator_ValidFormatForEffectiveDate_Succeeds()
        {
            var rule = new ValidFormatForEffectiveDate();
            Assert.IsTrue(rule.IsSatisfiedBy(enrollee));
        }

        [Test]
        public void EnrolleeValidator_ValidFormatForEffectiveDate_WrongFormat()
        {
            var rule = new ValidFormatForEffectiveDate();

            enrollee.Args[4] = "19860103";
            Assert.IsFalse(rule.IsSatisfiedBy(enrollee));
        }

        [Test]
        public void EnrolleeValidator_ValidFormatForEffectiveDate_NotADateTime()
        {
            var rule = new ValidFormatForEffectiveDate();

            enrollee.Args[4] = "xyzzy";
            Assert.IsFalse(rule.IsSatisfiedBy(enrollee));
        }
        #endregion

        #region ValidPlanType
        [Test]
        public void EnrolleeValidator_ValidPlanType_Succeeds()
        {
            var rule = new ValidPlanType();

            Assert.IsTrue(rule.IsSatisfiedBy(enrollee));
        }

        [Test]
        public void EnrolleeValidator_Valid_PlanType_BadPlan()
        {
            var rule = new ValidPlanType();

            enrollee.Args[3] = "oauhsg";
            Assert.IsFalse(rule.IsSatisfiedBy(enrollee));
        }
        #endregion


        #endregion

    }
}