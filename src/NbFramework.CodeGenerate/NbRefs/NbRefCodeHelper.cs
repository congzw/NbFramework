using System;
using System.Reflection;
using System.Text;
using NbFramework.Common;

namespace NbFramework.CodeGenerate.NbRefs
{
    public class NbRefCodeHelper
    {
        public static string Generate(params Assembly[] assemblies)
        {
            StringBuilder sb = new StringBuilder();
            if (assemblies == null || assemblies.Length == 0)
            {
                assemblies = AppDomain.CurrentDomain.GetAssemblies();
            }
            var dicTypeRefs = NbRefFieldValue.GetNbRefFieldDelcareTypes(assemblies);
            foreach (var dicTypeRef in dicTypeRefs)
            {
                var item = Generate(dicTypeRef);
                sb.Append(item);
                sb.AppendLine();
            }

            return sb.ToString();
        }
        public static string Generate(Type nbRefType)
        {
            var dicTypeRefs = NbRefFieldValue.GetAllNbRefFieldStrings(nbRefType);

            StringBuilder sb = new StringBuilder();
            foreach (var dicTypeRef in dicTypeRefs)
            {
                sb.AppendLine();
                var filedTemplate = FiledTemplate
                    .Replace(Holder_NbRefType, nbRefType.Name)
                    .Replace(Holder_NbRefFieldName, dicTypeRef.FieldName)
                    .Replace(Holder_NbRefFieldValue, dicTypeRef.FieldValue)
                    .Replace(Holder_NbRefFieldDesc, dicTypeRef.Description);
                sb.Append(filedTemplate);
                sb.AppendLine();
            }
            
            var classTemplate = ClassTemplate
                .Replace(Holder_NbRefType, nbRefType.Name)
                .Replace(Holder_Fileds, sb.ToString());
            return classTemplate;
        }
        
        #region template

        //public static class NbRefType
        //{
        //    [NbRefField("NbRefFieldDesc")]
        //    public static string NbRefFieldName = "NbRefFieldValue";
        //}

        ///// <summary>
        ///// Strong Type extensions for NbRefType
        ///// </summary>
        //public static class NbRefExt_NbRefType
        //{
        //    /// <summary>
        //    /// NbRefFieldName(NbRefFieldValue, NbRefFieldDesc)
        //    /// </summary>
        //    /// <param name="nbRef"></param>
        //    /// <returns></returns>
        //    public static string NbRefType_NbRefField(this NbRef nbRef)
        //    {
        //        return NbRefType.NbRefFieldName;
        //    }
        //}

        #endregion

        public const string Holder_NbRefType = "<NbRefType>";
        public const string Holder_NbRefFieldName = "<NbRefFieldName>";
        public const string Holder_NbRefFieldValue = "<NbRefFieldValue>";
        public const string Holder_NbRefFieldDesc = "<NbRefFieldDesc>";
        public const string Holder_Fileds = "<Fileds>";

        public static string ClassTemplate = @"/// <summary>
/// Strong Type extensions for <NbRefType>
/// </summary>
public static class NbRefExt_<NbRefType>
{<Fileds>
}";
        public static string FiledTemplate = @"    /// <summary>
    /// <NbRefFieldName>(<NbRefFieldValue>, <NbRefFieldDesc>)
    /// </summary>
    /// <param name=""nbRef""></param>
    /// <returns></returns>
    public static string <NbRefType>_<NbRefFieldName>(this NbRef nbRef)
    {
        return <NbRefType>.<NbRefFieldName>;
    }";

    }
}
