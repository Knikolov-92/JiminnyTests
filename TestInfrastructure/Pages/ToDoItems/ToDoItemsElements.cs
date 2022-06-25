using Jiminny.UITests.TestInfrastructure.Extensions;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace Jiminny.UITests.TestInfrastructure.Pages.ToDoItems
{
    public class ToDoItemsElements : BaseElements
    {
        private static readonly string AllItemsListLocator = "//ul[@class='todo-list']/li";

        public IWebElement ItemCounter => Driver.FindElementWithExplicitWait(By.XPath("//span[@class='todo-count']/strong"));

        public IEnumerable<IWebElement> AllItemsList => Driver.FindElements(By.XPath(AllItemsListLocator));

        public IWebElement AddToDoItemField => Driver.FindElementWithExplicitWait(By.XPath("//input[@class='new-todo']"));

        public IWebElement GetItemLabel(IWebElement parent)
        {
            return parent.FindElement(By.XPath(".//label"));
        }

        public IWebElement GetItemLabelInput(IWebElement label)
        {
            return label.FindElement(By.XPath(".//following::input[@class='edit']"));
        }
    }
}
