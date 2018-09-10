using System.Collections.Generic;

namespace NbFramework.TextRules.Core
{
    public class TextRuleNames
    {
        public static string Customer = "Customer";
        public static string MachineCode = "MachineCode";
        public static string SiteCount = "SiteCount";
        public static string DateExpired = "DateExpired";
        public static string V2EntryCount = "V2EntryCount";


        private static IList<string> _knownTextRuleNames = new List<string>()
        {
            Customer,
            MachineCode,
            SiteCount,
            DateExpired,
            V2EntryCount
        };
        public static IList<string> KnownTextRuleNames
        {
            get { return _knownTextRuleNames; }
            set { _knownTextRuleNames = value; }
        }
    }
}
