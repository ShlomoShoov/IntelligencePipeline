using IntelligencePipeline.Exceptions;
using IntelligencePipeline.Extensions;
using IntelligencePipeline.Models;
using IntelligencePipeline.Models.Reports;

namespace IntelligencePipeline.Validation
{
    class SoldierValidator : BaseValidator
    {

        public override void ValidateSpecificFields(Report report, ValidationResult validationResult)
        {
            _ValidType(report);
            SoldierReport soldierReport = (SoldierReport)report;
            _ValidateName( soldierReport, validationResult);
            _ValidateID(soldierReport, validationResult);
            _ValidateconfidenceLevel(soldierReport, validationResult);
            _ValidateUnit(soldierReport, validationResult);
        }

        private  void _ValidType(Report report)
        {
            string validType = "Soldier";
            if (validType != report.GetSourceType())
            {
                throw new MismatchedObjectException($"excepted processing {validType} but got {report.GetSourceType}");
            }

        }

        private  void _ValidateName(SoldierReport report, ValidationResult validationResult)
        {
            int minSoldierNameLen = 2;
            int maxSoldierNameLen = 50;
            if (report.SoldierName.Length < minSoldierNameLen || report.SoldierName.Length > maxSoldierNameLen)
            {
                ErrorModel error = new("SoldierName", $"name must be between {minSoldierNameLen} to  " +
                    $"{maxSoldierNameLen} but got {report.SoldierName.Length}");
                validationResult.UpdateFailResult(error);
            }

        }

        private  void _ValidateID(SoldierReport report, ValidationResult validationResult)
        {
            int idLength = 7;
            if (!StringExtension.IsDigits(report.SoldierID))
            {
                ErrorModel error = new("SoldierID",
                        $"ID must be only digits but got {report.SoldierID}");
                validationResult.UpdateFailResult(error);
            }
            if (report.SoldierID.Length != idLength)
            {
                ErrorModel error = new("SoldierID",
                                        $"ID must be only {idLength} digits but got {report.SoldierID.Length}");
                validationResult.UpdateFailResult(error);
            }
        }

        private  void _ValidateUnit(SoldierReport report, ValidationResult validationResult)
        {
            int minUnitLen = 2;
            int maxUnitLen = 50;
            if (report.Unit.Length < minUnitLen || report.Unit.Length > maxUnitLen)
            {
                ErrorModel error = new("Unit",
                                    $"Unit must contain between {minUnitLen} to {maxUnitLen} chars, bur got {report.Unit.Length}");
                validationResult.UpdateFailResult(error);
            }

        }

        private  void _ValidateconfidenceLevel(SoldierReport report, ValidationResult validationResult)
        {
            int minConfidenceLevel = 1;
            int maxConfidencelevel = 5;
            if (report.ConfidenceLevel < minConfidenceLevel || report.ConfidenceLevel > maxConfidencelevel)
            {
                ErrorModel error = new("ConfidenceLevel",
                                        $"Confidence Level must be between {minConfidenceLevel}" +
                                        $"to {maxConfidencelevel} but got {report.ConfidenceLevel}");
            }
        }
    }
}