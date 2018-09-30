using System;
using System.Collections.Generic;
using System.IO;
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
        public class DicItemDto
        {
            public string Code { get; set; }
            public string Name { get; set; }
        }

        public static string Temp(string[] lines)
        {
            string template = "[NbRefField(\"{0}\")]\r\npublic static string {1} = \"{1}\"; ";
            StringBuilder sb = new StringBuilder();
            foreach (var line in lines)
            {
                var dicItemDto = new DicItemDto();
                var strings = line.Split(',');
                dicItemDto.Code = strings[0].Replace('"',' ').Trim();
                dicItemDto.Name = strings[1].Replace('"', ' ').Trim();
                sb.AppendLine(string.Format(template, dicItemDto.Name, dicItemDto.Code));
            }
            return sb.ToString();
        }
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
