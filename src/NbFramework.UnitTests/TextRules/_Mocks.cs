using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbFramework.TextRules.Core;
using NbFramework.TextRules.Core.Validators;

namespace NbFramework.TextRules
{
    public class TextEngineFactory
    {
        public static TextRuleEngine Create()
        {
            var engine = new TextRuleEngine
            {
                Rules = LoadRules(),
                Validators = GetValidators()
            };
            return engine;
        }

        private static IList<TextRule> LoadRules()
        {
            var rules = new List<TextRule>();
            rules.Add(new TextRule() { Name = TextRuleNames.Customer, Value = "Foo", Scope = "" });
            rules.Add(new TextRule() { Name = TextRuleNames.MachineCode, Value = "abc", Scope = "" });
            rules.Add(new TextRule() { Name = TextRuleNames.SiteCount, Value = "3", Scope = "" });
            rules.Add(new TextRule() { Name = TextRuleNames.DateExpired, Value = "2000-01-01", Scope = "" });
            rules.Add(new TextRule() { Name = TextRuleNames.DateExpired, Value = "2000-02-01", Scope = "SiteA" });
            rules.Add(new TextRule() { Name = TextRuleNames.DateExpired, Value = "2000-03-01", Scope = "SiteB,SiteC" });
            rules.Add(new TextRule() { Name = TextRuleNames.V2EntryCount, Value = "3", Scope = "" });
            return rules;
        }
        private static IList<ITextRuleValidator> GetValidators()
        {
            var validators = new List<ITextRuleValidator>();
            validators.Add(new DateExpiredValidator());
            return validators;
        }

    }

    public class MockTextValidateContext
    {
        public DateTime GetNow()
        {
            return new DateTime(2000, 1, 1);
        }

        public string GetMachineCode()
        {
            return "ABC";
        }

        public IDictionary<string, object> GetRequestContext()
        {
            return new Dictionary<string, object>();
        }
    }
}
