using System;
using TestStack.White.UIItems.ListBoxItems;

namespace ExampleApplication.Model
{
    public class PersonListModel : ListBox
    {

        public PersonListModel(ListBox list)
            : base(list.AutomationElement, list.ActionListener)
        {
        }

        public bool NothingSelected
        {
            get
            {
                try
                {
                    return SelectedItem == null;
                }
                catch (NullReferenceException)
                {
                    return false;
                }
            }
        }
        public void ScrollLargeDown()
        {
            var ScrollBarsMaximum = ScrollBars.Vertical.MaximumValue;
            if (ScrollBars.CanScroll && ScrollBars.Vertical.Value != ScrollBarsMaximum)
            {
                ScrollBars.Vertical.ScrollDownLarge();
            }
        }
    }
}
