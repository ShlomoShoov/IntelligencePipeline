
namespace IntelligencePipeline.Extensions
{
    /// <summary>
    /// This class contain all Helper generic methods for Strings
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// static Helper function that checks if string exists in another string 
        /// </summary>
        /// <param name="text">the text we search in it</param>
        /// <param name="target">the specif sequence on letters we want to search</param>
        /// <param name="ignoreCase">if true, ignore big and small letters (for example- InText("H","h", true) > return true</param>
        /// <returns>true if exists, false otherwise </returns>
        public static bool InText(string text, string target, bool ignoreCase = false)
        {
            if (text.Length == 0 || target.Length == 0) return false;
            if (ignoreCase) { text = text.ToLower(); target = target.ToLower();}

            int targetIndex = 0;
            for (int textIndex= 0; textIndex < text.Length; textIndex++ )
            {
                if (target[targetIndex] == text[textIndex])
                {
                    if (targetIndex == target.Length - 1) return true; // we check all the target and  it is equal.
                    targetIndex++;
                }
                else targetIndex = 0;
            }
            return false;
        }

        /// <summary>
        /// check if some word from a list of string exists in the text
        /// </summary>
        /// <param name="text">the text we search in it</param>
        /// <param name="targetList">the list of sequence on letters we want to search</param>
        /// <param name="ignoreCase">if true, ignore big and small letters</param>
        /// <returns></returns>
        public static bool InText(string text, List<string> targetList, bool ignoreCase = false)
        {
           foreach (string target in targetList)
            {
                if (InText(text, target, ignoreCase)) return true;
            }
            return false;
        }
    }
}