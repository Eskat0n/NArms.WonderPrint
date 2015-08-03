namespace NArms.WonderPrint.Utilities
{
    using System.Text;

    public static class IndentHelper
    {
        public static string GetIndent(string @base, int length)
        {
            if (string.IsNullOrEmpty(@base))
                return string.Empty;

            var indent = new StringBuilder(string.Empty);
            for (var i = 0; i < length; i++)
                indent.Append(@base);
            return indent.ToString();
        }
    }
}