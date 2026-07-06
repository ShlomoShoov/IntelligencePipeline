using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;
using IntelligencePipeline.Pipeline;

namespace IntelligencePipeline.UI
{
    public class SignalFactory : BaseFactory
    {

        public SignalFactory(ReportPipeline pipeline) : base(pipeline) { }
        public override void AddFields()
        {
            _Fields.Add(new ReportField("Frequency", "Frequency", TypeValidation.ParseDouble));
            _Fields.Add(new ReportField("Content", "Content", TypeValidation.ParesString));
            _Fields.Add(new ReportField("Language", "Language", TypeValidation.ParseEnum<Language>));
            _Fields.Add(new ReportField("signalStrength", "signal Strength", TypeValidation.ParseInt));
        }


        public override Report CreateReport(Dictionary<string, object> inputData)
        {
            int RecordId = Pipeline.GetNewId();


            return new SignalReport(reportId: RecordId,
                               timestamp: (DateTime)inputData["Timestamp"],
                               latitude: (double)inputData["Latitude"],
                               longitude: (double)inputData["Longitude"],
                               description: (string)inputData["Description"],
                               frequency: (double)inputData["Frequency"],
                               content: (string)inputData["Content"],
                               language: (Language)inputData["Language"],
                               signalStrength: (int)inputData["signalStrength"]

                              );

        }
    }
}