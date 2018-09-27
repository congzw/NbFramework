using System;
using System.ComponentModel;

namespace NbFramework.UI.DynamicPages
{
    /// <summary>
    /// 动态布局的组件
    /// </summary>
    public class DynamicWidget : IDynamicWidget
    {
        /// <summary>
        /// 指示位置
        /// </summary>
        public DynamicWidgetPosition WidgetPosition { get; set; }

        /// <summary>
        /// 部件页面
        /// </summary>
        public string WidgetPath { get; set; }

        /// <summary>
        /// WidgetVO，如果不关注，则为空即可
        /// </summary>
        public object WidgetVo { get; set; }

        /// <summary>
        /// 容器
        /// </summary>
        public IDynamicWidgetContainer Container { get; set; }

        /// <summary>
        /// 设置外层的容器
        /// </summary>
        /// <param name="outerCssClass"></param>
        /// <param name="innerCssClass"></param>
        /// <param name="containerDomId"></param>
        /// <returns></returns>
        public IDynamicWidget WithContainer(string outerCssClass, string innerCssClass, string containerDomId = null)
        {
            Container = DynamicWidgetContainer.Create(outerCssClass, innerCssClass, containerDomId);
            return this;
        }

        /// <summary>
        /// Factory
        /// </summary>
        /// <param name="widgetPath">对比DynamicPage的相对位置，或填写绝对位置（.cshtml）</param>
        /// <param name="position"></param>
        /// <param name="widgetVo"></param>
        /// <returns></returns>
        public static IDynamicWidget Create(string widgetPath, DynamicWidgetPosition position, object widgetVo = null)
        {
            if (string.IsNullOrWhiteSpace(widgetPath))
            {
                throw new ArgumentException("widgetPath不能为空");
            }

            var dynamicWidget = new DynamicWidget();
            dynamicWidget.WidgetPath = widgetPath;
            dynamicWidget.WidgetPosition = position;
            dynamicWidget.WidgetVo = widgetVo;
            return dynamicWidget;
        }
    }

    /// <summary>
    /// 组件位置
    /// </summary>
    [Description("组件位置")]
    public enum DynamicWidgetPosition
    {
        /// <summary>
        /// BeforeRenderBody
        /// </summary>
        [Description("BeforeRenderBody")]
        BeforeRenderBody = 1,
        /// <summary>
        /// 属于RenderBody
        /// </summary>
        [Description("RenderBody")]
        RenderBody = 2,
        /// <summary>
        /// AfterRenderBody
        /// </summary>
        [Description("AfterRenderBody")]
        AfterRenderBody = 3
    }
}