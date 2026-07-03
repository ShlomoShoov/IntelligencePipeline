using IntelligencePipeline.Extensions;
using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;
using IntelligencePipeline.Exceptions;

namespace IntelligencePipeline.Storage
{
    /// <summary>
    /// Stores and manages validated reports.
    /// </summary>
    public class ReportRepository
    {
        private List<Report> _reports;

        public ReportRepository()
        {
            _reports = [];
        }

        public void Add(Report report)
        {
            _reports.Add(report);
        }

        public List<Report> GetAll()
        {
            return _reports;
        }

        public List<Report> GetByStatus(ReportStatus status)
        {
            List<Report> filterdReports = [];
            foreach(Report report in _reports)
            {
                if (report.Status == status)
                    filterdReports.Add(report);
            }
            return filterdReports;
        }

        public List<Report> GetByPriority(Priority priority)
        {
            List<Report> filterdReports = [];
            foreach (Report report in _reports)
                if (report.Priority == priority)
                    filterdReports.Add(report);
            return filterdReports;
        }

        public List<Report> Search(string keyword)
        {
            List<Report> filterdReports = [];
            foreach (Report report in _reports)
                if (StringExtension.InText(keyword, report.Description))
                    filterdReports.Add(report);
            return filterdReports;
        }

        /// <summary>
        /// return report by Id, if not exists raise 
        /// </summary>
        /// <param name="reportId"></param>
        /// <returns></returns>
        public Report GetById(int reportId)
        {
            foreach(Report report in _reports)
            {
                if (report.ReportId == reportId)
                    return report;
            }
            throw new IdNotFound($"report id: {reportId} not found ");
        }

        public void UpdateStatus(int reportId, ReportStatus newStatus)
        {
            GetById(reportId).Status = newStatus;
        }

        public int GetTotalCount()
        {
            return _reports.Count;
        }

        public int GetCountByStatus(ReportStatus status)
        {
            return GetByStatus(status).Count;
        }


    }
}