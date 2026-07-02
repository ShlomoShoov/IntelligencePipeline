using System;
using IntelligencePipeline.Validation;
using IntelligencePipeline.Extensions;
using IntelligencePipeline.Models.Reports;

namespace IntelligencePipeline
{
    class Projram 
    {
        static void Main()
        {
            DroneReport d = new(12, new DateTime(2015, 12, 7), 29.5, 34, "hello00000", 500, 1800);
            ValidationResult r = DroneValidator.Validate(d);
            Console.WriteLine(r);
        }
    }

}