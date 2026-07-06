
namespace IntelligencePipeline.UI
{
    public class ReportField
    {
        public string Name { get; }
        public string DisplayName { get; }
        public Func<string, (bool IsVAlid, object Value, string ErrorMassage)> ParseFunction { get; }

        public ReportField(string name, string displayName, Func<string, (bool IsVAlid, object Value, string ErrorMassage)> parseFunction)
        {
            Name = name;
            DisplayName = displayName;
            ParseFunction = parseFunction;
        }
    }

}