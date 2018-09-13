using System;
using System.Collections.Generic;

namespace NbFramework.Common.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// 指示指定的字符串是 null、空还是仅由空白字符组成。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// 扩展的字符串比较
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="stringComparison"></param>
        /// <param name="trimSpaceBeforeCompare"></param>
        /// <returns></returns>
        public static bool NbEquals(this String value1, string value2, StringComparison stringComparison = StringComparison.OrdinalIgnoreCase)
        {
            if (value1 == null)
            {
                return string.IsNullOrWhiteSpace(value2);
            }

            if (value2 == null)
            {
                return string.IsNullOrWhiteSpace(value1);
            }

            return value1.Trim().Equals(value2.Trim(), stringComparison);
        }

        /// <summary>
        /// 扩展的字符串包含检测
        /// </summary>
        /// <param name="source"></param>
        /// <param name="toCheck"></param>
        /// <param name="comp"></param>
        /// <returns></returns>
        public static bool NbContains(this string source, string toCheck, StringComparison comp = StringComparison.OrdinalIgnoreCase)
        {
            if (source == null)
            {
                return false;
            }
            return source.IndexOf(toCheck, comp) >= 0;
        }

        /// <summary>
        /// Concatenates the members of a constructed <see cref="IEnumerable{T}"/> collection of type System.String, using the specified separator between each member.
        /// This is a shortcut for string.Join(...)
        /// </summary>
        /// <param name="source">A collection that contains the strings to concatenate.</param>
        /// <param name="separator">The string to use as a separator. separator is included in the returned string only if values has more than one element.</param>
        /// <returns>A string that consists of the members of values delimited by the separator string. If values has no members, the method returns System.String.Empty.</returns>
        public static string JoinAsString(this IEnumerable<string> source, string separator)
        {
            return string.Join(separator, source);
        }

    }
}
