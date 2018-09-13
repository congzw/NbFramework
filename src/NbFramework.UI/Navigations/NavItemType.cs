using System;

namespace NbFramework.UI.Navigations
{
    [Flags]
    public enum NavItemType
    {
        Breadcrumb = 1 << 0,
        Menu = 1 << 1
    }

    /// <summary>
    /// NavItemType Extensions
    /// </summary>
    public static class NavItemTypeExtensions
    {
        /// <summary>
        /// 是否包含此标志位
        /// </summary>
        /// <param name="value"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        public static bool HasType(this string value, NavItemType flag)
        {
            NavItemType result;
            var tryParse = Enum.TryParse(value, true, out result);
            if (!tryParse)
            {
                return false;
            }
            return result.HasFlag(flag);
        }

        /// <summary>
        /// "Breadcrumb, Menu" => Breadcrumb | Menu
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static NavItemType? TryParseTypeNames(this string value, NavItemType? defaultValue = null)
        {
            NavItemType result;
            var tryParse = Enum.TryParse(value, true, out result);
            if (tryParse)
            {
                return result;
            }
            return defaultValue;
        }

        /// <summary>
        /// Breadcrumb | Menu => "Breadcrumb, Menu"
        /// </summary>
        /// <param name="navItemType"></param>
        /// <returns></returns>
        public static string ToTypeNames(this NavItemType navItemType)
        {
            return navItemType.ToString("G");
        }
    }
}