
using IntelligencePipeline.Exceptions;
using IntelligencePipeline.Models.Reports;
using System.ComponentModel;

namespace IntelligencePipeline.Validation
{
    class RadarValidator : BaseValidator
    {

        public override void ValidateSpecificFields(Report report, ValidationResult validationResult)
        {
            _ValidType(report);
            RadarReport radarReport = (RadarReport)report;
            _ValidateSpeed(radarReport, validationResult);
            _ValidateDirection(radarReport, validationResult);
            _ValidateDistance(radarReport, validationResult);
            
        }
        private void _ValidType(Report report)
        {
            string validType = "Radar";
            if (validType != report.GetSourceType())
            {
                throw new MismatchedObjectException($"excepted processing {validType} but got {report.GetSourceType}");
            }

        }

        private void _ValidateSpeed(RadarReport report, ValidationResult validationResult)
        {
            double minSpeed = 0;
            double maxSpeed = 2000;

            if (report.Speed < minSpeed || report.Speed > maxSpeed)
            {
                ErrorModel error = new("Speed",
                                        $"Speed must be between {minSpeed} to {maxSpeed}" +
                                        $"but got {report.Speed}");
                validationResult.UpdateFailResult(error);
            }
        }

        private void _ValidateDirection(RadarReport report, ValidationResult validationResult)
        {
            double minDirection = 0;
            double maxDirection = 360;
            if (report.Direction < minDirection || report.Direction > maxDirection)
            {
                ErrorModel error = new("Direction",
                                       $"Direction must be between {minDirection} to {maxDirection}" +
                                       $"but got {report.Direction}");
                validationResult.UpdateFailResult(error);
            }
        }

        private void _ValidateDistance(RadarReport report, ValidationResult validationResult)
        {
            double minDistance = 100;
            double maxDistance = 100000;
            if (report.Distance < minDistance || report.Distance > maxDistance)
            {
                ErrorModel error = new("Distance",
                                        $"Distance must be between {minDistance}" +
                                        $"to {maxDistance}" +
                                        $"but got {report.Distance}");
            }
        }

    }
}