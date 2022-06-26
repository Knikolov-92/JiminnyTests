using Jiminny.UITests.TestInfrastructure.Extensions;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace Jiminny.UITests.TestInfrastructure.Pages.ToDoItems
{
    public class ToDoItemsElements : BaseElements
    {
        private static readonly string ToDoListLocator = "//ul[@class='todo-list']";
        private static readonly string AllItemsListLocator = "//ul[@class='todo-list']/li";

        public IWebElement ItemCounter => Driver.FindElementWithExplicitWait(By.XPath("//span[@class='todo-count']/strong"));

        public IEnumerable<IWebElement> ToDoList => Driver.FindElements(By.XPath(ToDoListLocator));

        public IEnumerable<IWebElement> AllItemsList => Driver.FindElements(By.XPath(AllItemsListLocator));

        public IWebElement AddToDoItemField => Driver.FindElementWithExplicitWait(By.XPath("//input[@class='new-todo']"));

        public IWebElement AllListButton => Driver.FindElementWithExplicitWait(By.XPath("//a[normalize-space(text())='All']"));

        public IWebElement ActiveListButton => Driver.FindElementWithExplicitWait(By.XPath("//a[normalize-space(text())='Active']"));

        public IWebElement CompletedListButton => Driver.FindElementWithExplicitWait(By.XPath("//a[normalize-space(text())='Completed']"));

        public IWebElement ClearCompletedButton => Driver.FindElementWithExplicitWait(By.XPath("//button[@class='clear-completed']"));

        public IWebElement GetItemLabel(IWebElement parent)
        {
            return parent.FindElement(By.XPath(".//label"));
        }

        public IWebElement GetItemLabelInput(IWebElement label)
        {
            return label.FindElement(By.XPath(".//following::input[@class='edit']"));
        }

        public IWebElement GetItemCheckbox(IWebElement label)
        {
            return label.FindElement(By.XPath(".//input[@type='checkbox']"));
        }

        public string GetItemCheckboxClass(IWebElement checkbox)
        {
            return GetElementClass(checkbox);
        }

        public IWebElement GetItemDeleteButton(IWebElement label)
        {
            return label.FindElement(By.XPath(".//button[@class='destroy']"));
        }
    }
}
