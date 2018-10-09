namespace NbFramework.Core.SoftwareMetas
{
    /// <summary>
    /// 模块化的元信息
    /// </summary>
    public interface ISoftwareMeta
    {
        /// <summary>
        /// 唯一名
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// 友好名
        /// </summary>
        string FriendlyName { get; set; }
        /// <summary>
        ///内部版本
        /// </summary>
        string Version { get; set; }
        /// <summary>
        /// 对外版本
        /// </summary>
        string VersionInfo { get; set; }
    }

    public abstract class BaseSoftwareMeta : ISoftwareMeta
    {
        public string Name { get; set; }
        public string FriendlyName { get; set; }
        public string Version { get; set; }
        public string VersionInfo { get; set; }
    }
}
