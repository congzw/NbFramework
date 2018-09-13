using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using NbFramework.Common.Extensions;

namespace NbFramework.Common
{
    /*模型的帮助类*/

    public class MyModelHelper
    {
        private static IList<Type> _notProcessPerpertyBaseTypes = new List<Type>()
        {
            typeof (DynamicObject),
            typeof (Object),
            //typeof (BaseViewModel),
            //typeof (BaseViewModel<>),
            //typeof (Expando)
        };

        /// <summary>
        /// 在这些类型中声明的属性不处理
        /// </summary>
        public static IList<Type> NotProcessPerpertyBaseTypes
        {
            get { return _notProcessPerpertyBaseTypes; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                _notProcessPerpertyBaseTypes = value;
            }
        }

        public static IEnumerable<T> TryCopySimpleItems<T>(IEnumerable<T> copyFrom, string[] excludeProperties = null)
        {
            var enumerable = copyFrom as IEnumerable;
            if (enumerable != null)
            {
                return FixEnumerableWithDeepCopy(enumerable) as IEnumerable<T>;
            }
            return Enumerable.Empty<T>();
        }

        public static void TryCopyProperties(Object updatingObj, Object collectedObj, string[] excludeProperties = null)
        {
            if (collectedObj != null && updatingObj != null)
            {
                //获取类型信息
                Type updatingObjType = updatingObj.GetType();
                PropertyInfo[] updatingObjPropertyInfos = updatingObjType.GetProperties();

                Type collectedObjType = collectedObj.GetType();
                PropertyInfo[] collectedObjPropertyInfos = collectedObjType.GetProperties();

                string[] fixedExPropertites = excludeProperties ?? new string[] { };

                foreach (PropertyInfo updatingObjPropertyInfo in updatingObjPropertyInfos)
                {
                    foreach (PropertyInfo collectedObjPropertyInfo in collectedObjPropertyInfos)
                    {
                        if (updatingObjPropertyInfo.Name == collectedObjPropertyInfo.Name)
                        {
                            if (fixedExPropertites.Contains(updatingObjPropertyInfo.Name,
                                StringComparer.OrdinalIgnoreCase))
                            {
                                continue;
                            }

                            //do not process complex property
                            var isSimpleType = IsSimpleType(collectedObjPropertyInfo.PropertyType);
                            if (!isSimpleType)
                            {
                                continue;
                            }

                            //fix dynamic problems: System.Reflection.TargetParameterCountException
                            var declaringType = collectedObjPropertyInfo.DeclaringType;
                            if (declaringType != null && declaringType != collectedObjType)
                            {
                                //do not process base class dynamic property
                                if (NotProcessPerpertyBaseTypes.Contains(declaringType))
                                {
                                    continue;
                                }
                            }

                            object value = collectedObjPropertyInfo.GetValue(collectedObj, null);
                            if (updatingObjPropertyInfo.CanWrite)
                            {
                                //do not process read only property
                                updatingObjPropertyInfo.SetValue(updatingObj, value, null);
                            }
                            break;
                        }
                    }
                }
            }
        }

        public static void SetProperties<T>(T theObjToBeUpdated, T readFromValueObj, string[] excludeProperties = null)
            where T : class
        {
            if (theObjToBeUpdated == null)
            {
                throw new ArgumentNullException("theObjToBeUpdated");
            }
            if (readFromValueObj == null)
            {
                throw new ArgumentNullException("readFromValueObj");
            }

            //获取类型信息
            Type t = theObjToBeUpdated.GetType();
            PropertyInfo[] propertyInfos = t.GetProperties();
            string[] fixedExPropertites = excludeProperties ?? new string[] { };

            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                if (fixedExPropertites.Contains(propertyInfo.Name, StringComparer.OrdinalIgnoreCase))
                {
                    continue;
                }
                object value = propertyInfo.GetValue(readFromValueObj, null);
                propertyInfo.SetValue(theObjToBeUpdated, value, null);
            }

        }

        public static bool SetProperty<T>(T obj, string key, object value)
        {
            bool reslut = false;
            if (obj != null && !string.IsNullOrEmpty(key) && value != null)
            {
                //获取类型信息
                Type t = typeof(T);
                PropertyInfo[] propertyInfos = t.GetProperties();

                foreach (PropertyInfo var in propertyInfos)
                {
                    if (var.Name.Equals(key, StringComparison.InvariantCultureIgnoreCase))
                    {
                        var.SetValue(obj, value, null);
                        reslut = true;
                        break;
                    }
                }
            }
            return reslut;
        }

