using System;
using System.Collections.Generic;
using System.Linq;
using NbFramework.Common.Extensions;

namespace NbFramework.Common.Trees
{
    /// <summary>
    /// 树结构的容器，用于简单结构和树结构的转化
    /// </summary>
    public class TreeItemHolder<T>
    {
        /// <summary>
        /// CTOR
        /// </summary>
        public TreeItemHolder(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            Value = value;
            Children = new List<TreeItemHolder<T>>();
        }

        /// <summary>
        /// 节点值
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// 子节点
        /// </summary>
        public IList<TreeItemHolder<T>> Children { get; set; }

        /// <summary>
        /// 最大深度
        /// </summary>
        /// <param name="topDeepAs"></param>
        /// <returns></returns>
        public int MaxDeep(int topDeepAs = 1)
        {
            if (Children.IsNullOrEmpty())
            {
                return topDeepAs;
            }
            var maxChild = Children.Select(x => x.MaxDeep()).Max();
            return maxChild + 1;
        }

        /// <summary>
        /// 搜索树节点
        /// </summary>
        /// <param name="getId"></param>
        /// <param name="idToSearch"></param>
        /// <returns></returns>
        public TreeItemHolder<T> Search(Func<T, string> getId, string idToSearch)
        {
            return TreeItemHelper.Search(this, getId, idToSearch);
        }

        /// <summary>
        /// 搜索孩子节点
        /// </summary>
        /// <param name="getId"></param>
        /// <param name="idToSearch"></param>
        /// <param name="recursive"></param>
        /// <returns></returns>
        public TreeItemHolder<T> SearchChild(Func<T, string> getId, string idToSearch, bool recursive)
        {
            return TreeItemHelper.SearchChild(this, getId, idToSearch, recursive);
        }

        /// <summary>
        /// 转化数据结构为树型容器
        /// </summary>
        /// <param name="treeItems"></param>
        /// <param name="getId"></param>
        /// <param name="getParentId"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public static List<TreeItemHolder<T>> ConvertToHolders(IList<T> treeItems, Func<T, string> getId, Func<T, string> getParentId, string parentId = null)
        {
            return TreeItemHelper.ConvertToHolders(treeItems, getId, getParentId, parentId);
        }
    }
}
