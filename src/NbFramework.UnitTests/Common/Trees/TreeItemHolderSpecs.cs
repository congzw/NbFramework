using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NbFramework.Common.Trees
{
    [TestClass]
    public class TreeItemHolderSpecs
    {
        [TestMethod]
        public void ConvertToHolders_top_level_should_ok()
        {
            var perCount = 2;
            var maxDeep = 3;
            var mockTreeItems = MockTreeItem.Create(perCount, maxDeep);
            var treeItemHolders = TreeItemHolder<MockTreeItem>.ConvertToHolders(mockTreeItems, item => item.Id, item => item.ParentId, null);
            ShowTreeHolders(treeItemHolders);

            treeItemHolders.Count.ShouldEqual(2);
        }

        [TestMethod]
        public void MaxDeep_should_ok()
        {
            var perCount = 1;
            var maxDeep = 4;
            var mockTreeItems = MockTreeItem.Create(perCount, maxDeep);
            var treeItemHolders = TreeItemHolder<MockTreeItem>.ConvertToHolders(mockTreeItems, item => item.Id, item => item.ParentId, null);
            ShowTreeHolders(treeItemHolders);

            var treeItemHolder = treeItemHolders[0];
            treeItemHolder.MaxDeep().ShouldEqual(maxDeep);
        }

        [TestMethod]
        public void Search_should_ok()
        {
            var perCount = 2;
            var maxDeep = 3;
            var mockTreeItems = MockTreeItem.Create(perCount, maxDeep);
            var treeItemHolders = TreeItemHolder<MockTreeItem>.ConvertToHolders(mockTreeItems, item => item.Id, item => item.ParentId, null);
            ShowTreeHolders(treeItemHolders);
            var treeItemHolder = treeItemHolders[0];

            treeItemHolder.Search(item => item.Id, "NotExistId").ShouldNull("NotExistId");
            treeItemHolder.Search(item => item.Id, "1.").ShouldNotNull();
            treeItemHolder.Search(item => item.Id, "1.1.").ShouldNotNull();
            treeItemHolder.Search(item => item.Id, "1.1.1.").ShouldNotNull();
        }
        
        [TestMethod]
        public void SearchChild_should_ok()
        {
            var perCount = 2;
            var maxDeep = 3;
            var mockTreeItems = MockTreeItem.Create(perCount, maxDeep);
            var treeItemHolders = TreeItemHolder<MockTreeItem>.ConvertToHolders(mockTreeItems, item => item.Id, item => item.ParentId, null);
            ShowTreeHolders(treeItemHolders);
            var treeItemHolder = treeItemHolders[0];

            treeItemHolder.SearchChild(item => item.Id, "NotExistId", false).ShouldNull("NotExistId");
            treeItemHolder.SearchChild(item => item.Id, "1.", false).ShouldNull();
            treeItemHolder.SearchChild(item => item.Id, "1.1.", false).ShouldNotNull();
            treeItemHolder.SearchChild(item => item.Id, "1.1.1.", false).ShouldNull();
            treeItemHolder.SearchChild(item => item.Id, "1.1.", true).ShouldNotNull();
            treeItemHolder.SearchChild(item => item.Id, "1.1.1.", true).ShouldNotNull();
        }
        
        private void ShowTreeHolders(IList<TreeItemHolder<MockTreeItem>> holders)
        {
            Console.WriteLine("-- holders total count: {0} --", holders.Count);
            foreach (var holder in holders)
            {
                ShowTreeHolder(holder);
            }
        }
        private void ShowTreeHolder(TreeItemHolder<MockTreeItem> holder)
        {
            Console.WriteLine(holder.Value);
            foreach (var childHolder in holder.Children)
            {
                ShowTreeHolder(childHolder);
            }
        }
    }
}
