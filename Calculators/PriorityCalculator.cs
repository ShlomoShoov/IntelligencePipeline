using IntelligencePipeline.Extensions;
using IntelligencePipeline.Models;
using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;

namespace IntelligencePipeline.Calculators 
{
    /// <summary>
    /// Calculates report priority based on business rules.
    /// </summary>
    public static class PriorityCalculator
    {
        public static Priority Calculate(Report report)
        {
            if (_IsCritical(report))
                return Priority.Critical;
            if (_IsHigh(report))
                return Priority.High;
            if (_IsMedium(report))
                return Priority.Medium;
            return Priority.Low;

        }

        public static Priority Calculate(RadarReport report)
        {

            int criticalRadarSpeedThreshold = 800;
            int highSpeedThreshold = 500;
            int mediumSpeedThreshold = 120;

            if (_IsCritical(report) || report.Speed >= criticalRadarSpeedThreshold)
                return Priority.Critical;
            if (_IsHigh(report) || report.Speed >= highSpeedThreshold)
                return Priority.High;
            if (_IsMedium(report) || report.Speed >= mediumSpeedThreshold)
                return Priority.Medium;
            return Priority.Low;
        }

        public static Priority Calculate(SoldierReport report)
        {
            int highConfidnceLevel = 4;

            if (_IsCritical(report))
                return Priority.Critical;
            if (_IsHigh(report) ||
                            (report.ConfidenceLevel >= highConfidnceLevel && 
                            StringExtension.InText(wordsList:KeyWords.HighSoldierReportKeyWords, report.Description)))
                return Priority.High;
            if (_IsMedium(report))
                return Priority.Medium;
            return Priority.Low;
        }

        public static Priority Calculate(DroneReport report)
        {
            int highAltitudeThreshod = 500;

            if (_IsCritical(report))
                return Priority.Critical;
            if (_IsHigh(report) || report.Altitude > highAltitudeThreshod)
                return Priority.Medium;
            if (_IsMedium(report))
                return Priority.Medium;
            return Priority.Low;

        }

        public static Priority Calculate(SignalReport report)
        {
            if (_IsCritical(report) || 
                                    StringExtension.AllInText(wordsList: KeyWords.criticalPrioritySignalKeyWords, report.Content))
                return Priority.Critical;
            if (_IsHigh(report))
                return Priority.High;
            if (_IsMedium(report))
                return Priority.Medium;
            return Priority.Low;
        }

        private static bool _IsCritical(Report report)
        {
            return StringExtension.InText( KeyWords.criticalPriorityKeyWords, report.Description, ignoreCase: true);
        }

        private static bool _IsHigh(Report report)
        {
            return StringExtension.InText( KeyWords.highPriorityKeywords, report.Description, ignoreCase:true);
        }

        private static bool _IsMedium(Report report)
        {
            int mediumReliablityScore = 7;
            return StringExtension.InText(KeyWords.MediumPriorityKeywords, report.Description, ignoreCase: true
                || report.ReliabilityScore >= mediumReliablityScore);
        }
    }
}
