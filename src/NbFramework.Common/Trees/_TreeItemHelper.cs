using System;
using System.Collections.Generic;
using System.Linq;
using NbFramework.Common.Extensions;

namespace NbFramework.Common.Trees
{
    /// <summary>
    /// 内部帮助类
    /// </summary>
    internal class TreeItemHelper
    {
        internal static List<TreeItemHolder<T>> ConvertToHolders<T>(IList<T> treeItems, Func<T, string> getId, Func<T, string> getParentId, string parentId = null)
        {
            var holders = new List<TreeItemHolder<T>>();
            if (treeItems == null || !treeItems.Any())
            {
                return holders;
            }

            var topItems = treeItems.Where(x => getParentId(x).NbEquals(parentId)).ToList();
            foreach (var topItem in topItems)
            {
                var holder = ConvertToHolder(treeItems, topItem, getId, getParentId);
                holders.Add(holder);
            }
            return holders;
        }

        internal static TreeItemHolder<T> ConvertToHolder<T>(IList<T> treeItems, T currentItem, Func<T, string> getId, Func<T, string> getParentId)
        {
            var currentHolder = new TreeItemHolder<T>(currentItem);

            string currentId = getId.Invoke(currentItem);
            var childItems = treeItems.Where(x => getParentId(x).NbEquals(currentId)).ToList();
            foreach (var childItem in childItems)
            {
                var childHolder = ConvertToHolder(treeItems, childItem, getId, getParentId);
                currentHolder.Children.Add(childHolder);
            }

            return currentHolder;
        }

        internal static TreeItemHolder<T> Search<T>(TreeItemHolder<T> treeHolder, Func<T, string> getId, string idToSearch)
        {
            //如果不传入参数，搜索返回null
            if (string.IsNullOrEmpty(idToSearch))
            {
                return null;
            }

            //是否是当前的树
            var id = getId(treeHolder.Value);
            if (idToSearch.NbEquals(id))
            {
                return treeHolder;
            }

            //如果不是当前的树，递归向下查找
            if (!treeHolder.Children.IsNullOrEmpty())
            {
                return treeHolder.Children.Select(item => Search(item, getId, idToSearch))
                    .FirstOrDefault();
            }

            //没有找到
            return null;
        }
        internal static TreeItemHolder<T> SearchChild<T>(TreeItemHolder<T> treeHolder, Func<T, string> getId, string idToSearch, bool recursive)
        {
            if (string.IsNullOrEmpty(idToSearch) || treeHolder == null || treeHolder.Children.IsNullOrEmpty())
            {
                return null;
            }

            var theOne = treeHolder.Children.FirstOrDefault(item => idToSearch.NbEquals(getId(item.Value)));
            if (theOne != null)
            {
                return theOne;
            }

            if (recursive)
            {
                return treeHolder.Children.Select(childHolder => 
                    SearchChild(childHolder, getId, idToSearch, true))
                    .FirstOrDefault(theOne2 => theOne2 != null);
            }
            
            //没有找到
            return null;
        }
    }
}