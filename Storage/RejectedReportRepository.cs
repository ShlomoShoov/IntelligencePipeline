using IntelligencePipeline.Models.Reports;
using IntelligencePipeline.Validation;

namespace IntelligencePipeline.Storage
{
    /// <summary>
    /// Stores and manages rejected reports separately
    /// </summary>
    public class RejectedReportRepository
    {
        private List<Report> _rejectedReports;
        public RejectedReportRepository()
        {
            _rejectedReports = [];
        }

        public void Add(Report report)
        {
            _rejectedReports.Add(report);
        }

        public List<Report> GetAll()
        {
            return _rejectedReports;
        }

        public int GetTotalCount()
        {
            return _rejectedReports.Count;
        }

        public List<Report> GetByReason(string reasonKeyword)
        {
            List<Report> filteredReports = [];
            
            foreach(Report report in _rejectedReports)
            {
                foreach(ErrorModel error in report.RejectionReason)
                if (error.Error == reasonKeyword) 
                    filteredReports.Add(report);
            }

            return filteredReports;
        }


    }
}