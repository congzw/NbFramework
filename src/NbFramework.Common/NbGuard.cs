using System;
using NbFramework.Common.Extensions;

namespace NbFramework.Common
{
    /// <summary>
    /// 防御Coding的帮助类，包含常用的一些验证断言
    /// </summary>
    public class NbGuard
    {
        /// <summary>
        /// 保证不是默认值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        public static void MakeSureIsNotDefault<T>(T instance)
        {
            var value = default(T);
            bool isEqual = Equals(instance, value); 

            if (isEqual)
            {
                string exMessage = string.Format("值不能为:{0}", instance);
                exMessage = exMessage == "值不能为:" ? "值不能为:null" : exMessage;
                throw new ArgumentException(exMessage);
            }
        }

        /// <summary>
        /// Checks a value is between a minimum and maximum value.
        /// </summary>
        /// <param name="value">The value to be checked</param>
        /// <param name="min">Minimum (exclusive) value</param>
        /// <param name="max">Maximum (exclusive) value</param>
        public static void MakeSureBetweenExclusive<T>(T value, T min, T max) where T : IComparable<T>
        {
            MakeSureBetween(value, min, max, false, false);
        }

        /// <summary>
        /// Checks a value is between a minimum and maximum value. 
        /// </summary>
        /// <param name="value">The value to be checked</param>
        /// <param name="min">Minimum (inclusive) value</param>
        /// <param name="max">Maximum (inclusive) value</param>
        public static void MakeSureBetweenInclusive<T>(T value, T min, T max) where T : IComparable<T>
        {
            MakeSureBetween(value, min, max, true, true);
        }

        /// <summary>
        /// 整数范围
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="inclusiveMin">包含最小</param>
        /// <param name="inclusiveMax">包含最大</param>
        /// <returns></returns>
        public static void MakeSureBetween<T>(T value, T min, T max, bool inclusiveMin, bool inclusiveMax) where T : IComparable<T>
        {

            var isOk = value.IsBetween(min, max, inclusiveMin, inclusiveMax);
            if (!isOk)
            {
                string exMessage = string.Format("输入参数{0}不满足此条件：大于{1}{2}, 且小于{3}{4}", value, inclusiveMin ? "等于" : "", min, inclusiveMax ? "等于" : "", max);
                throw new ArgumentException(exMessage);
            }
        }

        /// <summary>
        /// 字符串不能为空值
        /// </summary>
        /// <param name="value"></param>
        public static void NotNullOrWhiteSpace(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                string exMessage = string.Format("字符串不能为空值:{0}", value);
                throw new ArgumentException(exMessage);
            }
        }
    }
}