using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;
using IntelligencePipeline.Pipeline;

namespace IntelligencePipeline.UI
{
    public class ReporterUI : BaseUI
    {
        
        private DroneFactory droneFactory;
        private RadarFactory radarFactory;
        private SignalFactory signalFactory;
        private SoldierFactory soldierFactory;

        public ReporterUI(ReportPipeline pipeline) : base(pipeline)
        {
            
            droneFactory = new DroneFactory(pipeline);
            radarFactory = new(pipeline);
            signalFactory = new(pipeline);
            soldierFactory = new(pipeline);

        }

        public void CreateReport()
        {
            ReportType reportType = GetReportType();

            switch (reportType)
            {
                case ReportType.DroneReport:
                    ProcessCreateRport(droneFactory);
                    break;
                case ReportType.SoldierReport:
                    ProcessCreateRport(soldierFactory);
                    break;
                case ReportType.RadarReport:
                    ProcessCreateRport(radarFactory);
                    break;
                case ReportType.SignalReport:
                    ProcessCreateRport(signalFactory);
                    break;
            }
        }

        private void ProcessCreateRport(BaseFactory factory)
        {
            Dictionary<string, object> userFields = getFields(factory);
            Report newReport = factory.CreateReport(userFields);
            newReport.Status = ReportStatus.New;
            Pipeline.ProcessReport(newReport);
            
        }



        

        private  Dictionary<string, object> getFields(BaseFactory factory)
        {
            Dictionary<string, object> inputData = new Dictionary<string, object>();
            List<ReportField> fields = factory.GetRequiredFields();
            foreach(ReportField field in fields)
            {
                object value = GetField(field);
                inputData[field.Name] = value;
            }
            return inputData;
        }

        private object GetField(ReportField field)
        {
            bool isValid = false;
            object value = 0;
            while (!isValid)
            {
                Console.WriteLine($"Please Enter {field.DisplayName}");
                string input = Console.ReadLine();
                var parseResult = field.ParseFunction(input);
                if (!parseResult.IsVAlid)
                {
                    Console.WriteLine(parseResult.ErrorMassage);
                }
                else
                {
                    value = parseResult.Value;
                    isValid = true;
                }
            }
            return value;
        }
    }
}