using System;
using IntelligencePipeline.Validation;
using IntelligencePipeline.Extensions;
using IntelligencePipeline.Models.Reports;
using IntelligencePipeline.Calculators;
using IntelligencePipeline.Pipeline;
using IntelligencePipeline.UI;

namespace IntelligencePipeline
{
    class Projram 
    {
        static void Main()
        {
            DroneReport d = new(12, new DateTime(2020, 12, 7), 29.5, 34, "hello00000 weapon", 500, 800);
            ValidationResult r = new DroneValidator().Validate(d);
            Console.WriteLine(r);
            Console.WriteLine(StringExtension.InText("t555", "t555g"));
            Console.WriteLine( PriorityCalculator.Calculate(d));

            ReportPipeline pipe = new ReportPipeline();
            new ReporterUI(pipe).CreateReport();
            new AnalyzerUI(pipe).DisplayRejectedReports();
        }
    }

}