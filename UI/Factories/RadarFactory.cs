using IntelligencePipeline.Models.Reports;
using IntelligencePipeline.Pipeline;

namespace IntelligencePipeline.UI
{
    public class RadarFactory : BaseFactory
    {

        public RadarFactory(ReportPipeline pipeline) : base(pipeline) { }
        public override void AddFields()
        {
            _Fields.Add(new ReportField("Speed", "Speed", TypeValidation.ParseInt));
            _Fields.Add(new ReportField("Direction", "Direction", TypeValidation.ParseInt));
            _Fields.Add(new ReportField("Distance", "Distance", TypeValidation.ParseInt));
        }


        public override Report CreateReport(Dictionary<string, object> inputData)
        {
            int RecordId = Pipeline.GetNewId();


            return new RadarReport(reportId: RecordId,
                               timestamp: (DateTime)inputData["Timestamp"],
                               latitude: (double)inputData["Latitude"],
                               longitude: (double)inputData["Longitude"],
                               description: (string)inputData["Description"],
                               direction: (int)inputData["Direction"],
                               distance: (int)inputData["Distance"],
                               speed: (int)inputData["Speed"]

                              );

        }
    }
}