using IntelligencePipeline.Models.Reports;
using IntelligencePipeline.Extensions;
using IntelligencePipeline.Calculators;
namespace IntelligencePipeline.Models
{
    /// <summary>
    /// Represents an intelligence report from a soldier in the field.
    /// </summary>
    public class SoldierReport : Report
    {
        // const
        private int _baseScore = 4;
        private int _KeyWorkdsScore = 1;

        // properties
        public string SoldierName { get; protected set; }

        public string SoldierID { get; protected set; }

        public string Unit { get; protected set; }

        public int ConfidenceLevel { get; protected set; }

        // Constructor
        public SoldierReport(int reportId, DateTime timestamp, double latitude,
                     double longitude, string description,
                     string soldierName, string soldierID, string unit,
                     int confidenceLevel)
                     : base(reportId, timestamp, latitude, longitude, description)
        {
            SoldierName = soldierName;
            SoldierID = soldierID;
            ConfidenceLevel = confidenceLevel;
            Unit = unit;
        }

        public override string GetSourceType() => "Soldier";

        public override int CalculateReliabilityScore()
        {
            int score = _baseScore;
            score += ConfidenceLevel;
            if (StringExtension.InText(wordsList: KeyWords.reliabilityCriteriaText,  targetText: Description,  ignoreCase: true))
                score += _KeyWorkdsScore;

            return score;
        }

        public override string ToStringSpecificFields()
        {
            return $"|ConfidenceLevel: {ConfidenceLevel} | Unit:{Unit} | SoldierID: {SoldierID} | SoldierName : {SoldierName}";
        }
    }

}