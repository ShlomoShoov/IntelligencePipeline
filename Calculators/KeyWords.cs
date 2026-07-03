
namespace IntelligencePipeline.Calculators
{
    public static class KeyWords
    {
        public static List<string> reliabilityCriteriaText = ["weapon", "vehicle", "movement", "explosion"];
        public static List<string> signalReliabilityHighScoreKeyWords = ["attack", "target", "border", "vehicle"];

        public static List<string> criticalPriorityKeyWords = ["missile" , "explosion" , "attack" , "fire"];
        public static List<string> criticalPrioritySignalKeyWords = ["target", "attack"];
        public static List<string> HighSoldierReportKeyWords = ["movement"];
        public static List<string> highPriorityKeywords = ["weapon","suspicious","border"];
        public static List<string> MediumPriorityKeywords = ["movement", "vehicle" , "activity"];

        public static List<string> topSecretClassificationKeywords = ["target", "attack", "missile"];
        public static List<string> secretClassificationKeywords = ["border ", "weapon"];
        
    } 
    

}
