using Jiminny.UITests.TestInfrastructure.Helpers;
using Jiminny.UITests.TestInfrastructure.Models;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace Jiminny.UITests.TestInfrastructure.Pages.ToDoItems
{
    public class ToDoItemsFacade : BaseFacade<ToDoItemsElements, ToDoItemsValidator>
    {
        public ToDoItemsFacade() : base(){}

        public void AddItemsToTheToDoList(List<ToDoItem> listOfItems)
        {
            var input = WebElementUtility.WaitForElementToBeDisplayed(() => Elements.AddToDoItemField);

            foreach (var item in listOfItems)
            {
                EnterTextInField(() => Elements.AddToDoItemField, item.Name);
                input.SendKeys(Keys.Enter);
            }         
        }
    }
}
