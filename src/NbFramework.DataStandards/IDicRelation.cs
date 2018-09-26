using System;
using System.Collections.Generic;
using System.Linq;
using NbFramework.Common;

namespace NbFramework.DataStandards
{
    public interface IDicRelation
    {
        /// <summary>
        /// A.B
        /// A.B.C
        /// </summary>
        string DicTypeCodes { get; set; }
        /// <summary>
        /// a.b
        /// a.b.c
        /// </summary>
        string DicItemCodes { get; set; }
        /// <summary>
        /// 关系数量，默认是2： A.B
        /// </summary>
        int RelationDeep { get; set; }
        /// <summary>
        /// 是否可以编辑
        /// </summary>
        bool CanEdit { get; set; }
        /// <summary>
        /// 是否是系统预置项
        /// </summary>
        bool IsSystemItem { get; set; }
    }

    public class RelationPart
    {
        public string DicTypeCode { get; set; }
        public string DicItemCode { get; set; }
    }

    public class RelationUnit
    {
        public RelationUnit()
        {
            Parts = new List<RelationPart>();
        }

        public IList<RelationPart> Parts { get; set; }

        public static RelationUnit Create(IDicRelation dicRelation)
        {
            NbGuard.MakeSureIsNotDefault(dicRelation);

            var relation = new RelationUnit();
            var dicTypeCodes = dicRelation.DicTypeCodes.Split('.');
            var dicItemCodes = dicRelation.DicItemCodes.Split('.');
            var relationDeep = dicRelation.RelationDeep;
            for (int i = 0; i < relationDeep; i++)
            {
                relation.Parts.Add(new RelationPart() { DicTypeCode = dicTypeCodes[i], DicItemCode = dicItemCodes[i] });
            }
            return relation;
        }
    }

    public class RelationUnitForDouble : RelationUnit
    {
        public RelationPart GetLeft()
        {
            if (Parts.Count != 2)
            {
                throw new InvalidOperationException("必须包含二元关系");
            }
            return Parts[0];
        }
        public RelationPart GetRight()
        {
            if (Parts.Count != 2)
            {
                throw new InvalidOperationException("必须包含二元关系");
            }
            return Parts[1];
        }
    }

    /// <summary>
    /// DicRelation Extensions
    /// </summary>
    public static class DicRelationExtensions
    {
        /// <summary>
        /// 获取唯一键
        /// </summary>
        /// <param name="dicRelation"></param>
        /// <param name="codes"></param>
        /// <returns></returns>
        public static string CreateUniqueKey(this IDicRelation dicRelation, params string[] codes)
        {
            NbGuard.MakeSureIsNotDefault(dicRelation);
            if (codes.Length < 2)
            {
                throw new InvalidOperationException("必须至少包含两个以上的参数");
            }
            return string.Join(".", codes);
        }

        public static IList<RelationUnit> ToRelations(this IEnumerable<IDicRelation> dicRelations)
        {
            var relationList = dicRelations as IList<IDicRelation> ?? dicRelations.ToList();
            NbGuard.MakeSureIsNotDefault(relationList);

            var relations = relationList.Select(RelationUnit.Create).ToList();
            return relations;
        }
    }
}
