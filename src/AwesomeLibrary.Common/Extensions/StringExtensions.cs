namespace AwesomeLibrary.Common.Extensions
{
    public static class StringExtensions
    {
        public static string FirstCharToUpper(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value));
            }
            return string.Concat(value.Substring(0, 1).ToUpper(), value.Substring(1));
        }
    }
}
