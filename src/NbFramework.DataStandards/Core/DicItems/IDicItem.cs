namespace NbFramework.DataStandards.Core.DicItems
{
    /// <summary>
    /// 字典项
    /// </summary>
    public interface IDicItem
    {
        /// <summary>
        /// 字典类型码
        /// </summary>
        string DicTypeCode { get; set; }
        /// <summary>
        /// 字典编码，系统项不可以修改
        /// 内置的编码为国家标准码或自定义码
        /// 定制的编码为GuidComb
        /// </summary>
        string Code { get; set; }
        /// <summary>
        /// 显示名字，不同DicTypeCode可重复
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// 可空预留，模糊匹配用
        /// </summary>
        string Tags { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        string Description { get; set; }
        /// <summary>
        /// 是否是系统预置项
        /// </summary>
        bool IsSystemItem { get; set; }
        /// <summary>
        /// 二级分类，预留扩展，例如： A.B.C.
        /// </summary>
        string SubCategory { get; set; }
    }
}
