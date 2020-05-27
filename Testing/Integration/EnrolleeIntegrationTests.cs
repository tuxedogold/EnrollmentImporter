using NUnit.Framework;
using System.IO;
using EnrollmentImporter;
using System.Linq;
using System.Diagnostics;
using System;

namespace Testing.Integration
{
    public class EnrolleeIntegrationTests
    {
        [SetUp]
        public void Setup()
        {
        }
        [TearDown]
        public void TearDown()
        {
        }
        [Test]
        public void EnrolleeIntegration_Succeeds()
        {
            #region Given a well formed file with two records
            var payload = 
@"John,Candy,10311950,HSA,06102020
Chris,Farley,02151964,HRA,06112020";
            var filename = "data.dat";
            var path = Path.Join(Directory.GetCurrentDirectory(), filename);

            File.WriteAllText(path, payload);

            #endregion


            #region When Enrollemnt is Imported
            var enrollees = Program.Go(new string[] { path });

            #endregion

            #region Then two records have been processed
            Assert.AreEqual(enrollees.Count(), payload.Split('\n').Count());

            File.Delete(path);
            #endregion
        }
       
        [Test]
        public void EnrolleeIntegration_HaltsValidation()
        {
            #region Given a file with incomplete data records
            var payload =
@"John,Candy,HSA,06102020
Chris,Farley,02151964,HRA,06112020"; //DOB missing
            var filename = "data.dat";
            var path = Path.Join(Directory.GetCurrentDirectory(), filename);
            var executable = Path.Join(Directory.GetCurrentDirectory(), "EnrollmentImporter.exe");
            File.WriteAllText(path, payload);

            #endregion

            #region When Enrollemnt is Imported Then error is present, thus halting has been reached

            var ex = Assert.Throws<InvalidDataException>(() => Program.Go(new string[] { path }));
            File.Delete(path);
            #endregion
        }
        
    }
}
