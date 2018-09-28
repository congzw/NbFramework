using System.Web;
using NbFramework.Common.Web.CDN;

namespace NbFramework.UI.Fx.Unify
{
    public class UnifyHelper
    {
        public static string GetAssetPath()
        {
            var virtualPath =  "~/Content/libs/Unify1.9";
            string result;
            CdnServer.Current.TryResolveCDNPath(virtualPath, out result);
            var absolutePath = VirtualPathUtility.ToAbsolute(result);
            return absolutePath;
        }
    }
}
