using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using NbFramework.Common;
using NbFramework.DataStandards.Core.DicItems;
using NbFramework.DataStandards.Core.DicRelations;
using NbFramework.DataStandards.Core.DicTypes;
using NbFramework.DataStandards.Core.Inits;

namespace NbFramework.CodeGenerate.DicRegistrys
{
    public class DicRegistryCode
    {
    }


    public class MyClass
    {
        private void AppendDicTypes(DicRegistry dicRegistry, IDicType dicType, IList<IDicItem> dicItems, IList<IDicRelation> dicRelations)
        {
            dicRegistry.DicTypes.Add(dicType);
            foreach (var dicItem in dicItems)
            {
                dicRegistry.DicItems.Add(dicItem);
            }
            foreach (var dicRelation in dicRelations)
            {
                dicRegistry.DicRelations.Add(dicRelation);
            }
        }
    }
}
