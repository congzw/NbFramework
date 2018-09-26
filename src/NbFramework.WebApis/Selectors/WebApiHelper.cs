using System;

namespace NbFramework.WebApis.Selectors
{
    public class WebApiSelectorHelper
    {
        private static Func<INamespaceApiControllerSelector> _resolve = () => new NamespaceApiControllerSelector();

        public static Func<INamespaceApiControllerSelector> Resolve
        {
            get { return _resolve; }
            set { _resolve = value; }
        }

        public static void Debug(string message)
        {
            //todo
        }

        public static void Error(string format, Exception exception)
        {
            //todo
        }
    }
}
