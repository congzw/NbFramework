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
        /// ����Ƥ��
        /// </summary>
        public string ThemeSkin { get; set; }
        /// <summary>
        /// ������ɫ
        /// </summary>
        public string ThemeColor { get; set; }
        /// <summary>
        /// ���ַ��
        /// </summary>
        public string LayoutStyle { get; set; }
        /// <summary>
        /// �Զ����Unifyҳ����ʽ
        /// </summary>
        public string UnifyCustomCss { get; set; }

        /// <summary>
        /// ҳ�����岿�ֵ�չʾ���
        /// </summary>
        public MainContentPartStyle MainContentPartStyle { get; set; }

        private static UnifyContext defaultUnifyContext = new UnifyContext()
        {
            ThemeColor = "blue",
            ThemeSkin = "",
            LayoutStyle = ""
        };

        /// <summary>
        /// ��ȡ��ǰ������
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
    /// ҳ�����岿�ֵ�չʾ���
    /// </summary>
    public class MainContentPartStyle
    {
        /// <summary>
        /// �Ƿ���ʾ���м��һ����ҳtrue����ҳfalse
        /// </summary>
        public bool ShowBreadcrumbs { get; set; }
        /// <summary>
        /// RenderBody�Ƿ�Ƕ����div�У�һ����ҳtrue����ҳfalse
        /// </summary>
        public bool WithWrapper { get; set; }
        /// <summary>
        /// ҳ�����岿�ֵ�������ʽ��Ĭ����"container content"����WithWrapperΪtrueʱ������������
        /// </summary>
        public string WrapperCss { get; set; }
        /// <summary>
        /// ���ڿ��Ʋ˵�
        /// </summary>
        public bool WithMenu { get; set; }

        /// <summary>
        /// ��ҳģʽ��Ĭ�ϴ�Container������м��
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
        /// ��ҳģʽ��Ĭ�ϲ���Container���������м��
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
        /// ��ȡ��ǰ������
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
    //    /// ��ȡ��ǰ������
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