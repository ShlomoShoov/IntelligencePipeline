using System;
using IntelligencePipeline.Validation;
using IntelligencePipeline.Extensions;
using IntelligencePipeline.Models.Reports;
using IntelligencePipeline.Calculators;

namespace IntelligencePipeline
{
    class Projram 
    {
        static void Main()
        {
            DroneReport d = new(12, new DateTime(2020, 12, 7), 29.5, 34, "hello00000 weapon", 500, 50);
            ValidationResult r = DroneValidator.Validate(d);
            Console.WriteLine(r);
            Console.WriteLine(StringExtension.InText("t555", "t"));
            Console.WriteLine( PriorityCalculator.Calculate(d));
        }
    }

}