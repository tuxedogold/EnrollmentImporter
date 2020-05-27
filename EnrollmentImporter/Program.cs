using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Validation.FileSystem;
using Validation.CLIParameter;
using EnrollmentImporter.RetrieveDataStrategy;
using DataStrategy.LoadDataStrategy;
using Validation.EnrolleeEntity;
using System.IO;

namespace EnrollmentImporter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Go(args);
            }
            catch(Exception e)
            {
                File.AppendAllText("Error.log",$"{DateTime.Now} \n {e} \n {e.Message} \n\n");
                Console.WriteLine("A record in the file failed validation. Processing has stopped.");
                Environment.Exit(1);
            }
        }
        public static List<Enrollee> Go(string[] args)
        {
            Console.WriteLine("asdfasdfasdf");
            Validate(args);
            var rawData = new RetrieveDataStrategyFileSystem().Retrieve(args[0]);
            var loadDataStrategy = new LoadDataStrategyEnrolleeCSV();
            var enrollees = loadDataStrategy.Load(rawData);
            new EnrolleeValidator().ValidateAll(enrollees);
            Display(enrollees.ToList());
            return enrollees;
        }

        private static void Validate(string[] args)
        {
            new CLIArgumentValidator().ValidateRule(args);
            new FileSystemValidator().ValidateRule(args[0]);    
        }


        private static void Display(List<Enrollee> enrollees)
        {
            enrollees.ForEach((Action<Enrollee>)(entity =>
            {
                Console.WriteLine($"{entity.ProcessingStatus}, {entity.FirstName}, {entity.LastName}, {entity.DateOfBirth.ToShortDateString()}, {entity.Args[3]}, {entity.EffectiveDate.ToShortDateString()}, ");
            }));
        }
    }
}
