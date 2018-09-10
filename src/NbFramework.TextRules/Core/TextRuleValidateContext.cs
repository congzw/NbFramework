using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace NbFramework.TextRules.Core
{
    public class TextRuleValidateContext
    {
        public Func<DateTime> GetNow { get; set; }
        //public Func<IDictionary<string, object>> GetEnvirenmentContext { get; set; }
        public Func<string> GetMachineCode { get; set; }
        public Func<IDictionary<string, object>> GetRequestContext { get; set; }
    }

    internal class EmptyTextRuleValidateContext : TextRuleValidateContext
    {
        public EmptyTextRuleValidateContext()
        {
            GetNow = () => DateTime.Now;
            GetMachineCode = () => string.Empty;
            GetRequestContext = () => new ConcurrentDictionary<string, object>();
        }
    }
}