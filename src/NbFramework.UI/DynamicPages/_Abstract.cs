using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbFramework.UI.DynamicPages
{
    /// <summary>
    /// 动态布局
    /// </summary>
    public interface IDynamicPage
    {
        /// <summary>
        /// layout路径，默认为"~/Views/Shared/_Unify/_DynamicUnifyLayout.cshtml"
        /// </summary>
        string LayoutPath { get; set; }
        /// <summary>
        /// 替换Layout
        /// </summary>
        /// <param name="layoutPath"></param>
        /// <returns></returns>
        IDynamicPage WithLayoutPath(string layoutPath);

        /// <summary>
        /// 动态页面的路径，默认为"~/Views/Shared/_Unify/_DynamicUnifyPage.cshtml"
        /// </summary>
        string DynamicPagePath { get; set; }
        /// <summary>
        /// 替换DynamicPagePath
        /// </summary>
        /// <param name="dynamicPagePath"></param>
        /// <returns></returns>
        IDynamicPage WithDynamicPagePath(string dynamicPagePath);


        /// <summary>
        /// 动态布局的组件列表
        /// </summary>
        List<IDynamicWidget> Widgets { get; set; }
        /// <summary>
        /// 增加Widget
        /// </summary>
        /// <returns></returns>
        IDynamicPage AddWidget(IDynamicWidget widget);
        /// <summary>
        /// 移除Widget
        /// </summary>
        /// <param name="widgetPath"></param>
        /// <returns></returns>
        IDynamicPage RemoveWidget(string widgetPath);
        /// <summary>
        /// 有则替换，无则添加Widget
        /// </summary>
        /// <param name="widget"></param>
        /// <returns></returns>
        IDynamicPage AddOrReplaceWidget(IDynamicWidget widget);
    }

    /// <summary>
    /// 动态布局的组件
    /// </summary>
    public interface IDynamicWidget
    {
        /// <summary>
        /// 指示位置
        /// </summary>
        DynamicWidgetPosition WidgetPosition { get; set; }

        /// <summary>
        /// 部件页面
        /// </summary>
        string WidgetPath { get; set; }
        /// <summary>
        /// WidgetVO，如果不关注，则为空即可
        /// </summary>
        object WidgetVo { get; set; }

        /// <summary>
        /// 容器
        /// </summary>
        IDynamicWidgetContainer Container { get; set; }

        /// <summary>
        /// 设置外层的容器
        /// </summary>
        /// <param name="outerCssClass"></param>
        /// <param name="innerCssClass"></param>
        /// <param name="containerDomId"></param>
        /// <returns></returns>
        IDynamicWidget WithContainer(string outerCssClass, string innerCssClass, string containerDomId = null);
    }

    /// <summary>
    /// 动态布局的组件容器
    /// </summary>
    public interface IDynamicWidgetContainer
    {
        /// <summary>
        /// 容器的DomId
        /// </summary>
        string ContainerDomId { get; set; }
        /// <summary>
        /// 外层css样式
        /// </summary>
        string OuterCssClass { get; set; }
        /// <summary>
        /// 内层css样式
        /// </summary>
        string InnerCssClass { get; set; }
    }
}
