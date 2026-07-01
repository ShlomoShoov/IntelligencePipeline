namespace IntelligencePipeline.Validation
{
    /// <summary>
    /// Define the type of Error message When a field is invalid
    /// </summary>
    class ErrorModel
    {
        // fields 
        private string _errorNumber;
        private string _field;
        private string _error;

        // properties

        public string ErrorNumber { get => _errorNumber; }
        public string Field { get => _field; }
        public string Error { get => _error; }

        // constructor

        public ErrorModel(string field, string error, string errorNumber )
        {
            _field = field;
            _error = error;
            _errorNumber = errorNumber;
        }

        public override string ToString()
        {
            return $"Field: {Field} | Error: {Error}";
        }


    }
}