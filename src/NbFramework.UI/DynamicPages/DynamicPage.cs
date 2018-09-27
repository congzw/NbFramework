using System;
using System.Collections.Generic;
using System.Linq;
using NbFramework.Common.Extensions;

namespace NbFramework.UI.DynamicPages
{
    /// <summary>
    /// 动态布局
    /// </summary>
    public class DynamicPage : IDynamicPage
    {
        /// <summary>
        /// CTOR
        /// </summary>
        public DynamicPage()
        {
            Widgets = new List<IDynamicWidget>();
        }

        /// <summary>
        /// 动态Layout的模板页面
        /// </summary>
        public string LayoutPath { get; set; }

        /// <summary>
        /// 替换Layout
        /// </summary>
        /// <param name="layoutPath"></param>
        /// <returns></returns>
        public IDynamicPage WithLayoutPath(string layoutPath)
        {
            if (layoutPath == null)
            {
                throw new ArgumentException("dynamicPagePath不能为空");
            }
            LayoutPath = layoutPath;
            return this;
        }

        /// <summary>
        /// 动态页面的路径，默认为"~/Views/Shared/_Unify/_DynamicUnifyPage.cshtml"
        /// </summary>
        public string DynamicPagePath { get; set; }

        /// <summary>
        /// 替换DynamicPagePath
        /// </summary>
        /// <param name="dynamicPagePath"></param>
        /// <returns></returns>
        public IDynamicPage WithDynamicPagePath(string dynamicPagePath)
        {
            if (dynamicPagePath == null)
            {
                throw new ArgumentException("dynamicPagePath不能为空");
            }
            DynamicPagePath = dynamicPagePath;
            return this;
        }

        /// <summary>
        /// 动态布局的组件列表
        /// </summary>
        public List<IDynamicWidget> Widgets { get; set; }
        /// <summary>
        /// 增加Widget
        /// </summary>
        /// <returns></returns>
        public IDynamicPage AddWidget(IDynamicWidget widget)
        {
            if (widget == null)
            {
                throw new ArgumentException("参数widget不能为null");
            }

            if (string.IsNullOrWhiteSpace(widget.WidgetPath))
            {
                throw new ArgumentException("参数widget.WidgetPath不能为null");
            }

            var any = Widgets.Any(x => widget.WidgetPath.NbEquals(x.WidgetPath));
            if (any)
            {
                throw new ArgumentException("不能重复添加组件:" + widget.WidgetPath);
            }

            Widgets.Add(widget);
            return this;
        }

        /// <summary>
        /// 移除Widget
        /// </summary>
        /// <param name="widgetPath"></param>
        /// <returns></returns>
        public IDynamicPage RemoveWidget(string widgetPath)
        {
            if (string.IsNullOrWhiteSpace(widgetPath))
            {
                throw new ArgumentException("参数widget.WidgetPath不能为null");
            }

            var theOne = Widgets.SingleOrDefault(x => widgetPath.NbEquals(x.WidgetPath));
            if (theOne != null)
            {
                Widgets.Remove(theOne);
            }
            return this;
        }

        /// <summary>
        /// 替换Widget
        /// </summary>
        /// <param name="widget"></param>
        /// <returns></returns>
        public IDynamicPage AddOrReplaceWidget(IDynamicWidget widget)
        {
            if (widget == null)
            {
                throw new ArgumentException("参数widget不能为null");
            }

            if (string.IsNullOrWhiteSpace(widget.WidgetPath))
            {
                throw new ArgumentException("参数widget.WidgetPath不能为null");
            }
            var fixWidgetPath = widget.WidgetPath;

            var any = Widgets.Any(x => widget.WidgetPath.NbEquals(x.WidgetPath));
            if (!any)
            {
                Widgets.Add(widget);
                return this;
            }

            int indexOfWidget = -1;
            for (var i = 0; i < Widgets.Count; i++)
            {
                var dynamicWidget = Widgets[i];
                if (fixWidgetPath.NbEquals(dynamicWidget.WidgetPath))
                {
                    indexOfWidget = i;
                    break;
                }
            }

            Widgets[indexOfWidget] = widget;
            return this;
        }

        /// <summary>
        /// Factory
        /// </summary>
        /// <param name="layoutTemplatePath"></param>
        /// <param name="dynamicPagePath"></param>
        /// <returns></returns>
        public static IDynamicPage Create(string layoutTemplatePath, string dynamicPagePath)
        {
            if (string.IsNullOrWhiteSpace(layoutTemplatePath))
            {
                throw new ArgumentException("layout路径不能为空");
            }
            if (string.IsNullOrWhiteSpace(dynamicPagePath))
            {
                throw new ArgumentException("dynamicPagePath路径不能为空");
            }
            var dynamicLayout = new DynamicPage();
            dynamicLayout.LayoutPath = layoutTemplatePath;
            dynamicLayout.DynamicPagePath = dynamicPagePath;
            return dynamicLayout;
        }

        /// <summary>
        /// Factory(Default)
        /// </summary>
        /// <returns></returns>
        public static IDynamicPage Create()
        {
            var dynamicLayout = Create("~/Views/Shared/_Unify/_DynamicUnifyLayout.cshtml", "~/Views/Shared/_Unify/_DynamicUnifyPage.cshtml");
            return dynamicLayout;
        }
    }
}