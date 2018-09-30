using System;
using System.Collections.Generic;
using System.Linq;

namespace NbFramework.DataStandards.Core.Inits
{
    public class DicMetaRegistry
    {
        internal Dictionary<string, DicMeta> Metas { get; set; }

        public DicMetaRegistry()
        {
            Metas = new Dictionary<string, DicMeta>();
        }

        public void AddOrUpdate(DicMeta dicMeta)
        {
            //check args
            //add or replace
            var key = CreateKey(dicMeta);
            Metas[key] = dicMeta;
        }

        public DicMeta TryGet(string dicTypeCode)
        {
            var key = dicTypeCode.ToLower();
            return Metas[key];
        }

        public IReadOnlyList<DicMeta> GetDicMetas()
        {
            return Metas.Values.ToList();
        }

        private string CreateKey(DicMeta dicMeta)
        {
            if (dicMeta == null || dicMeta.DicType == null || string.IsNullOrWhiteSpace(dicMeta.DicType.Code))
            {
                throw new InvalidOperationException("DicTypeCode should not null");
            }
            return dicMeta.DicType.Code.ToLower();
        }
    }
}