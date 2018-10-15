using System.Diagnostics;
using System.IO;
using System.Web.Hosting;
using NbFramework.Common.Web.CDN;
// ReSharper disable CheckNamespace

namespace System.Web.Mvc
{
    public abstract class MyWebViewPage<TModel> : WebViewPage<TModel>
    {
        private static readonly string ShowRazorPath = "ShowRazorPath";

        //for debug razor view path
        public override void ExecutePageHierarchy()
        {
            var showDebugInfo = this.Request.QueryString[ShowRazorPath] != null;
            if (showDebugInfo)
            {
                this.WriteLiteral("<!--Begin-ViewPath:" + this.VirtualPath + "-->");
            }
            base.ExecutePageHierarchy();
            if (showDebugInfo)
            {
                this.WriteLiteral("\r\n<!--End-ViewPath:" + this.VirtualPath + "-->");
            }
        }

        //fix multi themes, ects...
        public override string Layout
        {
            get
            {
                var layout = base.Layout;

                if (!string.IsNullOrEmpty(layout))
                {
                    var filename = Path.GetFileNameWithoutExtension(layout);
                    ViewEngineResult viewResult = ViewEngines.Engines.FindView(ViewContext.Controller.ControllerContext, filename, "");
                    if (viewResult.View != null && viewResult.View is RazorView)
                    {
                        layout = (viewResult.View as RazorView).ViewPath;
                    }
                }

                return layout;
            }
            set
            {
                base.Layout = value;
            }
        }

        public override string Href(string path, params object[] pathParts)
        {
            //todo switch cdn, if necessary
            Debug.WriteLine("------> path: " + path);
            return base.Href(path, pathParts);
            //todo

            #region path and pathParts

            //https://msdn.microsoft.com/zh-cn/library/system.web.webpages.helperpage.href(v=vs.111).aspx
            //The Href(String, Object[]) method combines the initial path
            //(such as the application root that is provided in the path parameter) with a list of folders, subfolders, and file names 
            //that are provided in the pathParts parameter. It returns a fully-qualified URL.
            //For example, 
            //if path parameter contains the string "~/Music" and the pathParts array contains the strings "Jazz" and "Saxophone.wav", 
            //the Href(String, Object[]) method returns the URL http://localhost/MyApp/Music/Jazz/Saxophone.wav.

            #endregion

            string cdnPath;
            var tryResolveCdnPath = CdnServer.Current.TryResolveCDNPath(path, out cdnPath);
            if (tryResolveCdnPath)
            {
                return cdnPath;
            }
            var url = base.Href(path, pathParts);
            var vpp = HostingEnvironment.VirtualPathProvider;
            if (vpp.FileExists(url)&&!url.StartsWith("/content/libs/",StringComparison.OrdinalIgnoreCase))
            {
                var hash = vpp.GetFileHash(path, new[] { path });
                url += "?" + hash;
            }
            return url;
        }
    }

    public abstract class MyWebViewPage : MyWebViewPage<dynamic>
    {
    }
}