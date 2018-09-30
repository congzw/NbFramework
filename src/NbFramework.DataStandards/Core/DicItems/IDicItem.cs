using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using NbFramework.Common;

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

    public class DicItem : IDicItem
    {
        public string DicTypeCode { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Tags { get; set; }
        public string Description { get; set; }
        public bool IsSystemItem { get; set; }
        public string SubCategory { get; set; }


        public static DicItem Create(string dicTypeCode, string code, string name)
        {
            //Guard check, todo 
            return new DicItem() {DicTypeCode = dicTypeCode, Code = code, Name = name};
        }

        public static DicItem AutoCreateFromAttribute(Expression<Func<object, object>> action, Type classType, string dicTypeCode)
        {
            var nbRefFieldValue = NbRefFieldValue.GetRefFieldValue(action, classType);
            if (nbRefFieldValue == null)
            {
                return null;
            }
            return Create(dicTypeCode, nbRefFieldValue.FieldValue, nbRefFieldValue.Description);
        }

        public static IList<DicItem> AutoCreateAllFromAttribute(Type classType, string dicTypeCode)
        {
            var dicItems = new List<DicItem>();
            var nbRefFieldValue = NbRefFieldValue.GetAllNbRefFieldStrings(classType);
            foreach (var refFieldValue in nbRefFieldValue)
            {
                var dicItem = Create(dicTypeCode, refFieldValue.FieldValue, refFieldValue.Description);
                dicItems.Add(dicItem);
            }
            return dicItems;
        }
    }
}
