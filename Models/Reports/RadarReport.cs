namespace IntelligencePipeline.Models.Reports
{
    /// <summary>
    /// Represents an intelligence report from a radar system.
    /// </summary>
    public class RadarReport : Report
    {
        public int Speed { get; protected set; }

        public int Direction { get; protected set; }

        public int Distance { get; protected set; }

        private int _baseScore = 6;
        private int _goodDistanceScore = 2;
        private int _minGoodDistance = 500;
        private int _maxGoodDistance = 3000;
        private int _goodSpeedScore = 1;
        private int _minGoodSpeed = 10;
        private int _maxGoodSpeed = 900;
        private int _badDistanceScore = -2;
        private int _badDistanceThreshold = 7000;
        private int _badSpeedScore = -2;
        private int _badSpeedThreshold = 1500;

        public RadarReport(int reportId, DateTime timestamp, double latitude,
                            double longitude, string description,
                            int speed, int direction, int distance)
                            : base(reportId, timestamp, latitude, longitude, description)
        {
            Speed = speed;
            Direction = direction;
            Distance = distance;
        }

        public override string GetSourceType() => "Radar";

        public override int CalculateReliabilityScore()
        {
            int score = _baseScore;
            if (Distance >= _minGoodDistance && Distance <= _maxGoodDistance) score += _goodDistanceScore;
            else if (Distance > _badDistanceThreshold) score += _badDistanceScore;
            if (Speed >= _minGoodSpeed && Speed <= _maxGoodSpeed) score += _goodSpeedScore;
            else if (Speed > _badSpeedThreshold) score += _badSpeedScore;
            return score;
        }

        public override string ToStringSpecificFields()
        {
            return $"|Distance: {Distance}| Direction:{Direction}| Speed:{Speed}";
        }


    }
}