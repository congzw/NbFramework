using System;
using System.Collections.Generic;

namespace NbFramework.Common
{
    public interface INbRegistry
    {
        object GetProperty(string name, object defaultValue = null);
        void SetProperty(string name, object value);
    }

    public class NbRegistry : Dictionary<string, object>, INbRegistry
    {
        public static INbRegistry Instance = new NbRegistry();

        public object GetProperty(string name, object defaultValue = null)
        {
            var key = CreateKey(name);
            if (!ContainsKey(key))
            {
                return defaultValue;
            }
            return this[key];
        }

        public void SetProperty(string name, object value)
        {
            var key = CreateKey(name);
            this[key] = value;
        }

        private static string CreateKey(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("name should not be empty or null");
            }
            return name.Trim().ToLower();
        }
    }

    public static class NbRegistryExtensions
    {
        public static T GetProperty<T>(this INbRegistry nbRegistry, string name, T defaultValue = default(T))
        {
            return (T)nbRegistry.GetProperty(name);
        }

        public static void SetProperty<T>(this INbRegistry nbRegistry, string name, T value)
        {
            nbRegistry.SetProperty(name, value);
        }
    }
}
