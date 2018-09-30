using System.Collections.Generic;
using NbFramework.Common;
using NbFramework.DataStandards.Core.DicItems;
using NbFramework.DataStandards.Core.DicRelations;
using NbFramework.DataStandards.Core.DicTypes;

namespace NbFramework.DataStandards.Core.Inits
{
    /// <summary>
    /// 字典的编码注册表
    /// </summary>
    public class DicRegistry : NbRegistry<DicRegistry>
    {
        /// <summary>
        /// 所有的字典类型
        /// </summary>
        public List<IDicType> DicTypes { get; set; }
        /// <summary>
        /// 所有的字典项
        /// </summary>
        public List<IDicItem> DicItems { get; set; }
        /// <summary>
        /// 字典关系（描述两种字典的映射关系，例如学科和学段）
        /// </summary>
        public List<IDicRelation> DicRelations { get; set; }

        /// <summary>
        /// 字典的编码注册表
        /// </summary>
        public DicRegistry()
        {
            DicTypes = new List<IDicType>();
            DicItems = new List<IDicItem>();
            DicRelations = new List<IDicRelation>();
        }
    }
}
