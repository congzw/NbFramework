using System.Collections.Generic;

namespace DemoSite.Views.Shared.Widgets.Backstretch
{
    public class BackstretchVm
    {
        public BackstretchVm()
        {
            ImgUrls = new List<string>();
            ImgUrls.Add("~/Content/images/bg/1.jpg");
            ImgUrls.Add("~/Content/images/bg/2.jpg");
            Fade = 1000;
            Duration = 5000;
        }
        public IList<string> ImgUrls { get; set; }
        public int Fade { get; set; }
        public int Duration { get; set; }
    }
}
