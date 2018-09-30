namespace NbFramework.DataStandards.Core.DicTypes
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

    public class DicType : IDicType
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public bool InUse { get; set; }
        public bool CanEdit { get; set; }

        public static DicType Create(string code, string name, bool inUse = true, bool canEdit = true)
        {
            //Guard check, todo 
            return new DicType(){Code = code, Name = name, CanEdit = canEdit, InUse = inUse};
        }
    }
}
