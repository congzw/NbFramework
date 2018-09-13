using System.Collections.Generic;

namespace NbFramework.UI.Navigations._Mocks
{
    public class MemoryNavItemRepository  : INavItemRepository
    {
        public MemoryNavItemRepository()
        {
            Items = new List<NavItem>();
            Init();
        }
        public IList<NavItem> Items { get; set; }

        public IList<NavItem> GetAll()
        {
            return Items;
        }

        private void Init()
        {
            Items.Add(new NavItem(){Pk = "Root",  ParentPk = null, Text = "Root"});
            Items.Add(new NavItem(){Pk = "Root_A",  ParentPk = "Root", Text = "A"});
            Items.Add(new NavItem(){Pk = "Root_A_1",  ParentPk = "Root_A", Text = "A_1"});
            Items.Add(new NavItem(){Pk = "Root_A_2",  ParentPk = "Root_A", Text = "A_2"});
            Items.Add(new NavItem(){Pk = "Root_B",  ParentPk = "Root", Text = "B"});
        }
    }
}
