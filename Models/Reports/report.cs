using IntelligencePipeline.Models.Enums;

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

        public string RejectionReason { get; set; }

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
        }

        // abstract methods 
        public abstract string GetSourceType();

        public abstract int CalculateReliabilityScore();

        // Display and Represent the DATA

        public virtual string GetSummary()
        {
            return "";
        }



        public override string ToString()
        {
            return "";
        }






    }
}