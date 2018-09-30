using System;
using Newtonsoft.Json;

namespace NbFramework.Common
{
    public interface ISimpleJsonHelper
    {
        object Deserialize(string json, Type type = null);
        string Serialize(object instance);
    }

    public class SimpleJsonHelper : ISimpleJsonHelper, IResolveAsSingleton
    {
        #region for di extensions

        private static Func<ISimpleJsonHelper> _resolve = () => ResolveAsSingleton.Resolve<SimpleJsonHelper, ISimpleJsonHelper>();
        public static Func<ISimpleJsonHelper> Resolve
        {
            get { return _resolve; }
            set { _resolve = value; }
        }

        #endregion
        
        public object Deserialize(string json, Type type = null)
        {
            return type != null ? JsonConvert.DeserializeObject(json, type) : JsonConvert.DeserializeObject(json);
        }

        public string Serialize(object instance)
        {
            return JsonConvert.SerializeObject(instance);
        }
    }
}
