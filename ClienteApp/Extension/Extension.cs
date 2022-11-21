namespace ClienteApp.Extension
{
    public static class Extension
    {
        public static string NormalizeString(this string value)
        {
            var normalizedString = value.Replace(".", "")
                       .Replace("-", "")
                       .ToLower();

            return normalizedString;
        }
    }
}
