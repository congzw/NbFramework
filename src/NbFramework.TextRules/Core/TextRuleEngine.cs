using System;
using System.Collections.Generic;
using System.Linq;

namespace NbFramework.TextRules.Core
{
    public class TextRuleEngine
    {
        public TextRuleEngine()
        {
            Validators = new List<ITextRuleValidator>();
            Rules = new List<TextRule>();
            GetValidateContext = () => new EmptyTextRuleValidateContext();
        }

        public IList<ITextRuleValidator> Validators { get; set; }
        public IList<TextRule> Rules { get; set; }
        public Func<TextRuleValidateContext> GetValidateContext { get; set; }

        public TextRuleResult Validate_ApplicationStart()
        {
            return ValidateByMode(TextRuleValidateMode.OnApplicationStart);
        }
        
        public TextRuleResult Validate_Request()
        {
            return ValidateByMode(TextRuleValidateMode.OnRequest);
        }
        
        public TextRuleResult Validate_Timer()
        {
            return ValidateByMode(TextRuleValidateMode.OnTimer);
        }

        public TextRuleResult ValidateByMode(TextRuleValidateMode mode)
        {
            //todo cache per mode?
            var validators = Validators.Where(x => x.Mode.HasFlag(mode));
            var licenseValidateContext = GetValidateContext();

            foreach (var validator in validators)
            {
                var vr = validator.Validate(Rules, licenseValidateContext);
                if (!vr.Success)
                {
                    return vr;
                }
            }

            return new TextRuleResult() { Message = "OK", Success = true };
        }
    }
}