using System;
using System.Threading;
using TestStack.White;
using TestStack.White.Configuration;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.MenuItems;
using Xunit;

namespace ExampleApplication.Model.Utils
{
    public static class AutomationHelper
    {
        public const double DefaultTimeoutMs = 5000;
        public const double DefaultRetryIntervalMs = 500;

        public static T CustomGet<T>(this IUIItem item, SearchCriteria searchCriteria = null, TimeSpan? retryInterval = null, TimeSpan? timeout = null, bool throwsException = true) 
            where T : IUIItem
        {
            searchCriteria = searchCriteria ?? SearchCriteria.All;
            timeout = timeout ?? TimeSpan.FromMilliseconds(DefaultTimeoutMs);
            retryInterval = retryInterval ?? TimeSpan.FromMilliseconds(DefaultRetryIntervalMs);
            DateTime startTime = DateTime.Now;
            searchCriteria = searchCriteria.AndControlType(typeof(T), item.Framework);
            UIItemContainer container = new UIItemContainer(item.AutomationElement, item.ActionListener);
            while (true)
            {
                try
                {
                    IUIItem element = container.Get(searchCriteria, TimeSpan.Zero);
                    if (element == null)
                    {
                        throw new Exception("Null element found while getting " + searchCriteria);
                    }
                    return (T) element;
                }
                catch (AutomationException)
                {
                    TimeSpan elapsedTime = DateTime.Now.Subtract(startTime);
                    bool timeoutOccurred = elapsedTime > timeout;
                    if (timeoutOccurred)
                    {
                        break;
                    }
                    Thread.Sleep((TimeSpan) retryInterval);
                        // gives the automation time to refresh UIAutomation tree
                }
            }
            Assert.False(throwsException, $"Failed to get {searchCriteria} in {container}.");
            return default(T);
        }

        public static TProperty GetLazyProperty<TUiItem, TProperty>(this IUIItem parent, ref TProperty field, string automationId, Func<TUiItem, TProperty> create, bool isMandatory = true)
            where TUiItem : IUIItem
        {
            if (field == null)
            {
                TUiItem item = parent.CustomGet<TUiItem>(SearchCriteria.ByAutomationId(automationId), null, null, isMandatory);
                field = create(item);
            }
            return field;
        }

        public static TProperty GetLazyProperty<TProperty>(this IUIItem parent, ref TProperty field, string automationId, bool isMandatory = true)
            where TProperty : IUIItem
        {
            return GetLazyProperty(parent, ref field, automationId, (TProperty item) => item, isMandatory);
        }

        public static Menus GetChildMenus(this Menu menu)
        {
            menu.Click();
            Thread.Sleep(250);
            var childMenus = new Menus(menu.AutomationElement, menu.ActionListener);
            return childMenus;
        }


    }
}
