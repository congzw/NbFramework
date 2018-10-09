namespace NbFramework.Core.SoftwareMetas
{
    /// <summary>
    /// 模块的元信息
    /// </summary>
    public class MoudleMeta : BaseSoftwareMeta
    {
        /// <summary>
        /// 需要平台的最小版本，如3.1
        /// </summary>
        public string MinPlatformVersion { get; set; }
        /// <summary>
        /// 需要平台的最大版本，如3.5
        /// </summary>
        public string MaxPlatformVersion { get; set; }
    }
}