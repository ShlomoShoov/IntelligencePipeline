
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace IntelligencePipeline.Extensions
{
    public static class ConsoleExtensions
    {
        public static void DisplayWarning(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        public static void DisplayError(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        public static void DisplayGreen(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        public static void DisplayBlueOnWhite(string msg)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        public static int GetChoiceFromOptions(List<string> options, string msg)
        {
            int selectedIndex = 0;
            bool runnign = true;
            while (runnign)
            {
                Console.Clear();
                Console.WriteLine(msg);
                DisplayGreen("Use Up/Down arrows and press Enter:");
                for (int i = 0; i<options.Count; i++)
                {
                    if (i == selectedIndex) DisplayBlueOnWhite($" > {options[i]}");
                    else Console.WriteLine($"   {options[i]}");
                }
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    if (selectedIndex == 0) selectedIndex = options.Count - 1;
                    else selectedIndex -= 1;
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    if (selectedIndex == options.Count - 1) selectedIndex = 0;
                    else selectedIndex++;
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    runnign = false;
                    
                }
            }
            return selectedIndex;
        }
    }
}
