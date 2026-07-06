using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Exceptions;
using IntelligencePipeline.Extensions;
using IntelligencePipeline.Pipeline;
namespace IntelligencePipeline.UI
{
    public abstract class BaseUI
    {
        protected ReportPipeline Pipeline;
        public BaseUI(ReportPipeline pipeline)
        {
            Pipeline = pipeline;
        }

        protected ReportType GetReportType()
        {
            return GetEnum<ReportType>("Report Type");
        }

        protected T GetEnum<T>(string displayName) where T : struct, Enum 
        {
            T[] enumArray = Enum.GetValues<T>();
            List<string> enumList = [];
            foreach (T enumName in enumArray) enumList.Add(enumName.ToString());



            int userChoice = ConsoleExtensions.GetChoiceFromOptions(enumList, $"Please enter {displayName}");

            return enumArray[userChoice];

        }

    }
    
}