        /// <summary>
        /// 查找泛型T的属性
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object GetProperty<T>(T obj, string key)
        {
            object result = null;
            if (obj != null && !string.IsNullOrEmpty(key))
            {
                //获取类型信息
                Type t = typeof(T);
                PropertyInfo[] propertyInfos = t.GetProperties();

                foreach (PropertyInfo var in propertyInfos)
                {
                    if (var.Name.Equals(key, StringComparison.OrdinalIgnoreCase))
                    {
                        object value = var.GetValue(obj, null);
                        result = value;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 查找obj的所有属性
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object GetProperty(Object obj, string key)
        {
            object result = null;
            if (obj != null && !string.IsNullOrEmpty(key))
            {
                //获取类型信息
                Type t = obj.GetType();
                PropertyInfo[] propertyInfos = t.GetProperties();

                foreach (PropertyInfo var in propertyInfos)
                {
                    if (var.Name.Equals(key, StringComparison.OrdinalIgnoreCase))
                    {
                        object value = var.GetValue(obj, null);
                        result = value;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 获取所有的Property名称(修正自动扩展的两个属性"Infoset", "Data")
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<string> GetKeys<T>()
        {
            //修正自动扩展的两个属性
            string[] excludePropertyNames = new[] { "Infoset", "Data" };
            return GetKeys<T>(excludePropertyNames);
        }

        /// <summary>
        /// 获取所有的Property名称
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="excludePropertyNames"></param>
        /// <returns></returns>
        public static List<string> GetKeys<T>(string[] excludePropertyNames)
        {
            List<string> result = new List<string>();
            //获取类型信息
            Type t = typeof(T);
            PropertyInfo[] propertyInfos = t.GetProperties();

            var excludePropertyNamesFix = new List<string>();
            if (excludePropertyNames != null && excludePropertyNames.Length > 0)
            {
                excludePropertyNamesFix = excludePropertyNames.ToList();
            }

            foreach (PropertyInfo var in propertyInfos)
            {
                if (excludePropertyNamesFix.Contains(var.Name, StringComparer.OrdinalIgnoreCase))
                {
                    continue;
                }
                result.Add(var.Name);
            }
            return result;
        }

        public static Dictionary<string, object> GetKeyValueDictionary<T>(T obj)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            if (obj != null)
            {
                //获取类型信息
                Type t = typeof(T);
                PropertyInfo[] propertyInfos = t.GetProperties();

                foreach (PropertyInfo var in propertyInfos)
                {
                    result.Add(var.Name, var.GetValue(obj, null));
                }
            }
            return result;
        }

        public static bool SetKeyValueDictionary<T>(T obj, Dictionary<string, object> dic)
        {
            bool reslut = false;
            if (obj != null && dic != null)
            {
                //获取类型信息
                Type t = typeof(T);
                PropertyInfo[] propertyInfos = t.GetProperties();
                foreach (PropertyInfo var in propertyInfos)
                {
                    foreach (var key in dic.Keys)
                    {
                        if (var.Name.Equals(key, StringComparison.InvariantCultureIgnoreCase))
                        {
                            object value = null;
                            bool temp = dic.TryGetValue(key, out value);
                            if (temp)
                            {
                                var.SetValue(obj, value, null);
                                break;
                            }
                        }
                    }
                }
            }
            return reslut;
        }

        public static void ResetAllStringEmpty<T>(T obj)
        {
            if (obj != null)
            {
                //获取类型信息
                Type t = typeof(T);
                PropertyInfo[] propertyInfos = t.GetProperties();
                foreach (PropertyInfo var in propertyInfos)
                {
                    object value = var.GetValue(obj, null);
                    if (value == null && var.PropertyType.Name == string.Empty.GetType().Name)
                    {
                        var.SetValue(obj, string.Empty, null);
                    }
                }
            }
        }

        //包括string和datetime
        public static void ResetAllDateDefault<T>(T obj, DateTime defaultDate)
        {
            if (obj != null)
            {
                //获取类型信息
                Type t = typeof(T);
                PropertyInfo[] propertyInfos = t.GetProperties();
                foreach (PropertyInfo var in propertyInfos)
                {
                    object value = var.GetValue(obj, null);
                    if (var.PropertyType.Name == DateTime.Now.GetType().Name)
                    {
                        var.SetValue(obj, defaultDate, null);
                    }
                }
            }
        }

        public static List<string> GetPublicMethods<T>()
        {
            List<string> result = new List<string>();
            //获取类型信息
            Type t = typeof(T);
            MethodInfo[] infos = t.GetMethods();

            foreach (MethodInfo var in infos)
            {
                result.Add(var.Name);
            }

            result.Remove("ToString");
            result.Remove("Equals");
            result.Remove("GetHashCode");
            result.Remove("GetType");
            return result;
        }

        public static string MakeIniString(Object obj, bool removeLastlastSplit = true)
        {
            string temp = MakeIniStringExt(obj, removeLastlastSplit: true);
            return temp;
        }

        public static string MakeIniStringExt(Object obj, string equalOperator = "=", string lastSplit = ";",
            bool removeLastlastSplit = true)
        {
            string schema = string.Format("{0}{1}{2}{3}", "{0}", equalOperator, "{1}", lastSplit);
            StringBuilder sb = new StringBuilder();
            if (obj != null)
            {
                //获取类型信息
                Type t = obj.GetType();
                PropertyInfo[] propertyInfos = t.GetProperties();
                foreach (PropertyInfo var in propertyInfos)
                {
                    object value = var.GetValue(obj, null);
                    string temp = "";

                    //如果是string，并且为null
                    if (value == null)
                    {
                        temp = "";
                    }
                    else
                    {
                        temp = value.ToString();
                    }

                    value = temp.ReplaceString(new[] { lastSplit, "=" });
                    sb.AppendFormat(schema, var.Name, value);
                }
            }
            //去掉最后的分号
            if (removeLastlastSplit)
            {
                string result = sb.ToString();
                return result.Substring(0, result.Length - 1);
            }
            else
            {
                return sb.ToString();
            }
        }

        //Model object => object[] args
        //Model class  => string args
        public static object[] MakeArgs<T>(T obj)
        {
            Dictionary<string, object> dic = GetKeyValueDictionary<T>(obj);
            object[] result = dic.Values.ToArray();
            return result;
        }

        public static string MakeSpArgs<T>()
        {
            StringBuilder sb = new StringBuilder();
            List<string> propList = GetKeys<T>();
            if (propList.Count == 0)
            {
                return "";
            }

            int length = propList.Count;
            for (int i = 0; i < length - 1; i++)
            {
                sb.Append(propList[i]);
                sb.Append(",");
                sb.AppendLine();
            }

            sb.Append(propList[length - 1]);
            return sb.ToString();
        }

        public static List<T> Where<T>(IEnumerable<T> enumerable, Func<T, bool> predicate)
        {
            List<T> result = new List<T>();
            if (enumerable == null)
            {
                return result;
            }
            IEnumerable<T> temp = enumerable.Where(predicate);
            if (temp != null)
            {
                result = temp.ToList();
            }

            return result;
        }

        public static string[] MakeIdArrays<T>(IEnumerable<T> enumerable, Func<T, string> getId)
        {
            List<T> result = new List<T>();
            if (enumerable == null)
            {
                return new string[] { };
            }

            List<string> temp = new List<string>();
            foreach (var item in enumerable)
            {
                string id = getId.Invoke(item);
                temp.Add(id);
            }
            return temp.ToArray();
        }

        public static void LookupProperties(Object obj, StringBuilder sb)
        {
            if (obj != null && sb != null)
            {
                //获取类型信息
                Type collectedObjType = obj.GetType();
                PropertyInfo[] collectedObjPropertyInfos = collectedObjType.GetProperties();
                foreach (PropertyInfo collectedObjPropertyInfo in collectedObjPropertyInfos)
                {
                    object value = collectedObjPropertyInfo.GetValue(obj, null);
                    sb.AppendFormat("{0}={1};", collectedObjPropertyInfo.Name, value);
                }
            }
        }

        /// <summary>
        /// 是否是简单类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsSimpleType(Type type)
        {
            var typeInfo = type.GetTypeInfo();
            if (typeInfo.IsGenericType && typeInfo.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                // nullable type, check if the nested type is simple.
                return IsSimpleType(typeInfo.GetGenericArguments()[0]);
            }
            return typeInfo.IsPrimitive
                   || typeInfo.IsEnum
                   || type == typeof(string)
                   || type == typeof(decimal)
                //|| type == typeof(Guid)
                //|| type == typeof(DateTime)
                   || type.IsSubclassOf(typeof(ValueType)); //Guid, Datetime, etc...
        }

        private static IEnumerable FixEnumerableWithDeepCopy(IEnumerable arraySource)
        {
            using (var ms = new MemoryStream())
            {
                var bf = new BinaryFormatter { Context = new StreamingContext(StreamingContextStates.Clone) };
                bf.Serialize(ms, arraySource);
                ms.Position = 0;
                return bf.Deserialize(ms) as IEnumerable;
            }
        }

        #region FixStringProperties

        /// <summary>
        /// 修复字符串字段
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="nullOrEmptyReplacement">如果为空，用此替换</param>
        /// <param name="autoTrim">自动去除头尾的空</param>
        /// <param name="excludeProperties"></param>
        public static void TryFixStringProperties(Object obj, string nullOrEmptyReplacement, bool autoTrim = true, string[] excludeProperties = null)
        {
            if (obj == null)
            {
                return;
            }

            string[] fixedExPropertites = excludeProperties ?? new string[] { };

            //获取类型信息
            Type objType = obj.GetType();
            PropertyInfo[] properties = objType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo p in properties)
            {
                // Only work with strings
                if (p.PropertyType != typeof(string))
                {
                    continue;
                }

                // If not writable then cannot null it; if not readable then cannot check it's value
                if (!p.CanWrite || !p.CanRead)
                {
                    continue;
                }

                if (fixedExPropertites.Contains(p.Name, StringComparer.OrdinalIgnoreCase))
                {
                    continue;
                }

                MethodInfo mget = p.GetGetMethod(false);
                MethodInfo mset = p.GetSetMethod(false);
                // Get and set methods have to be public
                if (mget == null)
                {
                    continue;
                }
                if (mset == null)
                {
                    continue;
                }

                var originalValue = (string)p.GetValue(obj, null);
                if (string.IsNullOrWhiteSpace(originalValue))
                {
                    p.SetValue(obj, nullOrEmptyReplacement, null);
                }
                else
                {
                    if (autoTrim)
                    {
                        var trimValue = originalValue.Trim();
                        if (trimValue != originalValue)
                        {
                            p.SetValue(obj, originalValue.Trim());
                        }
                    }
                }
            }
        }

        #endregion

        #region TryConvertDateAndTime

        /// <summary>
        /// 转化日期和时间
        /// </summary>
        /// <param name="date"></param>
        /// <param name="timeOfDay"></param>
        /// <returns></returns>
        public static MessageResult TryConvertDateAndTime(string date, string timeOfDay)
        {
            if (date != null)
            {
                date = date.Trim();
            }

            if (timeOfDay != null)
            {
                timeOfDay = timeOfDay.Trim();
            }

            var messageResult = new MessageResult();

            DateTime theDate;
            var tryParseDate = DateTime.TryParse(date, out theDate);
            if (!tryParseDate)
            {
                messageResult.Message = string.Format("无效日期:{0}", date);
                return messageResult;
            }

            DateTime theTime;
            var tryParseTime = DateTime.TryParse(timeOfDay, out theTime);
            if (!tryParseTime)
            {
                messageResult.Message = string.Format("无效时间:{0}", timeOfDay);
                return messageResult;
            }

            messageResult.Success = true;
            messageResult.Message = "OK";
            messageResult.Data = theDate.Date.AddTicks(theTime.TimeOfDay.Ticks);
            return messageResult;
        }

        /// <summary>
        /// 转化日期
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static MessageResult TryConvertDatetime(string datetime)
        {
            if (datetime != null)
            {
                datetime = datetime.Trim();
            }
            
            var messageResult = new MessageResult();

            if (string.IsNullOrWhiteSpace(datetime))
            {
                messageResult.Message = "时间不能为空";
                return messageResult; 
            }

            DateTime theDate;
            var tryParseDate = DateTime.TryParse(datetime, out theDate);
            if (!tryParseDate)
            {
                messageResult.Message = string.Format("无效时间:{0}", datetime);
                return messageResult;
            }

            messageResult.Success = true;
            messageResult.Message = "OK";
            messageResult.Data = theDate;
            return messageResult;
        }



        #endregion
    }
}
