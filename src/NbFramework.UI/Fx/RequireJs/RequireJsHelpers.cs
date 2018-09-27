using System;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace NbFramework.UI.Fx.RequireJs
{
    public static class RequireJsHelpers
    {
        public static MvcHtmlString InitPageMainModule(this HtmlHelper helper, string pageModule)
        {
            var requireScript = new StringBuilder();

            var scriptsPath = "~/Scripts/";
            var absolutePath = VirtualPathUtility.ToAbsolute(scriptsPath);

            requireScript.AppendLine("<script>");
            requireScript.AppendFormat("    require([\"{0}main.js\"]," + Environment.NewLine, absolutePath);
            requireScript.AppendLine("        function() {");
            requireScript.AppendFormat("            require([\"{0}\", \"domReady!\"]);" + Environment.NewLine, pageModule);
            requireScript.AppendLine("        }");
            requireScript.AppendLine("    );");
            requireScript.AppendLine("</script>");

            return new MvcHtmlString(requireScript.ToString());
        }
    }
}
