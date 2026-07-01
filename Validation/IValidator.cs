
using IntelligencePipeline.Models.Reports;

namespace IntelligencePipeline.Validation 
{
    /// <summary>
    /// Defines the contract for report validation.
    /// </summary>
    interface IValidator
    {
        static abstract ValidationResult Validate(Report report);
    }
}
