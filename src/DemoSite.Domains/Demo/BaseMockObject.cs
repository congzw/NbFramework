using System;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using NbFramework.Common.Extensions;

namespace DemoSite.Domains.Demo
{
    public abstract class BaseMockObject : IDisposable
    {
        public bool WasDisposed { get; set; }

        protected BaseMockObject()
        {
            var type = this.GetType();
            var message = string.Format("<< create: {0} {1}", type.Name, this.GetHashCode());
            //Console.WriteLine(message);
            Debug.WriteLine(message);
        }

        public void Dispose()
        {
            // clean up
            var type = this.GetType();
            var message = string.Format("             dispose {0}: {1} >> ", type.Name, this.GetHashCode());
            //Console.WriteLine(message);
            Debug.WriteLine(message);
            WasDisposed = true;
        }

        public override string ToString()
        {
            return this.ToDebugInfo();
        }
    }

    public static class ObjectDebugExtensions
    {
        public static string ToDebugInfo(this object value, Type objectType = null)
        {
            if (value == null)
            {
                return string.Format("<< {0} : NULL >>", objectType == null ? string.Empty : objectType.Name);
            }
            
            var t = objectType ?? value.GetType();

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<< {0}: {1}", t.GetFriendlyName(), value.GetHashCode());

            int append = 0;
            var propertyInfos = t.GetProperties();
            foreach (var propertyInfo in propertyInfos)
            {
                var propType = propertyInfo.PropertyType;
                var isSimpleType = IsSimpleType(propType);
                if (isSimpleType && propType.Name != "Tenant")
                {
                    continue;
                }

                sb.AppendLine();
                append++;
                object propValue = propertyInfo.GetValue(value, null);
                if (propValue == null)
                {
                    sb.AppendFormat("{0}<< {1} : NULL >>", Tabs(append), propType.GetFriendlyName());
                }
                else
                {
                    sb.AppendFormat("{0} {1}", Tabs(append), propValue);
                }
            }

            if (append > 0)
            {
                sb.AppendLine();
            }

            var result = sb.ToString();
            return result;
        }

        private static bool IsSimpleType(Type type)
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

        private static string Tabs(int n)
        {
            if (n <= 0)
            {
                return string.Empty;
            }
            return new String('\t', n);
        }
    }
}
