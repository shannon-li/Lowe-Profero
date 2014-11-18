using System;
using System.Text.RegularExpressions;

namespace LP.Logic
{
    public static class HtmlUtils
    {
        private static Regex regex_0 = new Regex(@"[^\w&;#]", RegexOptions.Singleline | RegexOptions.Compiled);
        private static Regex regex_1 = new Regex(@"<[^>]+>|\&nbsp\;", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private static Regex regex_2 = new Regex(@"\s{2,}", RegexOptions.Compiled);

        public static string GetTextFromHTML(string html)
        {
            Regex regex = new Regex("</?(?!br|/?p|img)[^>]*>", RegexOptions.IgnoreCase);
            return regex.Replace(html, "");
        }

        public static string HtmlDecodeEntities(string string_0)
        {
            if (string.IsNullOrEmpty(string_0))
            {
                return string.Empty;
            }
            string_0 = string_0.Replace("&lt;", "<");
            string_0 = string_0.Replace("&gt;", ">");
            string_0 = string_0.Replace("&quot;", "\"");
            string_0 = string_0.Replace("&nbsp;", " ");
            string_0 = string_0.Replace("&amp;", "&");
            string_0 = string_0.Replace("<br />", "\r\n");
            string_0 = string_0.Replace("<br>", "\r\n");
            return string_0;
        }

        public static string HtmlEncodeEntities(string html)
        {
            if (string.IsNullOrEmpty(html))
            {
                return string.Empty;
            }
            html = html.Replace("<", "&lt;");
            html = html.Replace(">", "&gt;");
            html = html.Replace("\"", "&quot;");
            html = html.Replace("&", "&amp;");
            html = html.Replace(" ", "&nbsp;");
            html = html.Replace("\r\n", "<br />");
            html = html.Replace("\r", "<br />");
            html = html.Replace("\n", "<br />");
            return html;
        }

        public static string MaxLength(string text, int charLimit)
        {
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }
            if (charLimit >= text.Length)
            {
                return text;
            }
            Match match = regex_0.Match(text, charLimit);
            if (!match.Success)
            {
                return text;
            }
            return text.Substring(0, match.Index);
        }

        public static string RemoveHtml(string html)
        {
            return RemoveHtml(html, 0);
        }

        public static string RemoveHtml(string html, int charLimit)
        {
            if (string.IsNullOrEmpty(html))
            {
                return string.Empty;
            }
            string text = regex_2.Replace(regex_1.Replace(html, " ").Trim(), " ");
            if ((charLimit > 0) && (charLimit < text.Length))
            {
                return MaxLength(text, charLimit);
            }
            return text;
        }

        public static string RemoveUnsafeHtml(string html)
        {
            html = Regex.Replace(html, @"(\<|\s+)o([a-z]+\s?=)", "$1$2", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"(script|frame|form|meta|behavior|style)([\s|:|>])+", "$1.$2", RegexOptions.IgnoreCase);
            return html;
        }

        public static string StripAllTags(string stringToStrip)
        {
            return StripAllTags(stringToStrip, true);
        }

        public static string StripAllTags(string stringToStrip, bool enableMultiLine)
        {
            if (enableMultiLine)
            {
                stringToStrip = Regex.Replace(stringToStrip, @"</p(?:\s*)>(?:\s*)<p(?:\s*)>", "\n\n", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                stringToStrip = Regex.Replace(stringToStrip, @"<br(?:\s*)/>", "\n", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            }
            else
            {
                stringToStrip = Regex.Replace(stringToStrip, @"</p(?:\s*)>(?:\s*)<p(?:\s*)>", string.Empty, RegexOptions.Compiled | RegexOptions.IgnoreCase);
                stringToStrip = Regex.Replace(stringToStrip, @"<br(?:\s*)/>", string.Empty, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            }
            stringToStrip = Regex.Replace(stringToStrip, "\"", "''", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            stringToStrip = Regex.Replace(stringToStrip, "&[^;]*;", string.Empty, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            stringToStrip = Regex.Replace(stringToStrip, "<[^>]+>", string.Empty, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return stringToStrip;
        }

        public static string Trim(string html, int charLimit)
        {
            if (string.IsNullOrEmpty(html))
            {
                return string.Empty;
            }
            string rawString = StripAllTags(html, false);
            if ((charLimit > 0) && (charLimit < rawString.Length))
            {
                return StringUtils.Trim(rawString, charLimit);
            }
            return rawString;
        }
    }
}
