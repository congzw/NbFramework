using System.Linq;
using NbFramework.DataStandards.Core.DicItems;
using NbFramework.DataStandards.Core.DicTypes;
using NbFramework.DataStandards.Core.Inits;

namespace NbFramework.DataStandards.Dics.Subjects
{
    public class SubjectMetaProvider : IDicMetaProvider
    {
        public DicMeta Create()
        {
            var dicType = DicType.AutoCreateFromAttribute(x => Dic_DicTypeCode.Subject, typeof (Dic_DicTypeCode));
            var dicMeta = DicMeta.Create(dicType);
            var orgTypeItems = DicItem.AutoCreateAllFromAttribute(typeof (Dic_SubjectCode), Dic_DicTypeCode.Subject);
            dicMeta.DicItems = orgTypeItems.Cast<IDicItem>().ToList();
            return dicMeta;
        }
    }
}
