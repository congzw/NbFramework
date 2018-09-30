using System.Linq;
using NbFramework.DataStandards.Core.DicItems;
using NbFramework.DataStandards.Core.DicTypes;
using NbFramework.DataStandards.Core.Inits;

namespace NbFramework.DataStandards.Dics.Phases
{
    public class PhaseMetaProvider : IDicMetaProvider
    {
        public DicMeta Create()
        {
            var dicType = DicType.AutoCreateFromAttribute(x => Dic_DicTypeCode.Phase, typeof (Dic_DicTypeCode));
            var dicMeta = DicMeta.Create(dicType);
            var dicItems = DicItem.AutoCreateAllFromAttribute(typeof (Dic_PhaseCode), Dic_DicTypeCode.Phase);
            dicMeta.DicItems = dicItems.Cast<IDicItem>().ToList();
            return dicMeta;
        }
    }
}
