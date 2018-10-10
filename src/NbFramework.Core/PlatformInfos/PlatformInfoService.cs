using System;

namespace NbFramework.Core.PlatformInfos
{
    public interface IPlatformInfoService
    {
        PlatformInfo GetPlatformInfo();
    }

    public class PlatformInfoService : IPlatformInfoService
    {
        public PlatformInfo GetPlatformInfo()
        {
            //todo customize by context
            return new PlatformInfo()
            {
                Code = "NbCloud",
                Name = "NbCloud",
                Copyright = string.Format("{0}-{1} All Rights Reserved", 2011, DateTime.Now.Year),
                Version = "1.0.0"
            };
        }
    }
}