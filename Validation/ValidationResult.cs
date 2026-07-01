

namespace IntelligencePipeline.Validation
{
    /// <summary>
    /// Encapsulates the result of a validation operation.
    /// </summary>
    class ValidationResult
    {
        // fields
        
        
        private bool _isValid;
        private List<ErrorModel> _errorMessages;

        // properties
        public bool IsValid { get=>_isValid; }
        public List<ErrorModel> ErrorMessage { get=>_errorMessages; }

        // constructor 
        public ValidationResult(bool isValid, List<ErrorModel> errorMessages)
        {
            _isValid = isValid;
            _errorMessages = errorMessages;
        }

        // Display functions
        public override string ToString()
        {
            string display = $"Is Valid: {IsValid}";
            if (!IsValid)
            {
                display += "\n" + string.Join("\n", ErrorMessage);
            }
            return display;
        }

        // Quick Creation Validation Reports
        public static ValidationResult Success()
        {
            return new ValidationResult(true, []);
        }

        public static ValidationResult Failure(List<ErrorModel> errorMessages)
        {
            return new ValidationResult(false, errorMessages);
        }

       

    }
}
