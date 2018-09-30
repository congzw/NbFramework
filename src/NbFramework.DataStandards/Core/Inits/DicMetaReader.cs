using System.Collections.Generic;
using NbFramework.Common;
using NbFramework.DataStandards.Core.DicTypes;
using NbFramework.DataStandards.Dics;

namespace NbFramework.DataStandards.Core.Inits
{
    public interface IDicMetaReader
    {
        IList<DicType> LoadDicTypes();
    }

    public class AssemblyDicMetaReader : IDicMetaReader
    {
        public IList<DicType> LoadDicTypes()
        {
            var dicTypes = new List<DicType>();
            var simpleJsonHelper = SimpleJsonHelper.Resolve();
            var dicTypeRefs = NbRefFieldValue.GetAllNbRefFieldStrings(typeof(Dic_DicTypeCode));
            foreach (var dicTypeRef in dicTypeRefs)
            {
                var dicType = (DicType)simpleJsonHelper.Deserialize(dicTypeRef.ValueBag, typeof(DicType));
                dicTypes.Add(dicType);
            }
            return dicTypes;
        }
    }
}
