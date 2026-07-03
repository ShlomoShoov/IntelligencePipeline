using IntelligencePipeline.Extensions;
using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;
namespace IntelligencePipeline.Calculators
{
    /// <summary>
    /// Calculates security classification based on business rules.
    /// </summary>
    public static class ClassificationCalculator
    {
        public static Classification Calculate(Report report)
        {
            if (report.Priority == Priority.Critical ||
                StringExtension.InText(wordsList: KeyWords.topSecretClassificationKeywords, report.Description))
                return Classification.TopSecret;

            if (report.Priority == Priority.High ||
                report.GetSourceType() == "Signal" ||
                StringExtension.InText(wordsList: KeyWords.secretClassificationKeywords, report.Description))
                return Classification.Secret;

            if (report.Priority == Priority.Medium ||
                report.GetSourceType() == "Soldier")
                return Classification.Restricted;

            return Classification.Unclassified;
        }

        
    }
}