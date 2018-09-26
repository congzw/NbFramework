﻿namespace NbFramework.DataStandards
{
    /// <summary>
    /// 字典类型的接口
    /// </summary>
    public interface IDicType
    {
        /// <summary>
        /// 作为唯一键使用，不可更改：Grade,Subject等
        /// </summary>
        string Code { get; set; }

        /// <summary>
        ///  显示名
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        bool InUse { get; set; }

        /// <summary>
        /// 某些字典类型下的条目不需要提供修改功能
        /// </summary>
        bool CanEdit { get; set; }
    }
}
