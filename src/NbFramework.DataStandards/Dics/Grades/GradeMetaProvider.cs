using System.Linq;
using NbFramework.DataStandards.Core.DicItems;
using NbFramework.DataStandards.Core.DicTypes;
using NbFramework.DataStandards.Core.Inits;

namespace NbFramework.DataStandards.Dics.Grades
{
    public class GradeMetaProvider : IDicMetaProvider
    {
        public DicMeta Create()
        {
            var dicType = DicType.AutoCreateFromAttribute(x => Dic_DicTypeCode.Grade, typeof (Dic_DicTypeCode));
            var dicMeta = DicMeta.Create(dicType);
            var orgTypeItems = DicItem.AutoCreateAllFromAttribute(typeof (Dic_GradeCode), Dic_DicTypeCode.Grade);
            dicMeta.DicItems = orgTypeItems.Cast<IDicItem>().ToList();
            return dicMeta;
        }
    }
}
