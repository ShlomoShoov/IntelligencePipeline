using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Validation;
using System.Security.Cryptography.X509Certificates;

namespace IntelligencePipeline.Models.Reports
{
    /// <summary>
    /// Models the shared concept of an intelligence report regardless of source type.
    /// </summary>

    public abstract class Report
    {
        // properties
        public int ReportId { get; protected set; }

        public DateTime Timestamp { get; protected set; }

        public double Latitude { get; protected set; }

        public double Longitude { get; protected set; }

        public string Description { get; protected set; }

        public ReportStatus Status { get; set; }

        public Priority Priority { get; set; }

        public Classification Classification { get; set; }

        public int ReliabilityScore { get; set; }

        public List<ErrorModel> RejectionReason { get; set; }

        // constructor 
        protected Report(int reportId, DateTime timestamp, double latitude,
                         double longitude, string description)
        {
            ReportId = reportId;
            Timestamp = timestamp;
            Latitude = latitude;
            Longitude = longitude;
            Description = description;
            Status = ReportStatus.New;
            RejectionReason = [];



        }

        // abstract methods 
        public abstract string GetSourceType();

        public abstract int CalculateReliabilityScore();

        // Display and Represent the DATA

        public abstract string ToStringSpecificFields();
        public override string ToString()
        {
            string result  = $"{GetSourceType()} |ID: {ReportId} |Timestamp: {Timestamp} |Description {Description} |Status {Status}";
            result += ToStringSpecificFields();
            if (Status != ReportStatus.Rejected)
            {
                result += $"\nPriority: {Priority}| Classification{Classification} | Priority: {Priority}";
            }
            else
            {
                result += $"\nErrors While Validating:\n{string.Join("\n", RejectionReason)}";
            }

            return result;
        }






    }
}