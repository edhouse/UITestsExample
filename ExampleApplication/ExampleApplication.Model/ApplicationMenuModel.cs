using TestStack.White.UIItems.MenuItems;
using TestStack.White.UIItems;
using ExampleApplication.Resources.AutomationIdentifiers;

namespace ExampleApplication.Model
{
    public class ApplicationMenuModel : Menus
    {

        public ApplicationMenuModel(UIItem menu)
            : base(menu.AutomationElement, menu.ActionListener)
        {
        }


        private Menu items;

        public Menu Items
        {
            get
            {
                if (items == null)
                {
                    items = Find(MainWindowIds.ItemsMenu);
                }
                return items;
            }
        }

        private Menu edit;

        public Menu Edit
        {
            get
            {
                if (edit == null)
                {
                    edit = Find(MainWindowIds.EditMenu);
                }
                return edit;
            }
        }
    }
}
