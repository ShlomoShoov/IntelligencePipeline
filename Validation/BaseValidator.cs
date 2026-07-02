using IntelligencePipeline.Models.Reports;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace IntelligencePipeline.Validation
{
    /// <summary>
    /// Provides common validation logic for all report types and eliminates code duplication.
    /// </summary>
    public abstract class BaseValidator : IValidator
    {

        // validations functions

        //  Time stamp:
        private static void _validateTimeStamp(DateTime timeStamp, ValidationResult validationResult)
        {
            DateTime _validTimeStamp = new DateTime(year: 2020, month: 1, day: 1);

            if (_validTimeStamp > timeStamp)
            {
                string errorMsg = $"timestamp must be AFTER {_validTimeStamp} but got: {timeStamp}";
                ErrorModel newError = new ErrorModel(field: "timestamp", error: errorMsg);
                validationResult.UpdateFailResult(newError);

            }
            if (timeStamp > DateTime.Now)
            {
                string errorMsg = $"timestamp can not be AFTER  the current time. but got: {timeStamp}";
                ErrorModel newError = new ErrorModel(field: "timestamp", error: errorMsg);
                validationResult.UpdateFailResult(newError);

            }

        }
        // Longitude

        private static void _ValidateLongitude(double longitude, ValidationResult validationResult)
        {

            double _minLongitude = 34.0000;
            double _maxLongitude = 36.0000;
            if (longitude < _minLongitude || longitude > _maxLongitude)
            {
                string errorMsg = $"longitude out of range:{longitude} must be between {_minLongitude} to {_maxLongitude}";
                ErrorModel newError = new ErrorModel(field: "longitude", error: errorMsg);
                validationResult.UpdateFailResult(newError);

            }

        }
        // latitude
        private static void _ValidateLatitude(double latitude, ValidationResult validationResult)
        {
            double _minLatitude = 29.5000;
            double _maxLatitude = 33.5000;
            if (latitude < _minLatitude || latitude > _maxLatitude)
            {
                string errorMsg = $"latitude out of range:{latitude} must be between {_minLatitude} to {_maxLatitude}";
                ErrorModel newError = new ErrorModel(field: "latitude", error: errorMsg);
                validationResult.UpdateFailResult(newError);

            }

        }

        private static void _ValidateDescriptin(string description, ValidationResult validationResult)
        {
            double _minDescription = 10;
            double _maxDescription = 500;
            if (description.Length > _maxDescription || description.Length < _minDescription)
            {
                string errorMsg = $"description length out of range got:{description.Length} must be between {_minDescription} to {_maxDescription}";
                ErrorModel newError = new ErrorModel(field: "latitude", error: errorMsg);
                validationResult.UpdateFailResult(newError);

            }

        }

        public static ValidationResult Validate(Report report)
        {
            ValidationResult validationResult = ValidationResult.Success();
            ValidateCommonFields(report, validationResult);
            ValidateSpecificFields(report, validationResult);
            return validationResult;
        }

        private static void ValidateCommonFields(Report report, ValidationResult validationResult)
        {
            _validateTimeStamp(report.Timestamp, validationResult);
            _ValidateLatitude(report.Latitude, validationResult);
            _ValidateLongitude(report.Longitude, validationResult);
            _ValidateDescriptin(report.Description, validationResult);
        }

        public static void ValidateSpecificFields(Report report, ValidationResult validationResult){}

        
    }
}