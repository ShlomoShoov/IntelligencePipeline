using IntelligencePipeline.Models.Reports;
using IntelligencePipeline.Pipeline;

namespace IntelligencePipeline.UI
{
    abstract public class BaseFactory
    {
        protected List<ReportField> _Fields = [];
        protected ReportPipeline Pipeline;
        protected BaseFactory(ReportPipeline pipeline)
        {
            _createFields();
            AddFields();
            Pipeline = pipeline;


        }
        private void _createFields()
        {

            _Fields.Add(new ReportField("Timestamp", "Time stamp", TypeValidation.ParseDateTime));
            _Fields.Add(new ReportField("Latitude", "Latitude", TypeValidation.ParseDouble));
            _Fields.Add(new ReportField("Longitude", "Longitude", TypeValidation.ParseDouble));
            _Fields.Add(new ReportField("Description", "Description", TypeValidation.ParesString));
        }

        public List<ReportField> GetRequiredFields()
        {
            return _Fields;
        }
        public abstract Report CreateReport(Dictionary<string, object> inputData);

        public abstract void AddFields();
    }
}