using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Extensions;
using IntelligencePipeline.Calculators;

namespace IntelligencePipeline.Models.Reports
{
    /// <summary>
    /// Represents an intelligence report from a signal intelligence system.
    /// </summary>
    public class SignalReport : Report
    {
        public double Frequency { get; protected set; }

        public string Content { get; protected set; }

        public Language Language { get; protected set; }

        public int SignalStrength { get; protected set; }

        int _baseScore = 5;
        int _goodStrengthThreshold = -70;
        int _goodStrngthScore = 2;
        int _bestStrengthThreshold = -40;
        int _bestStrengthScore = 3;
        int _KeyWordsScore = 1;
        int _badStrengthThreshold = -100;
        int _badStrengthScore = -2;


        public SignalReport(int reportId, DateTime timestamp, double latitude,
                            double longitude, string description,
                            double frequency, string content, Language language,
                            int signalStrength)
                            : base(reportId, timestamp, latitude, longitude, description)
        {
            Frequency = frequency;
            Content = content;
            Language = language;
            SignalStrength = signalStrength;
        }
        public override string GetSourceType() => "Signal";

        public override int CalculateReliabilityScore()
        {
            int score = _baseScore;

            if (SignalStrength >= _bestStrengthThreshold) score += _bestStrengthScore;
            else if (SignalStrength >= _goodStrengthThreshold) score += _goodStrngthScore;
            else if (SignalStrength < _badStrengthThreshold) score += _badStrengthScore;
            if (StringExtension.InText(text: Content, targetList: KeyWords.signalReliabilityHighScoreKeyWords, ignoreCase: true))
                score += _KeyWordsScore;
            return score;
        }


    }
}