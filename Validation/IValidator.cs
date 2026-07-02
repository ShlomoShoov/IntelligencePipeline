
using IntelligencePipeline.Models.Reports;

namespace IntelligencePipeline.Validation 
{
    /// <summary>
    /// Defines the contract for report validation.
    /// </summary>
    interface IValidator
    {
         abstract static ValidationResult Validate(Report report);
         abstract static void ValidateSpecificFields(Report report, ValidationResult validationResult);

    }
}
