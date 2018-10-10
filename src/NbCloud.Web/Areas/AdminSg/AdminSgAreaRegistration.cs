using System.Web.Mvc;

namespace NbCloud.Web.Areas.AdminSg
{
    public class AdminSgAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "AdminSg";
            }
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