﻿using System.Collections.Generic;
using NbFramework.Common.Extensions;

namespace NbFramework.Common.Trees
{
    public class MockTreeItem
    {
        public string Id { get; set; }
        public string ParentId { get; set; }
        public string Name { get; set; }
        
        public override string ToString()
        {
            return string.Format("{0}, Parent:{1}, Deep:{2}", Id, string.IsNullOrWhiteSpace(ParentId) ? "NULL" : ParentId, Id.Split('.').Length - 1);
        }

        public static IList<MockTreeItem> Create(int nodeCountPerDeep, int deep)
        {
            var items = new List<MockTreeItem>();
            AppendNode(items, nodeCountPerDeep, "", deep);
            return items;
        }

        private static void AppendNode(IList<MockTreeItem> items, int nodeCountPerDeep, string parentId, int deep)
        {
            if (deep == 0)
            {
                return;
            }

            var isTop = string.IsNullOrWhiteSpace(parentId);
            for (int i = 0; i < nodeCountPerDeep; i++)
            {
                var item = new MockTreeItem();
                item.Id = isTop ? string.Format("{0}.", i + 1) : string.Format("{0}{1}.", parentId, i + 1);
                item.Name = "标题" + item.Id;
                item.ParentId = parentId;
                items.Add(item);

                AppendNode(items, nodeCountPerDeep, item.Id, deep - 1);
            }
        }
    }
    
    public class MockTreeItemTree : MockTreeItem
    {
        public MockTreeItemTree()
        {
            Children = new List<MockTreeItemTree>();
        }

        public IList<MockTreeItemTree> Children { get; set; }

        public static IList<MockTreeItemTree> ConvertTrees(IList<MockTreeItem> items)
        {
            var trees = new List<MockTreeItemTree>();
            if (items.IsNullOrEmpty())
            {
                return trees;
            }

            var holders = TreeItemHolder<MockTreeItem>.ConvertToHolders(items, item => item.Id, item => item.ParentId, null);
            foreach (var holder in holders)
            {
                var itemTree = holder.ConvertToTree(item => item.ToMapped<MockTreeItemTree>(), tree => tree.Children);
                trees.Add(itemTree);
            }
            return trees;
        }
    }
}
