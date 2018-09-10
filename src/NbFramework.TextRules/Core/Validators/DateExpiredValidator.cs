using System;
using System.Collections.Generic;

namespace NbFramework.TextRules.Core.Validators
{
    public class DateExpiredValidator : ITextRuleValidator
    {
        private TextRuleValidateMode _mode = TextRuleValidateMode.OnApplicationStart | TextRuleValidateMode.OnTimer;

        public TextRuleValidateMode Mode
        {
            get { return _mode; }
            private set { _mode = value; }
        }

        public TextRuleResult Validate(IList<TextRule> rules, TextRuleValidateContext ctx)
        {
            var mr = new TextRuleResult();
            mr.Message = "OK";
            mr.Success = true;

            foreach (var rule in rules)
            {
                if (rule.IsForRule(TextRuleNames.DateExpired))
                {
                    var dateTime = ctx.GetNow();
                    mr.Success = DateTime.Parse(rule.Value) >= dateTime;
                    mr.Message = "时间过期：" + rule.Value;
                    return mr;
                }
            }

            return mr;
        }
    }
}