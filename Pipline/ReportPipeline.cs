using IntelligencePipeline.Models.Reports;
using IntelligencePipeline.Storage;
using IntelligencePipeline.Validation;

namespace IntelligencePipeline.Pipeline
{
    /// <summary>
    /// Orchestrates the complete report processing workflow.
    /// </summary>
    public class ReportPipeline
    {
        private ReportRepository _validatedReports;
        private RejectedReportRepository _rejectedReports;
        private int _nextReportId;
        public ReportPipeline()
        {
            _validatedReports = new ReportRepository();
            _rejectedReports = new RejectedReportRepository();
            _nextReportId = 1;
        }

        public void ProcessReport(Report report)
        {

        }

        public ReportRepository GetValidatedReports()
        {
            return _validatedReports;
        }

        public RejectedReportRepository GetRejectedReports()
        {
            return _rejectedReports;
        }

        //public string GetStatistics()
        //{

        //}

        //private IValidator _GetValidator(Report report)
        //{
            
        //}

        private void _ValidateReport(Report report)
        {

        }

        private void _CalculateMetrics(Report report)
        {

        }

        private void _StoreReport(Report report)
        {

        }


    }
}