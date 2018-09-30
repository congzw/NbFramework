using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        //public class DicRelationDto
        //{
        //    public string PhaseCode { get; set; }
        //    public string SubjectCode { get; set; }
        //    public string PhaseName { get; set; }
        //    public string SubjectName { get; set; }
        //}

        //public class DicItemDto
        //{
        //    public string Code { get; set; }
        //    public string Name { get; set; }
        //}

        //public static string Temp(string[] lines)
        //{
        //    string template = "[NbRefField(\"{0}\")]\r\npublic static string {0} = \"{1}\"; ";
        //    StringBuilder sb = new StringBuilder();
        //    //sb.AppendLine(string.Format(template, dicItemDto.Name, dicItemDto.Code));

        //    var dicItemDtos = new List<DicItemDto>();
        //    foreach (var line in lines)
        //    {
        //        var dicItemDto = new DicItemDto();
        //        var strings = line.Split(',');
        //        dicItemDto.PhaseCode = strings[0].Replace('"', ' ').Trim();
        //        dicItemDto.SubjectCode = strings[1].Replace('"', ' ').Trim();
        //        dicItemDto.PhaseName = strings[2].Replace('"', ' ').Trim();
        //        dicItemDto.SubjectName = strings[3].Replace('"', ' ').Trim();
        //        dicItemDtos.Add(dicItemDto);
        //    }


        //    var groupBy = dicItemDtos.GroupBy(x => x.PhaseName).Select(g =>
        //    {
        //        var list = g.ToList().Select(x => x.SubjectName).ToList();
        //        var codes = string.Join(",", list);
        //        sb.AppendLine(string.Format(template, g.Key, codes));
        //        return g.Key;
        //    }).ToList();
        //    return sb.ToString();
        //}
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
