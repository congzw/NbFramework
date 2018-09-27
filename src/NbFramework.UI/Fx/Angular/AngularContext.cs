namespace NbFramework.UI.Fx.Angular
{
    public class AngularContext
    {
        public string NgApp { get; set; }

        public AngularContext()
        {
            NgApp = "mainApp";
        }

        /// <summary>
        /// 获取当前上下文
        /// </summary>
        public static AngularContext Resolve()
        {
            //todo
            //Items["xxx"]
            return new AngularContext() ;
        }

        public string GetNgAppModuleJsPath()
        {
            //todo
            return null;
        }
    }
}
