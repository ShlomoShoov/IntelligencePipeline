using IntelligencePipeline.Exceptions;
using IntelligencePipeline.Models.Reports;



namespace IntelligencePipeline.Validation
{
    /// <summary>
    /// Validates drone-specific report fields.
    /// </summary>
    public class DroneValidator : IValidator
    {
        public static ValidationResult Validate(Report report)
        {
            ValidationResult validationResult = BaseValidator.Validate(report);
            ValidateSpecificFields(report, validationResult);
            return validationResult;
        }
        public static void  ValidateSpecificFields(Report report, ValidationResult validationResult)
        {
            
            _ValidType(report);
            _ValidImageQuality((DroneReport)report, validationResult);
            _ValidAltitude((DroneReport)report, validationResult);



        }

            private static void _ValidType(Report report)
            {
                string validType = "Drone";
                if (validType != report.GetSourceType())
                {
                    throw new MismatchedObjectException($"excepted processing {validType} but got {report.GetSourceType}");
                }
            
            }

        private static void _ValidAltitude(DroneReport report, ValidationResult validationResult)
        {
            int minAltitude = 100;
            int maxAltitude = 10000;


            if (report.Altitude < minAltitude || report.Altitude > maxAltitude)
            {
                ErrorModel error = new("Altitude", $"altitude must be between {minAltitude} to {maxAltitude}. but got: {report.Altitude}");
                validationResult.UpdateFailResult(error);
            }
        }

        private static void _ValidImageQuality(DroneReport report, ValidationResult validationResult)
        {
            int minImageQuality = 1;
            int maxImageQuality = 100;
            if (report.ImageQuality < minImageQuality || report.ImageQuality > maxImageQuality)
            {
                ErrorModel error = new("ImageQuality", $"Image Quality must be between {minImageQuality} to {maxImageQuality} but got {report.ImageQuality}");
                validationResult.UpdateFailResult(error);
            }
        }

    }
}