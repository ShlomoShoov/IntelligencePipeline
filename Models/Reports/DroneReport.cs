
namespace IntelligencePipeline.Models.Reports
{

    /// <summay>
    /// Represents an intelligence report from a drone source.
    ///</summay>
    public class DroneReport : Report
    {
        // const and Helpers Fields

        // reliability Calculations

        const int BaseScore = 5; // base score 
        const int MinHighQuality = 80;
        const int HighQulityScore = 3;
       
        const int MinMeduimQuality = 50;
        const int MediumQulityScore = 2;

        const int MinGoodAltitude = 500;
        const int MaxGoodAltitude = 3000;
        const int GoodAltitudeScore = 2;

        const int MaxReliableAltitude = 7000;
        const int UnreliableAltitudeScore = -2;

        // properties
        public int Altitude { get; protected set; }
        public int ImageQuality { get; protected set; }

        // Constructor
        public DroneReport(int reportId, DateTime timestamp, double latitude,
                            double longitude, string description,
                            int altitude, int imageQuality)
                            :base(reportId, timestamp, latitude, longitude, description)
        { 
            Altitude = altitude;
            ImageQuality = imageQuality;
        }


        // override functions
        public override string GetSourceType() => "Drone";

        // Class Calculation Functions
        public override int CalculateReliabilityScore()
        {
            int reliabilityScore = BaseScore;
            if (ImageQuality >= MinHighQuality) reliabilityScore += HighQulityScore;
            else if (ImageQuality>= MinMeduimQuality) reliabilityScore += ReliabilityScore;

            if (Altitude >= MinGoodAltitude && Altitude <= MaxGoodAltitude) reliabilityScore += GoodAltitudeScore;
            if (Altitude > MaxReliableAltitude) reliabilityScore += UnreliableAltitudeScore;

            return reliabilityScore;
        }

        public override string ToStringSpecificFields()
        {
            return $"|Altitude:{Altitude} | ImageQuality:{ImageQuality}";
        }



    }
}