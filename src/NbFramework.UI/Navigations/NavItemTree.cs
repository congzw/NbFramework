using System.Collections.Generic;
using NbFramework.Common.Extensions;
using NbFramework.Common.Trees;

namespace NbFramework.UI.Navigations
{
    /// <summary>
    /// 树结构的导航
    /// </summary>
    public class NavItemTree : NavItem
    {
        public NavItemTree()
        {
            Children = new List<NavItemTree>();
        }

        public IList<NavItemTree> Children { get; set; }

        public static IList<NavItemTree> ConvertTrees(IList<NavItem> items)
        {
            var trees = new List<NavItemTree>();
            if (items.IsNullOrEmpty())
            {
                return trees;
            }

            var holders = TreeItemHolder<NavItem>.ConvertToHolders(items, item => item.Pk, item => item.ParentPk, null);
            foreach (var holder in holders)
            {
                var itemTree = holder.ConvertToTree(item => item.ToMapped<NavItemTree>(), tree => tree.Children);
                trees.Add(itemTree);
            }
            return trees;
        }
    }
}