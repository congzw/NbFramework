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
            DicRelations = new List<IDicRelation>();
        }

        public IDicType DicType { get; set; }
        public IList<IDicItem> DicItems { get; set; }
        public IList<IDicRelation> DicRelations { get; set; }

        public static DicMeta Create(IDicType dicType)
        {
            var dicMeta = new DicMeta(dicType);
            return dicMeta;
        }
    }

    public interface IDicMetaProvider
    {
        DicMeta Create();
    }

    #region temp

    //public class DicMetaRegistry
    //{
    //    internal Dictionary<string, DicMeta> Metas { get; set; }

    //    public DicMetaRegistry()
    //    {
    //        Metas = new Dictionary<string, DicMeta>();
    //    }

    //    public void AddOrUpdate(DicMeta dicMeta)
    //    {
    //        //check args
    //        //add or replace
    //        var key = CreateKey(dicMeta);
    //        Metas[key] = dicMeta;
    //    }

    //    public DicMeta TryGet(string dicTypeCode)
    //    {
    //        var key = dicTypeCode.ToLower();
    //        return Metas[key];
    //    }

    //    public IReadOnlyList<DicMeta> GetDicMetas()
    //    {
    //        return Metas.Values.ToList();
    //    }

    //    private string CreateKey(DicMeta dicMeta)
    //    {
    //        if (dicMeta == null || dicMeta.DicType == null || string.IsNullOrWhiteSpace(dicMeta.DicType.Code))
    //        {
    //            throw new InvalidOperationException("DicTypeCode should not null");
    //        }
    //        return dicMeta.DicType.Code.ToLower();
    //    }
    //}
    #endregion
}
