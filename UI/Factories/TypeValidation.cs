namespace IntelligencePipeline.UI
{
    public static class TypeValidation
    {
        public static  (bool IsVAlid, object Value , string ErrorMassage) ParseInt(string number)
        {
            if (int.TryParse(number, out int parsedNumber))
            {
                return (true, parsedNumber, "");
            }
            return (false, 0, $"Invalid. Must be Integer, Got {number}");
        }

        public static (bool IsVAlid, object Value, string ErrorMassage) ParseDouble(string number)
        {
            if (double.TryParse(number, out double parsedNumber))
            {
                return (true, parsedNumber, "");
            }
            return (false, 0, $"Invalid. Must be double, Got {number}");
        }

        public static (bool IsVAlid, object Value, string ErrorMassage) ParseEnum<T>(string input) where T :struct, Enum
        {
            if (Enum.TryParse<T>(input, true,  out T parsedEnum))
            {
                return (true, parsedEnum, "");
            }
            return (false, 0, $"Invalid value, must be one of {string.Join(", ", Enum.GetNames(typeof(T)))} Got {input}");
        }

        public static (bool IsVAlid, object Value, string ErrorMassage) ParesString(string? input)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                return (true, input, "");
            }
            return (false, "", "Invalid: must contain anything but got null");
        }

        public static (bool IsVAlid, object Value, string ErrorMassage) ParseDateTime(string input)
        {
            if (DateTime.TryParse(input, out DateTime parsedDatetime))
            {
                return (true, parsedDatetime, "");
            }
            return (false, new DateTime(), $"Invalid. Must be valid date time, Got {input}");
        }







    }
}