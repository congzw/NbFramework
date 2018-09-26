using System.Collections.Generic;
using NbFramework.Common;

namespace NbFramework.DataStandards.Core.DicTypes
{
    public interface IDicTypeService
    {
        /// <summary>
        /// 查找所有的字典类型
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        IList<DicType> GetDicTypes(GetDicTypesArgs args);
        
        /// <summary>
        /// 批量增加验证
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        MessageResult BatchAddValidate(IList<DicType> list);

        /// <summary>
        /// 批量增加
        /// </summary>
        /// <param name="list"></param>
        /// <param name="validateFirst"></param>
        MessageResult BatchAdd(IList<DicType> list, bool validateFirst);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        MessageResult Edit(DicType model);

        //how to process business logic? todo
        //MessageResult ChangeName();
        //MessageResult Enabled();
        //MessageResult Disabled();
    }

    public class GetDicTypesArgs
    {
        public bool? InUse { get; set; }
        public bool? CanEdit { get; set; }
    }
}
