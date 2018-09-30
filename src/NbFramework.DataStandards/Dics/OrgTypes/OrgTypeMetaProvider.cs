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
            //dicMeta.DicItems.Add();
            //dicMeta.DicRelations.Add();
            return dicMeta;
        }
    }
}
