using System.Text.RegularExpressions;

namespace Blog.Helpers
{
    public static class RemoveHtmlTagHelper
    {
        public static string RemoveHtmlTags(string input)
        {
            return Regex.Replace(input, "<.*?>|&[a-zA-Z0-9#]+;", string.Empty);
        }
    }
}
