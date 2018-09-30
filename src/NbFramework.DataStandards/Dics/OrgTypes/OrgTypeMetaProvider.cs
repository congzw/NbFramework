using System.Linq;
using NbFramework.DataStandards.Core.DicItems;
using NbFramework.DataStandards.Core.DicTypes;
using NbFramework.DataStandards.Core.Inits;

namespace NbFramework.DataStandards.Dics.OrgTypes
{
    public class OrgTypeMetaProvider : IDicMetaProvider
    {
        public DicMeta Create()
        {
            var dicType = DicType.AutoCreateFromAttribute(x => Dic_DicTypeCode.OrgType, typeof (Dic_DicTypeCode));
            var dicMeta = DicMeta.Create(dicType);
            var orgTypeItems = DicItem.AutoCreateAllFromAttribute(typeof (Dic_OrgTypeCode), Dic_DicTypeCode.OrgType);
            dicMeta.DicItems = orgTypeItems.Cast<IDicItem>().ToList();
            return dicMeta;
        }
    }
}
