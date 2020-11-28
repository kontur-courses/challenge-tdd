using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App
{
    public static class Extensions
    {
        public static string[] SplitWithSeparators(this string str, char[] separators)
        {
            if (str == null || separators == null)
                throw new ArgumentNullException();

            var parts = new List<string>();

            var token = new StringBuilder();
            for (var i = 0; i < str.Length; i++)
            {
                if (separators.Contains(str[i]))
                {
                    if (token.Length > 0)
                    {
                        parts.Add(token.ToString());
                        token.Clear();
                    }
                    parts.Add(str[i].ToString());
                }
                else
                {
                    token.Append(str[i]);
                }
            }
            if (token.Length > 0)
            {
                parts.Add(token.ToString());
            }

            return parts.ToArray();
        }
    }
}
