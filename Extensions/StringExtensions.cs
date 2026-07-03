
using System.Security.Cryptography.X509Certificates;

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
        /// <param name="ignoreCase">if true, ignore big and small letters (for example- InText("H","hello", true) > return true</param>
        /// <returns>true if exists, false otherwise </returns>
        public static bool InText(string text, string target, bool ignoreCase = false)
        {
            if (text.Length == 0 || target.Length == 0) return false;
            if (ignoreCase) { text = text.ToLower(); target = target.ToLower();}

            int textIndex = 0;
            for (int targetIndex= 0; targetIndex < target.Length; targetIndex++ )
            {
                if (target[targetIndex] == text[textIndex])
                {
                    if (textIndex == text.Length - 1) return true; // we check all the target and  it is equal.
                    textIndex++;
                }
                else textIndex = 0;
            }
            return false;
        }

        /// <summary>
        /// check text exist in a list of strings
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

        /// <summary>
        /// return if some of list of words exists in a text
        /// </summary>
        /// <param name="textList"></param>
        /// <param name="targetText"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public static bool InText(List<string> wordsList, string targetText, bool ignoreCase = false)
        {
            foreach(string word in wordsList)
            {
                if (InText(word, targetText, ignoreCase)) return true;
            }
            return false;
        }

        /// <summary>
        /// checks if **all** list of words exists in some text
        /// </summary>
        /// <param name="textList"></param>
        /// <param name="targetText"></param>
        /// <returns></returns>
        public static bool AllInText(List<string> wordsList , string targetText,bool ignoreCase = false)
        {
            foreach(string word in wordsList)
            {
                if (!InText(word, targetText, ignoreCase)) return false;
            }
            return true;
        }


        /// <summary>
        /// checks if specific char in list of chars
        /// </summary>
        /// <param name="charToChck"></param>
        /// <param name="targetList"></param>
        /// <returns></returns>
        public static bool CharInList(char charToCheck , List<Char> targetList)
        {
            for(int index = 0; index < targetList.Count; index++)
            {
                if (charToCheck == targetList[index]) return true;
            }
            return false;
        }

        
        /// <summary>
        /// return if given sting contain digits [0-9] only.
        /// </summary>
        /// <param name="digits">the digit string we want to check</param>
        /// <returns>bool</returns>
        public static bool IsDigits(string digits)
        {
            List<Char> tenDigits = ['1', '2', '3', '4', '5', '6', '7', '8', '9', '0'];
            for(int index = 0; index<digits.Length; index++)
            {
                if (!CharInList(digits[index], tenDigits)) return false;
            }
            return true;
        }
    }
}