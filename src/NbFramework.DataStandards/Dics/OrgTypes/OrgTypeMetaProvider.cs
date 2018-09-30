using NbFramework.DataStandards.Core.DicTypes;
using NbFramework.DataStandards.Core.Inits;

namespace NbFramework.DataStandards.Dics.OrgTypes
{
    public class OrgTypeMetaProvider : IDicMetaProvider
    {
        public DicMeta Create()
        {
            var dicType = DicType.Create(Dic_DicTypeCode.OrgType, "组织类型", true, false);
            var dicMeta = DicMeta.Create(dicType);
            return dicMeta;
        }
    }
}