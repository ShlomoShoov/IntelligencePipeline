using IntelligencePipeline.Models.Reports;

namespace IntelligencePipeline.Calculators
{
    /// <summary>
    /// Centralized location for reliability score calculation logic.

    /// </summary>
    public static class ReliabilityCalculator
    {
        private static int _minScore = 1;
        private static int _maxScore = 10;
        public static int Calculate(Report report)
        {
            int score = report.CalculateReliabilityScore();
            if (score < _minScore) score = _minScore;
            if (score > _maxScore) score = _maxScore;
            return score;
        }


    }
}
