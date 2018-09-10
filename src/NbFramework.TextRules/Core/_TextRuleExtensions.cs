using System;

namespace NbFramework.TextRules.Core
{
    public static class TextRuleExtensions
    {
        public static void ShouldNotNull(this object value, string name = null)
        {
            if (value == null)
            {
                if (name == null)
                {
                    throw new ArgumentNullException();
                }
                throw new ArgumentNullException(name);
            }
        }

        public static bool MyEquals(this string value, string another = null)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return string.IsNullOrWhiteSpace(another);
            }
            return value.Equals(another, StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsForRule(this TextRule rule, string ruleName)
        {
            rule.ShouldNotNull();
            ruleName.ShouldNotNull();
            return ruleName.MyEquals(rule.Name);
        }
    }
}
