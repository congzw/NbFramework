using System.Web.Mvc;

namespace NbCloud.Web.Areas._Demo
{
    public class _DemoAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "_Demo";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            var routeArea = "Demo";
            context.MapRoute(
                AreaName + "_default",
                routeArea + "/{controller}/{action}",
                new { area = AreaName },
                new[] { GetType().Namespace + ".Controllers" });
        }
    }
}