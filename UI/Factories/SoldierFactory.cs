using IntelligencePipeline.Models;
using IntelligencePipeline.Models.Reports;
using IntelligencePipeline.Pipeline;

namespace IntelligencePipeline.UI
{
    public class SoldierFactory : BaseFactory
    {

        public SoldierFactory(ReportPipeline pipeline) : base(pipeline) { }
        public override void AddFields()
        {
            _Fields.Add(new ReportField("SoldierName", "Soldier Name", TypeValidation.ParesString));
            _Fields.Add(new ReportField("soldierID", "soldier ID", TypeValidation.ParesString));
            _Fields.Add(new ReportField("confidenceLevel", "confidence Level", TypeValidation.ParseInt));
            _Fields.Add(new ReportField("Unit", "DistanceUnit", TypeValidation.ParesString));
        }


        public override Report CreateReport(Dictionary<string, object> inputData)
        {
            int RecordId = Pipeline.GetNewId();


            return new SoldierReport(reportId: RecordId,
                               timestamp: (DateTime)inputData["Timestamp"],
                               latitude: (double)inputData["Latitude"],
                               longitude: (double)inputData["Longitude"],
                               description: (string)inputData["Description"],
                               soldierName: (string)inputData["SoldierName"],
                               soldierID: (string)inputData["soldierID"],
                               confidenceLevel: (int)inputData["confidenceLevel"],
                               unit: (string)inputData["Unit"]

                              );

        }
    }
}