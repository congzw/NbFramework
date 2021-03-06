﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace NbFramework.Common
{
    /// <summary>
    /// WeakType VS StrongType Convenient Helper
    /// </summary>
    public class NbRef
    {
        public static readonly NbRef Instance = new NbRef();
    }

    /// <summary>
    /// Attribute for bulid strong type string ref
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class NbRefFieldAttribute : Attribute
    {
        /// <summary>
        /// CTOR
        /// </summary>
        public NbRefFieldAttribute()
        {

        }
        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="description"></param>
        public NbRefFieldAttribute(string description)
            : this(description, null)
        {
        }
        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="description"></param>
        /// <param name="valueBag"></param>
        public NbRefFieldAttribute(string description, string valueBag)
        {
            Description = description;
            ValueBag = valueBag;
        }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 详细值
        /// </summary>
        public string ValueBag { get; set; }
    }

    /// <summary>
    /// strong type string ref value
    /// </summary>
    public class NbRefFieldValue
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string FieldName { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public string FieldValue { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 详细值
        /// </summary>
        public string ValueBag { get; set; }

        /// <summary>
        /// 反射查找并导出程序集里的注册信息
        /// </summary>
        /// <param name="assemblies"></param>
        /// <returns></returns>
        public static string ExportNbRefFieldValueInitTemplate(params Assembly[] assemblies)
        {
            #region class template

            //public class NbRefFieldValueInit
            //{
            //    /// <summary>
            //    /// NbRefFieldValue
            //    /// </summary>
            //    public static void Init()
            //    {
            //    }
            //}

            //sb.AppendLine("public class NbRefFieldValueInit");
            //sb.AppendLine("{");
            //sb.AppendLine("    /// <summary>");
            //sb.AppendLine("    /// Init NbRefFieldValue");
            //sb.AppendLine("    /// summary");
            //sb.AppendLine("    public static void Init()");
            //sb.AppendLine("{");
            //sb.AppendLine("}");

            #endregion

            StringBuilder sb = new StringBuilder();

            foreach (var assembly in assemblies)
            {
                var types = assembly.GetTypes();
                foreach (var type in types)
                {
                    AppendStaticField(type, sb);
                }
            }

            var classResult = string.Format(@"/// <summary>
/// NbRefFieldValue Init
/// </summary>
public class NbRefFieldValue
{{
    /// <summary>
    /// NbRefFieldValue Init
    /// </summary>
    public static void Init()
    {{
{0}
    }}
}}", sb.ToString().TrimEnd());
            return classResult;
        }

        private static void AppendStaticField(Type classType, StringBuilder sb)
        {
            var fieldInfos = classType.GetFields();
            bool appendTypeInfo = false;
            foreach (var fieldInfo in fieldInfos)
            {
                var customAttributes = fieldInfo.GetCustomAttributes(typeof(NbRefFieldAttribute), false);
                bool needAppendLine = customAttributes.Length > 0;
                if (needAppendLine && !appendTypeInfo)
                {
                    sb.AppendLine();
                    sb.AppendFormat("       //{0} \r\n", classType.FullName.Replace("+", "."));
                    appendTypeInfo = true;
                }
                if (needAppendLine)
                {
                    var att = (NbRefFieldAttribute)customAttributes[0];
                    var fieldValue = new NbRefFieldValue { Description = att.Description, FieldName = fieldInfo.Name };
                    var value = GetValue(fieldInfo);
                    fieldValue.FieldValue = value.ToString();
                    // IsLiteral determines if its value is written at 
                    //   compile time and not changeable
                    // IsInitOnly determine if the field can be set 
                    //   in the body of the constructor
                    // for C# a field which is readonly keyword would have both true 
                    //   but a const field would have only IsLiteral equal to true

                    if (fieldInfo.FieldType == typeof(int))
                    {
                        if (fieldInfo.IsLiteral && !fieldInfo.IsInitOnly)
                        {
                            sb.AppendFormat("       //{0}.{1} = {2}; //{3} //!const or readonly cannot set value! \r\n", classType.FullName.Replace("+", "."), fieldValue.FieldName, fieldValue.FieldValue, fieldValue.Description);
                        }
                        else
                        {
                            sb.AppendFormat("       {0}.{1} = {2}; //{3} \r\n", classType.FullName.Replace("+", "."), fieldValue.FieldName, fieldValue.FieldValue, fieldValue.Description);
                        }
                    }
                    else
                    {
                        if (fieldInfo.IsLiteral && !fieldInfo.IsInitOnly)
                        {
                            sb.AppendFormat("       //{0}.{1} = @\"{2}\"; //{3} //!const or readonly cannot set value! \r\n", classType.FullName.Replace("+", "."), fieldValue.FieldName, fieldValue.FieldValue, fieldValue.Description);
                        }
                        else
                        {
                            sb.AppendFormat("       {0}.{1} = @\"{2}\"; //{3} \r\n", classType.FullName.Replace("+", "."), fieldValue.FieldName, fieldValue.FieldValue, fieldValue.Description);
                        }
                    }
                }
            }
        }

        public static IList<NbRefFieldValue> ExportNbRefFields(params Assembly[] assemblies)
        {
            var nbRefFieldValues = new List<NbRefFieldValue>();
            foreach (var assembly in assemblies)
            {
                var types = assembly.GetTypes();
                foreach (var type in types)
                {
                    var theFieldValues = NbRefFieldValue.GetAllNbRefFieldStrings(type);
                    foreach (var theFieldValue in theFieldValues)
                    {
                        nbRefFieldValues.Add(theFieldValue);
                    }
                }
            }

            return nbRefFieldValues;
        }

        public static IList<Type> GetNbRefFieldDelcareTypes(params Assembly[] assemblies)
        {
            var theTypes = new Dictionary<Type, Type>();
            foreach (var assembly in assemblies)
            {
                var types = assembly.GetTypes();
                foreach (var type in types)
                {
                    if (theTypes.ContainsKey(type))
                    {
                        continue;
                    }

                    var fieldInfos = type.GetFields(BindingFlags.Public | BindingFlags.Static);
                    foreach (var fieldInfo in fieldInfos)
                    {
                        var customAttributes = fieldInfo.GetCustomAttributes(typeof(NbRefFieldAttribute), false);
                        if (customAttributes.Length > 0 && !theTypes.ContainsKey(type))
                        {
                            theTypes.Add(type, type);
                        }
                    }
                }
            }
            return theTypes.Values.ToList();
        }

        /// <summary>
        /// 获取某个类型声明的所有的NbRefFieldAttribute字段的信息
        /// </summary>
        /// <param name="classType"></param>
        /// <param name="includeRefAndReadOnly"></param>
        /// <returns></returns>
        public static IList<NbRefFieldValue> GetAllNbRefFieldStrings(Type classType, bool includeRefAndReadOnly = true)
        {
            var list = new List<NbRefFieldValue>();
            var fieldInfos = classType.GetFields();
            foreach (var fieldInfo in fieldInfos)
            {
                var customAttributes = fieldInfo.GetCustomAttributes(typeof(NbRefFieldAttribute), false);
                if (customAttributes.Length > 0)
                {
                    // IsLiteral determines if its value is written at 
                    //   compile time and not changeable
                    // IsInitOnly determine if the field can be set 
                    //   in the body of the constructor
                    // for C# a field which is readonly keyword would have both true 
                    //   but a const field would have only IsLiteral equal to true
                    if (!includeRefAndReadOnly)
                    {
                        if (fieldInfo.IsLiteral && !fieldInfo.IsInitOnly)
                        {
                            continue;
                        }
                    }

                    var att = (NbRefFieldAttribute)customAttributes[0];
                    var fieldValue = new NbRefFieldValue { Description = att.Description, FieldName = fieldInfo.Name, ValueBag = att.ValueBag };
                    //var value = fieldInfo.GetValue(null);
                    var value = GetValue(fieldInfo);
                    fieldValue.FieldValue = value.ToString();
                    list.Add(fieldValue);
                }
            }

            return list;
        }

        /// <summary>
        /// 获取某个类型声明的所有的Ref字段的信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IList<NbRefFieldValue> GetAllNbRefFieldStrings<T>()
        {
            var classType = typeof(T);
            return GetAllNbRefFieldStrings(classType);
        }

        /// <summary>
        /// 是否包含值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ContainsRefFiled<T>(string value)
        {
            var userTypeCodes = GetAllNbRefFieldStrings<T>()
                .Select(x => x.FieldValue).ToList();
            bool contains = userTypeCodes.Contains(value, StringComparer.OrdinalIgnoreCase);
            return contains;
        }
        //helpers
        private static object GetValue(FieldInfo fieldInfo)
        {
            object value = null;
            if (fieldInfo.IsStatic)
            {
                value = fieldInfo.GetValue(null);
                return value;
            }

            var classType = fieldInfo.DeclaringType;
            if (classType == null)
            {
                return null;
            }
            var instance = Activator.CreateInstance(classType);
            value = fieldInfo.GetValue(instance);
            return value;
        }

        #region GetRefFieldValue Expression
        
        private static readonly Dictionary<string, NbRefFieldValue> nbRefFieldValueCache = new Dictionary<string, NbRefFieldValue>();
        //not complete yet!
        public static NbRefFieldValue GetRefFieldValue(Expression<Func<object, object>> action, Type classType)
        {
            var expression = GetMemberInfo(action);
            var fieldInfo = classType.GetField(expression.Member.Name, BindingFlags.Public | BindingFlags.Static);
            if (fieldInfo == null)
            {
                throw new NotSupportedException("不支持非FieldInfo的计算！");
            }

            var key = string.Format("{0}.{1}", classType.Name, expression.Member.Name);
            if (!nbRefFieldValueCache.ContainsKey(key))
            {
                var customAttributes = fieldInfo.GetCustomAttributes(typeof(NbRefFieldAttribute), false);
                if (customAttributes.Length > 0)
                {
                    var att = (NbRefFieldAttribute)customAttributes[0];
                    var fieldValue = new NbRefFieldValue { Description = att.Description, FieldName = fieldInfo.Name, ValueBag = att.ValueBag };
                    var value = fieldInfo.GetValue(fieldInfo);
                    fieldValue.FieldValue = value.ToString();
                    nbRefFieldValueCache.Add(key, fieldValue);
                    //Console.WriteLine("cached!");
                }
            }
            return nbRefFieldValueCache[key];
        }
        private static MemberExpression GetMemberInfo(Expression method)
        {
            LambdaExpression lambda = method as LambdaExpression;
            if (lambda == null)
                throw new ArgumentNullException("method");

            MemberExpression memberExpr = null;
            if (lambda.Body.NodeType == ExpressionType.Convert)
            {
                memberExpr =
                    ((UnaryExpression)lambda.Body).Operand as MemberExpression;
            }
            else if (lambda.Body.NodeType == ExpressionType.MemberAccess)
            {
                memberExpr = lambda.Body as MemberExpression;
            }

            if (memberExpr == null)
                throw new ArgumentException("method");

            return memberExpr;
        }

        #endregion
    }
}
