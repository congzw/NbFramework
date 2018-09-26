using System;

namespace NbFramework.WebApis.Selectors.ClassifiedSelectors
{
    public class WebApiSelectorHelper
    {
        private static Func<IClassifiedHttpControllerSelectorService> _resolve = () => new ClassifiedHttpControllerSelectorService();

        public static Func<IClassifiedHttpControllerSelectorService> Resolve
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
