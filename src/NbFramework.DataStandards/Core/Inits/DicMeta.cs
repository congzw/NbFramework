using System;
using System.Collections.Generic;
using NbFramework.DataStandards.Core.DicItems;
using NbFramework.DataStandards.Core.DicRelations;
using NbFramework.DataStandards.Core.DicTypes;

namespace NbFramework.DataStandards.Core.Inits
{
    public class DicMeta
    {
        private DicMeta(IDicType dicType)
        {
            if (dicType == null)
            {
                throw new ArgumentNullException("dicType");
            }
            DicType = dicType;
            DicItems = new List<IDicItem>();
            Relations = new List<IDicRelation>();
        }

        public IDicType DicType { get; set; }
        public IList<IDicItem> DicItems { get; set; }
        public IList<IDicRelation> Relations { get; set; }

        public static DicMeta Create(IDicType dicType)
        {
            var dicMeta = new DicMeta(dicType);
            return dicMeta;
        }
    }
}
