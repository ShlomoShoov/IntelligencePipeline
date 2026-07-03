using IntelligencePipeline.Calculators;
using IntelligencePipeline.Models;
using IntelligencePipeline.Models.Enums;
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
            _ValidateReport(report);
            if (report.Status == ReportStatus.Validated)
                _CalculateMetrics(report);
            _StoreReport(report);


        }

        public ReportRepository GetValidatedReports()
        {
            return _validatedReports;
        }

        public RejectedReportRepository GetRejectedReports()
        {
            return _rejectedReports;
        }

        public int GetNewId()
        {
            return _nextReportId;
        }

        //public string GetStatistics()
        //{

        //}

        private IValidator _GetValidator(Report report)
        {
            return report switch
            {
                DroneReport => new DroneValidator(),
                SoldierReport => new SoldierValidator(),
                RadarReport => new RadarValidator(),
                SignalReport => new SignalValidator(),
                _ => throw new ArgumentException("Unknown report type")
            };
        }

        private void _ValidateReport(Report report)
        {
            report.Status = ReportStatus.Validating;
            IValidator validator = _GetValidator(report);
            ValidationResult validationResult = validator.Validate(report);

            if (!validationResult.IsValid) 
                report.Status = ReportStatus.Rejected;
    
            else
                report.Status = ReportStatus.Validated;

        }

        private void _CalculateMetrics(Report report)
        {
            report.ReliabilityScore = ReliabilityCalculator.Calculate(report);
            report.Priority = PriorityCalculator.Calculate(report);
            report.Classification = ClassificationCalculator.Calculate(report);
        }

        private void _StoreReport(Report report)
        {
            if (report.Status == ReportStatus.Validated)
                _validatedReports.Add(report);
            else if (report.Status == ReportStatus.Rejected)
                _rejectedReports.Add(report);
        }


    }
}