using NbFramework.Common.Ioc;

namespace NbFramework.UI.Fx.Unify
{
    /// <summary>
    /// UnifyContext
    /// </summary>
    public class UnifyContext
    {
        /// <summary>
        /// CTOR
        /// </summary>
        public UnifyContext()
        {
            MainContentPartStyle = MainContentPartStyle.CreateForPage();
        }

        /// <summary>
        /// 主题皮肤
        /// </summary>
        public string ThemeSkin { get; set; }
        /// <summary>
        /// 主题颜色
        /// </summary>
        public string ThemeColor { get; set; }
        /// <summary>
        /// 布局风格
        /// </summary>
        public string LayoutStyle { get; set; }
        /// <summary>
        /// 自定义的Unify页面样式
        /// </summary>
        public string UnifyCustomCss { get; set; }

        /// <summary>
        /// 页面主体部分的展示风格
        /// </summary>
        public MainContentPartStyle MainContentPartStyle { get; set; }

        private static UnifyContext defaultUnifyContext = new UnifyContext()
        {
            ThemeColor = "blue",
            ThemeSkin = "",
            LayoutStyle = ""
        };

        /// <summary>
        /// 获取当前上下文
        /// </summary>
        public static UnifyContext Current
        {
            get
            {
                var provider = CoreServiceProvider.LocateService<IUnifyContextProvider>();
                if (provider == null)
                {
                    return defaultUnifyContext;
                }
                var context = provider.GetCurrent();
                if (context == null)
                {
                    return defaultUnifyContext;
                }
                return context;
            }
        }
    }

    /// <summary>
    /// 页面主体部分的展示风格
    /// </summary>
    public class MainContentPartStyle
    {
        /// <summary>
        /// 是否显示面表屑，一般内页true，首页false
        /// </summary>
        public bool ShowBreadcrumbs { get; set; }
        /// <summary>
        /// RenderBody是否嵌套在div中，一般内页true，首页false
        /// </summary>
        public bool WithWrapper { get; set; }
        /// <summary>
        /// 页面主体部分的容器样式，默认是"container content"，当WithWrapper为true时，被赋予容器
        /// </summary>
        public string WrapperCss { get; set; }
        /// <summary>
        /// 用于控制菜单
        /// </summary>
        public bool WithMenu { get; set; }

        /// <summary>
        /// 内页模式（默认带Container，带包屑）
        /// </summary>
        public static MainContentPartStyle CreateForPage()
        {
            var style = new MainContentPartStyle();
            style.ShowBreadcrumbs = true;
            style.WithWrapper = true;
            style.WrapperCss = "container content";
            return style;
        }

        /// <summary>
        /// 首页模式（默认不带Container，不带面包屑）
        /// </summary>
        public static MainContentPartStyle CreateForIndex()
        {
            var style = new MainContentPartStyle();
            style.ShowBreadcrumbs = false;
            style.WithWrapper = false;
            style.WrapperCss = "container content";
            return style;
        }
    }


    /// <summary>
    /// UnifyContextProvider
    /// </summary>
    public interface IUnifyContextProvider
    {
        /// <summary>
        /// 获取当前上下文
        /// </summary>
        /// <returns></returns>
        UnifyContext GetCurrent();
    }

    //todo
    ///// <summary>
    ///// UnifyContextProvider
    ///// </summary>
    //public class UnifyContextProvider : IUnifyContextProvider
    //{
    //    /// <summary>
    //    /// 获取当前上下文
    //    /// </summary>
    //    /// <returns></returns>
    //    public UnifyContext GetCurrent()
    //    {
    //        var nbRequestContext = NbRequestContext.Current;
    //        if (nbRequestContext == null)
    //        {
    //            return new UnifyContext()
    //            {
    //                ThemeColor = "blue",
    //                ThemeSkin = "",
    //                LayoutStyle = ""
    //            };
    //        }

    //        var siteAreaSettingHelper = CoreServiceProvider.LocateService<ISiteAreaSettingService>();
    //        var unifySkin = siteAreaSettingHelper.GetBySiteUrlName<UnifySkin>(nbRequestContext.Site, string.IsNullOrWhiteSpace(nbRequestContext.Area) ? "*" : nbRequestContext.Area);

    //        var perRequestCacheManager = new PerRequestCacheManager(new HttpContextWrapper(HttpContext.Current));
    //        var cacheHelper = new CacheHelper();
    //        var makeCacheKey = cacheHelper.MakeCacheKey<UnifyContext>();
    //        var unifyContext = perRequestCacheManager.Get<UnifyContext>(makeCacheKey);
    //        if (unifyContext == null)
    //        {
    //            unifyContext = new UnifyContext()
    //            {
    //                ThemeColor = unifySkin.SkinColor,
    //                ThemeSkin = unifySkin.SkinColor,
    //                LayoutStyle = unifySkin.SkinLayout
    //            };
    //            perRequestCacheManager.Set(makeCacheKey, unifyContext);
    //        }

    //        unifyContext.ThemeColor = unifySkin.SkinColor;
    //        unifyContext.ThemeSkin = ""; //todo
    //        unifyContext.LayoutStyle = unifySkin.SkinLayout;
    //        return unifyContext;
    //    }
    //}
}