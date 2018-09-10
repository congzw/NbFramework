namespace NbFramework.TextRules.Core
{
    public class TextRule
    {
        public string Name { get; set; }
        public string Value { get; set; }

        // => "*", ""
        // => "SiteA", "SiteB, SiteC"
        public string Scope { get; set; }
    }
}