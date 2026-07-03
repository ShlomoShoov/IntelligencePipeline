

// Ignore Spelling: Validator

using IntelligencePipeline.Exceptions;
using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;
using System.Security.Cryptography;

namespace IntelligencePipeline.Validation
{
    public class SignalValidator : BaseValidator
    {

        public  override void ValidateSpecificFields(Report report, ValidationResult validationResult)
        {
            _ValidType(report);
            SignalReport radarReport = (SignalReport)report;
            _ValidateFrequency(radarReport, validationResult);
            _ValidateContent(radarReport, validationResult);
            _ValidateLanguge(radarReport, validationResult);
            _ValidateSignalStrength(radarReport, validationResult);

        }
        private  void _ValidType(Report report)
        {
            string validType = "Signal";
            if (validType != report.GetSourceType())
            {
                throw new MismatchedObjectException($"excepted processing {validType} but got {report.GetSourceType}");
            }

        }

        private  void _ValidateFrequency(SignalReport report, ValidationResult validationResult)
        {
            double minFrequency = 1.0;
            double maxFrequency = 3000.0;
            if (report.Frequency < minFrequency || report.Frequency > maxFrequency)
            {
                ErrorModel error = new("Frequency",
                                        $"Frequency must be between {minFrequency}" +
                                        $"to {maxFrequency}" +
                                        $"but got {report.Frequency}");
                validationResult.UpdateFailResult(error);
            }
        }

        private  void _ValidateContent(SignalReport report, ValidationResult validationResult)
        {
            int minContent = 5;
            int maxContent = 1000;
            if (report.Content.Length < minContent || report.Content.Length > maxContent)
            {
                ErrorModel error = new("Content",
                                        $"Content must contain between {minContent} to " +
                                        $"{maxContent} Chars" +
                                        $"but got {report.Content.Length}");
                validationResult.UpdateFailResult(error);
            }
        }

        private  void _ValidateLanguge(SignalReport report, ValidationResult validationResult)
        {
            if (!Enum.IsDefined(report.Language))
            {
                ErrorModel error = new("Language",
                                        $"Language not defined {report.Language}");
                validationResult.UpdateFailResult(error);
            }
        }

        private void _ValidateSignalStrength(SignalReport report, ValidationResult validationResult)
        {
            double minSignalStrength = -120;
            double maxSignalStrength = 0;
            if (report.SignalStrength < minSignalStrength || report.SignalStrength > maxSignalStrength)
            {
                ErrorModel error = new("SignalStrength",
                                        $"SignalStrength must be between {minSignalStrength} " +
                                        $"to {maxSignalStrength}" +
                                        $"but got {report.SignalStrength}");
                validationResult.UpdateFailResult(error);
            }
        }

    }
}