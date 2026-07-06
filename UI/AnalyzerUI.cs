using IntelligencePipeline.Extensions;
using IntelligencePipeline.Models.Reports;
using IntelligencePipeline.Pipeline;

namespace IntelligencePipeline.UI
{
    public class AnalyzerUI : BaseUI
    {
        public AnalyzerUI(ReportPipeline pipeline) : base(pipeline)
        {

        }

        public void DisplayValidatedReports()
        {
            List<Report> reports = Pipeline.GetValidatedReports().GetAll();
            ConsoleExtensions.DisplayGreen("Validated Reports:");
            Console.WriteLine(string.Join("\n", reports));
        }

        public void DisplayRejectedReports()
        {
            List<Report> reports = Pipeline.GetRejectedReports().GetAll();
            ConsoleExtensions.DisplayGreen("Invalidated Reports:");
            Console.WriteLine(string.Join("\n", reports));
        }

    }

}