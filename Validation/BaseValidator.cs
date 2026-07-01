using IntelligencePipeline.Models.Reports;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace IntelligencePipeline.Validation
{
    /// <summary>
    /// Provides common validation logic for all report types and eliminates code duplication.
    /// </summary>
    abstract class BaseValidator : IValidator
    {
        // validations

        //  Time stamp:
        private DateTime _validTimeStamp = new DateTime(year: 2020, month: 1, day: 1);
        public string timestampErrorNumber = "001";

        // latitude
        private double _minLatitude = 29.5000;
        private double _maxLatitude = 29.5000;
        public string latitudeErrorNumber = "002";

        // Longitude
        private double _minLongitude = 34.0000;
        private double _maxLongitude = 36.0000;
        public string longitudeErrorNumber = "003";

        private double _minDescription = 10;
        private double _maxDescription = 500;
        public string descriptionErrorNumber = "004";

        // validations functions
        private bool _validateTimeStamp(DateTime timeStamp, out ErrorModel? errorModel)
        {
           
            errorModel = null;
            if (_validTimeStamp > timeStamp)
            {
                string errorMsg = $"timestamp must be AFTER {_validTimeStamp} but got: {timeStamp}";
                ErrorModel newError = new ErrorModel(field: "timestamp", error:errorMsg, errorNumber: timestampErrorNumber);
                errorModel = newError;
                return false;
            }
            return true;
        }

        private bool _ValidateLongitude(double longitude, out ErrorModel? errorModel)
        {
            errorModel = null;
            if (longitude>_minLongitude || longitude < _maxLongitude)
            {
                string errorMsg = $"longitude out of range:{longitude} must be between {_minLatitude} to {_maxLatitude}";
                ErrorModel newError = new ErrorModel(field: "longitude", error: errorMsg, errorNumber: longitudeErrorNumber);
                errorModel = newError;
                return false;
            }
            return true;
        }

        private bool _ValidateLatitude(double latitude, out ErrorModel? errorModel)
        {
            errorModel = null;
            if (latitude > _minLatitude || latitude < _maxLatitude)
            {
                string errorMsg = $"latitude out of range:{latitude} must be between {_minLatitude} to {_maxLatitude}";
                ErrorModel newError = new ErrorModel(field: "latitude", error: errorMsg, errorNumber: latitudeErrorNumber);
                errorModel = newError;
                return false;
            }
            return true;
        }

        private  bool _ValidateDescriptin(string description, out ErrorModel? errorModel)
        {
            errorModel = null;
            if (description.Length > _maxDescription || description.Length < _minDescription)
            {
                string errorMsg = $"description length out of range got:{description.Length} must be between {_minDescription} to {_maxDescription}";
                ErrorModel newError = new ErrorModel(field: "latitude", error: errorMsg, errorNumber: descriptionErrorNumber);
                errorModel = newError;
                return false;
            }
            return true;
        }

        public ValidationResult Validate(Report report)
        {
            List<ErrorModel> erorrs = [];
            bool valid = true;
            if (!_ValidateLatitude(report.Latitude, out ErrorModel? errorLatitud)) { erorrs.Add(errorLatitud); valid = false; }
            if (!_ValidateLongitude(report.Longitude, out ErrorModel? errorLongitude)) { erorrs.Add(errorLongitude); valid = false; }
            if (!_ValidateDescriptin(report.Description, out ErrorModel? errorDescripion)) { erorrs.Add(errorDescripion); valid = false; }
            if (valid) return ValidationResult.Success();
            else return ValidationResult.Failure(erorrs);
        }
    }
}