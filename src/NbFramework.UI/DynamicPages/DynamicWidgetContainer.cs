namespace NbFramework.UI.DynamicPages
{
    /// <summary>
    /// 动态布局的组件容器
    /// </summary>
    public class DynamicWidgetContainer : IDynamicWidgetContainer
    {
        /// <summary>
        /// 容器的DomId
        /// </summary>
        public string ContainerDomId { get; set; }

        /// <summary>
        /// 外层css样式
        /// </summary>
        public string OuterCssClass { get; set; }

        /// <summary>
        /// 内层css样式
        /// </summary>
        public string InnerCssClass { get; set; }

        /// <summary>
        /// Factory
        /// </summary>
        /// <param name="outerCssClass"></param>
        /// <param name="innerCssClass"></param>
        /// <param name="containerDomId"></param>
        /// <returns></returns>
        public static IDynamicWidgetContainer Create(string outerCssClass, string innerCssClass, string containerDomId = null)
        {
            var dynamicWidgetWidgetContainer = new DynamicWidgetContainer();
            dynamicWidgetWidgetContainer.OuterCssClass = outerCssClass;
            dynamicWidgetWidgetContainer.InnerCssClass = innerCssClass;
            dynamicWidgetWidgetContainer.ContainerDomId = containerDomId;
            return dynamicWidgetWidgetContainer;
        }
    }
}