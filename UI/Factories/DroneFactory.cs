using IntelligencePipeline.Models.Reports;
using IntelligencePipeline.Pipeline;
using IntelligencePipeline.Models.Enums;

namespace IntelligencePipeline.UI
{
    public class DroneFactory : BaseFactory
    {

        public DroneFactory(ReportPipeline pipeline) : base(pipeline) { }
        public override void  AddFields()
        {
            _Fields.Add(new ReportField("altitude", "altitude", TypeValidation.ParseInt));
            _Fields.Add(new ReportField("ImageQuality", "Image Quality", TypeValidation.ParseInt));
        }


        public override Report CreateReport(Dictionary<string, object> inputData)
        {
            int RecordId = Pipeline.GetNewId();


            return new DroneReport(reportId: RecordId,
                               timestamp: (DateTime)inputData["Timestamp"],
                               latitude: (double)inputData["Latitude"],
                               longitude: (double)inputData["Longitude"],
                               description: (string)inputData["Description"],
                               altitude: (int)inputData["altitude"],
                               imageQuality: (int)inputData["ImageQuality"]
                              );
                            
        }
    }

}