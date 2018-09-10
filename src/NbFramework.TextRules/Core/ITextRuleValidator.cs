using System;
using System.Collections.Generic;

namespace NbFramework.TextRules.Core
{
    public interface ITextRuleValidator
    {
        TextRuleValidateMode Mode { get; }
        TextRuleResult Validate(IList<TextRule> rules, TextRuleValidateContext ctx);
    }

    #region models
    
    [Flags]
    public enum TextRuleValidateMode
    {
        None = 0,
        OnApplicationStart = 1 << 0,
        OnRequest = 1 << 1,
        OnTimer = 1 << 2
    }

    public class TextRuleResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }

    #endregion
}