namespace IntelligencePipeline.Validation
{
    /// <summary>
    /// Define the type of Error message When a field is invalid
    /// </summary>
    public class ErrorModel
    {
        // fields 
     
        private string _field;
        private string _error;

        // properties

        public string Field { get => _field; }
        public string Error { get => _error; }
        
        

        // constructor

        public ErrorModel(string field, string error )
        {
            _field = field;
            _error = error;
           
        }

        public override string ToString()
        {
            return $"Field: {Field} | Error: {Error}";
        }


    }
}