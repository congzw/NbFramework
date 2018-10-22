using System.Web.Mvc;

namespace NbCloud.Web.Areas.Auth
{
    public class AuthAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get { return "Auth"; }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                AreaName + "_default",
                AreaName + "/{controller}/{action}",
                new { area = AreaName },
                new[] { GetType().Namespace + ".Controllers" });
        }
    }
}