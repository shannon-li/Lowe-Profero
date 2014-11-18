using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace LP.Logic
{
    public static class StringUtils
    {
        public static string AsciiToUnicode(int asciiCode)
        {
            Encoding encoding = Encoding.UTF32;
            byte[] bytes = encoding.GetBytes(((char)asciiCode).ToString());
            return encoding.GetString(bytes);
        }

        public static string ByteArrayToHex(byte[] byte_0)
        {
            return BitConverter.ToString(byte_0).Replace("-", "");
        }

        public static string Chop(string string_0)
        {
            return Chop(string_0, 1);
        }

        public static string Chop(string string_0, int removeFromEnd)
        {
            string str = string_0;
            if (string_0.Length > (removeFromEnd - 1))
            {
                str = str.Remove(string_0.Length - removeFromEnd, removeFromEnd);
            }
            return str;
        }

        public static string Chop(string string_0, string backDownTo)
        {
            int startIndex = string_0.LastIndexOf(backDownTo);
            int count = 0;
            if (startIndex > 0)
            {
                count = string_0.Length - startIndex;
            }
            string str = string_0;
            if (string_0.Length > (count - 1))
            {
                str = str.Remove(startIndex, count);
            }
            return str;
        }

        public static string CleanSearchString(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                return string.Empty;
            }
            searchString = searchString.Replace("*", "%");
            searchString = HtmlUtils.RemoveHtml(searchString);
            searchString = Regex.Replace(searchString, "--|;|'|\"", " ", RegexOptions.Multiline);
            searchString = Regex.Replace(searchString, " {1,}", " ", RegexOptions.Multiline | RegexOptions.IgnoreCase);
            return searchString;
        }

        public static string ClearBR(string string_0)
        {
            Regex regex = null;
            Match match = null;
            regex = new Regex(@"(\r\n)", RegexOptions.IgnoreCase);
            for (match = regex.Match(string_0); match.Success; match = match.NextMatch())
            {
                string_0 = string_0.Replace(match.Groups[0].ToString(), "");
            }
            return string_0;
        }

        public static string Clip(string string_0)
        {
            return Clip(string_0, 1);
        }

        public static string Clip(string string_0, int removeFromBeginning)
        {
            string str = string_0;
            if (string_0.Length > removeFromBeginning)
            {
                str = str.Remove(0, removeFromBeginning);
            }
            return str;
        }

        public static string Clip(string string_0, string removeUpTo)
        {
            int index = string_0.IndexOf(removeUpTo);
            string str = string_0;
            if ((string_0.Length > index) && (index > 0))
            {
                str = str.Remove(0, index);
            }
            return str;
        }

        public static T? ConvertNullableValue<T>(string value) where T : struct
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            try
            {
                if (value == string.Empty)
                {
                    return null;
                }
                return new T?((T)Convert.ChangeType(value, typeof(T)));
            }
            catch
            {
                return null;
            }
        }

        public static string ConvertToString(object[] args)
        {
            if ((args == null) || (args.Length == 0))
            {
                return string.Empty;
            }
            StringBuilder builder = new StringBuilder();
            foreach (object obj2 in args)
            {
                if (obj2 != null)
                {
                    builder.Append(obj2.ToString());
                }
            }
            return builder.ToString();
        }

        public static T ConvertValue<T>(string value) where T : struct
        {
            return ConvertValue<T>(value, default(T));
        }

        public static T ConvertValue<T>(string value, T defaultValue) where T : struct
        {
            if (string.IsNullOrEmpty(value))
            {
                return defaultValue;
            }
            try
            {
                value = value.Trim();
                if (value == string.Empty)
                {
                    return defaultValue;
                }
                Type type = typeof(T);
                if ((type == typeof(bool)) && ((value == "1") || (value == "0")))
                {
                    value = (value == "1") ? "True" : "False";
                }
                return (T)Convert.ChangeType(value, typeof(T));
            }
            catch
            {
                return defaultValue;
            }
        }

        public static string CreateGuid(string format)
        {
            long num = DateTime.Now.ToUniversalTime().ToFileTime();
            uint num2 = ((uint)(num >> 0x20)) + 0x146bf4;
            int tickCount = Environment.TickCount;
            byte[] buffer = new byte[8];
            new Random((int)num).NextBytes(buffer);
            buffer[2] = (byte)(tickCount >> 0x18);
            buffer[3] = (byte)(tickCount >> 0x10);
            buffer[4] = (byte)(tickCount >> 8);
            buffer[5] = (byte)tickCount;
            Guid guid = new Guid((int)num, (short)num2, (short)((num2 | 0x10000000) >> 0x10), buffer);
            return guid.ToString(format);
        }

        public static string Crop(string input, string startText, string endText)
        {
            string str = input;
            int index = str.ToLower().IndexOf(startText.ToLower());
            try
            {
                str = str.Remove(0, index).Replace(startText, "");
                int length = str.ToLower().IndexOf(endText.ToLower());
                return str.Substring(0, length);
            }
            catch
            {
                return "";
            }
        }

        public static string DecimalToHex(string string_0)
        {
            return Convert.ToString(Convert.ToInt32(string_0), 0x10);
        }

        public static string FastReplace(string original, string pattern, string replacement, StringComparison comparisonType)
        {
            if (original == null)
            {
                return null;
            }
            if (string.IsNullOrEmpty(pattern))
            {
                return original;
            }
            int length = pattern.Length;
            int num = -1;
            int startIndex = 0;
            StringBuilder builder = new StringBuilder();
        Label_003A:
            num = original.IndexOf(pattern, num + 1, comparisonType);
            if (num >= 0)
            {
                builder.Append(original, startIndex, num - startIndex);
                builder.Append(replacement);
                startIndex = num + length;
                goto Label_003A;
            }
            builder.Append(original, startIndex, original.Length - startIndex);
            return builder.ToString();
        }

        public static int GetIndexOfSpacer(string string_0, int currentPosition, ref bool isNewLine)
        {
            int index = string_0.IndexOf(" ", currentPosition);
            int num2 = string_0.IndexOf(Environment.NewLine, currentPosition);
            bool flag = index > -1;
            bool flag2 = num2 > -1;
            isNewLine = false;
            if (flag && flag2)
            {
                if (index < num2)
                {
                    return index;
                }
                isNewLine = true;

                return num2;

            }

            if (flag && !flag2)
            {
                return index;
            }
            if (!flag && flag2)
            {
                isNewLine = true;
                return num2;
            }
            return -1;
        }

        public static int GetStringLength(string string_0)
        {
            return Encoding.Default.GetBytes(string_0).Length;
        }

        public static byte[] HexToByteArray(string string_0)
        {
            byte[] buffer = new byte[string_0.Length / 2];
            for (int i = 0; i < string_0.Length; i += 2)
            {
                buffer[i / 2] = Convert.ToByte(string_0.Substring(i, 2), 0x10);
            }
            return buffer;
        }

        public static bool IsHex(string string_0)
        {
            return (!string.IsNullOrEmpty(string_0) && string.IsNullOrEmpty(ReplaceChars(string_0, "0123456789ABCDEFabcdef", "                      ").Trim()));
        }

        public static bool IsMatch(string stringA, string stringB)
        {
            return string.Equals(stringA, stringB, StringComparison.InvariantCultureIgnoreCase);
        }

        public static bool IsMatch(string stringA, string stringB, bool trimStrings)
        {
            if (trimStrings)
            {
                return string.Equals(stringA.Trim(), stringB.Trim(), StringComparison.InvariantCultureIgnoreCase);
            }
            return string.Equals(stringA, stringB, StringComparison.InvariantCultureIgnoreCase);
        }

        public static bool IsRegexMatch(string inputString, string matchPattern)
        {
            return Regex.IsMatch(inputString, matchPattern, RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase);
        }

        public static bool IsStringNumeric(string string_0)
        {
            double num;
            return double.TryParse(string_0, NumberStyles.Float, (IFormatProvider)NumberFormatInfo.CurrentInfo, out num);
        }

        public static string JavaScriptEscape(string content)
        {
            return content.Replace("\"", "\\\"").Replace("\r", "").Replace("\n", @"\n").Replace("'", @"\'");
        }

        public static string Join(IList<string> items, string delimeter)
        {
            string str = "";
            int num = 0;
            while (num < (items.Count - 2))
            {
                str = str + items[num] + delimeter;
                num++;
            }
            return (str + items[num]);
        }

        public static IList<string> ReadLines(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new List<string>();
            }
            StringReader reader = new StringReader(text);
            string item = reader.ReadLine();
            IList<string> list = new List<string>();
            while (item != null)
            {
                list.Add(item);
                item = reader.ReadLine();
            }
            return list;
        }

        public static string Replace(string word, string find, string replaceWith, bool removeUnderscores)
        {
            string[] strArray = Split(find);
            string str = word;
            foreach (string str2 in strArray)
            {
                if (str2.Length > 0)
                {
                    str = str.Replace(str2, replaceWith);
                }
            }
            if (removeUnderscores)
            {
                return str.Replace(" ", "").Replace("_", "").Trim();
            }
            return str.Replace(" ", "").Trim();
        }

        public static string ReplaceChars(string string_0, string originalChars, string newChars)
        {
            string str = "";
            for (int i = 0; i < string_0.Length; i++)
            {
                int index = originalChars.IndexOf(string_0.Substring(i, 1));
                if (-1 != index)
                {
                    str = str + newChars.Substring(index, 1);
                }
                else
                {
                    str = str + string_0.Substring(i, 1);
                }
            }
            return str;
        }

        public static string ROT13Encode(string inputText)
        {
            string str = "";
            for (int i = 0; i < inputText.Length; i++)
            {
                int num2 = Convert.ToChar(inputText.Substring(i, 1));
                if ((num2 >= 0x61) && (num2 <= 0x6d))
                {
                    num2 += 13;
                }
                else if ((num2 >= 110) && (num2 <= 0x7a))
                {
                    num2 -= 13;
                }
                else if ((num2 >= 0x41) && (num2 <= 0x4d))
                {
                    num2 += 13;
                }
                else if ((num2 >= 0x4e) && (num2 <= 90))
                {
                    num2 -= 13;
                }
                str = str + ((char)num2);
            }
            return str;
        }

        public static string[] Split(string list)
        {
            try
            {
                return list.Split(new string[] { ", ", "," }, StringSplitOptions.RemoveEmptyEntries);
            }
            catch
            {
                return new string[] { string.Empty };
            }
        }

        public static string[] SplitString(string strContent, string strSplit)
        {
            if (string.IsNullOrEmpty(strContent))
            {
                return new string[0];
            }
            if (strContent.IndexOf(strSplit) < 0)
            {
                return new string[] { strContent };
            }
            return Regex.Split(strContent, Regex.Escape(strSplit), RegexOptions.IgnoreCase);
        }

        public static string[] SplitString(string strContent, string strSplit, int count)
        {
            string[] strArray = new string[count];
            string[] strArray2 = SplitString(strContent, strSplit);
            for (int i = 0; i < count; i++)
            {
                if (i < strArray2.Length)
                {
                    strArray[i] = strArray2[i];
                }
                else
                {
                    strArray[i] = string.Empty;
                }
            }
            return strArray;
        }

        public static string Squeeze(string input)
        {
            char[] separator = new char[] { ' ' };
            string[] strArray = input.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder builder = new StringBuilder();
            foreach (string str in strArray)
            {
                if (!string.IsNullOrEmpty(str.Trim()))
                {
                    builder.Append(str + " ");
                }
            }
            return Chop(builder.ToString()).Trim();
        }

        public static bool StartsWith(string word, string list)
        {
            if (string.IsNullOrEmpty(list))
            {
                return true;
            }
            foreach (string str in Split(list))
            {
                if (word.StartsWith(str, StringComparison.CurrentCultureIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        public static string StrFilter(string string_0, string bantext)
        {
            string oldValue = "";
            string newValue = "";
            string[] strArray = SplitString(bantext, "\r\n");
            for (int i = 0; i < strArray.Length; i++)
            {
                oldValue = strArray[i].Substring(0, strArray[i].IndexOf("="));
                newValue = strArray[i].Substring(strArray[i].IndexOf("=") + 1);
                string_0 = string_0.Replace(oldValue, newValue);
            }
            return string_0;
        }

        public static string Strip(string input, string stripValue)
        {
            if (!string.IsNullOrEmpty(stripValue))
            {
                string[] strArray = stripValue.Split(new char[] { ',' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (!string.IsNullOrEmpty(input))
                    {
                        input = Regex.Replace(input, strArray[i], string.Empty);
                    }
                }
            }
            return input;
        }

        public static string StripWhitespace(string inputString)
        {
            if (!string.IsNullOrEmpty(inputString))
            {
                return Regex.Replace(inputString, @"\s", string.Empty);
            }
            return inputString;
        }

        public static string[] ToStringArray(string delimitedText, char delimeter)
        {
            if (string.IsNullOrEmpty(delimitedText))
            {
                return null;
            }
            return delimitedText.Split(new char[] { delimeter });
        }

        public static string[] ToWords(string string_0)
        {
            return string_0.Trim().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        }

        public static string Trim(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }
            return value.Trim();
        }

        public static string Trim(string rawString, int maxLength)
        {
            return Trim(rawString, maxLength, "...");
        }

        public static string Trim(string rawString, int maxLength, string tailString)
        {
            if (string.IsNullOrEmpty(rawString))
            {
                return rawString;
            }
            string str = string.Empty;
            int byteCount = Encoding.Default.GetByteCount(rawString);
            int length = rawString.Length;
            int num2 = 0;
            int num3 = 0;
            if (byteCount <= maxLength)
            {
                return rawString;
            }
            for (int i = 0; i < length; i++)
            {
                if (Convert.ToInt32(rawString.ToCharArray()[i]) > 0xff)
                {
                    num2 += 2;
                }
                else
                {
                    num2++;
                }
                if (num2 > maxLength)
                {
                    num3 = i;
                    break;
                }
                if (num2 == maxLength)
                {
                    num3 = i + 1;
                    break;
                }
            }
            if (num3 >= 0)
            {
                str = rawString.Substring(0, num3) + tailString;
            }
            return str;
        }

        [CompilerGenerated]
        private sealed class Class23
        {
            public string string_0;

            public void method_0(KeyValuePair<string, string> keyValuePair_0)
            {
                this.string_0 = this.string_0.Replace("${" + keyValuePair_0.Key + "}", keyValuePair_0.Value);
            }
        }
    }
}
