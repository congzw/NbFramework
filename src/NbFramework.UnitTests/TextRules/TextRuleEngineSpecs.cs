using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NbFramework.TextRules.Core;

namespace NbFramework.TextRules
{
    [TestClass]
    public class TextRuleEngineSpecs
    {
        [TestMethod]
        public void not_expire_date_should_ok()
        {
            var engine = TextEngineFactory.Create();
            engine.GetValidateContext = () => new TextRuleValidateContext()
            {
                GetMachineCode = () => "ABC",
                GetNow = () => new DateTime(2000, 1, 1),
                GetRequestContext = () => new Dictionary<string, object>()
            };

            var vr = engine.Validate_ApplicationStart();
            Console.WriteLine(vr.Message);
            Assert.IsTrue(vr.Success);
        }

        [TestMethod]
        public void expire_date_should_failed()
        {
            var engine = TextEngineFactory.Create();
            engine.GetValidateContext = () => new TextRuleValidateContext()
            {
                GetMachineCode = () => "ABC",
                GetNow = () => new DateTime(2000, 2, 1),
                GetRequestContext = () => new Dictionary<string, object>()
            };

            var vr = engine.Validate_ApplicationStart();
            Console.WriteLine(vr.Message);
            Assert.IsFalse(vr.Success);
        }
    }
}
