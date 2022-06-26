﻿using Faker;
using Jiminny.UITests.TestInfrastructure.Helpers;
using Jiminny.UITests.TestInfrastructure.Models;
using Jiminny.UITests.TestInrastructure.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.Linq;

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

        public ToDoItem EditItemInTheToDoList(int itemPosition)
        {
            var items = WebElementUtility.WaitForElementsToExistInDom(() => Elements.AllItemsList);
            var item = items.ElementAt(itemPosition);

            var newItem = EditItemLabel(item);

            return newItem;
        }

        public void DoubleClickOnItemToBeginEditing(int itemPosition)
        {
            var items = WebElementUtility.WaitForElementsToExistInDom(() => Elements.AllItemsList);
            var item = items.ElementAt(itemPosition);

            DoubleClickOnItemInTheList(item);
        }

        public void CompleteItemInTheToDoList(int itemPosition)
        {
            var items = WebElementUtility.WaitForElementsToExistInDom(() => Elements.AllItemsList);
            var item = items.ElementAt(itemPosition);

            ClickOnWithActions(Elements.GetItemCheckbox(item));
        }

        public void DeleteItemInTheToDoList(int itemPosition)
        {
            var items = WebElementUtility.WaitForElementsToExistInDom(() => Elements.AllItemsList);
            var item = items.ElementAt(itemPosition);

            WebElementUtility.MoveCursorOverElement(item);
            ClickOn(Elements.GetItemDeleteButton(item));
        }

        public void DeleteItemsInTheToDoList(int startPosition, int endPosition)
        {
            var items = WebElementUtility.WaitForElementsToExistInDom(() => Elements.AllItemsList);

            for (int i = endPosition; i >= startPosition; i--)
            {
                var itemLabel = Elements.GetItemLabel(items.ElementAt(i));

                WebElementUtility.MoveCursorOverElement(itemLabel);
                ClickOn(Elements.GetItemDeleteButton(items.ElementAt(i)));
            }
        }

        public void LoadAllList()
        {
            ClickOn(() => Elements.AllListButton);
            WebElementUtility.WaitForElementsToExistInDom(() => Elements.ToDoList);
        }

        public void LoadActiveList()
        {
            ClickOn(() => Elements.ActiveListButton);
            WebElementUtility.WaitForElementsToExistInDom(() => Elements.ToDoList);
        }

        public void LoadCompletedList()
        {
            ClickOn(() => Elements.CompletedListButton);
            WebElementUtility.WaitForElementsToExistInDom(() => Elements.ToDoList);
        }

        public void ClearCompletedItems()
        {
            ClickOn(() => Elements.ClearCompletedButton);
        }

        public void MarkAllItemsAsCompleted()
        {
            ClickOn(() => Elements.MarkAllCompletedButton);
        }

        private ToDoItem EditItemLabel(IWebElement item)
        {            
            var newItem = new ToDoItem()
            {
                Name = Lorem.Sentence()
            };
            var numberOfSymbols = item.Text.Length;

            DoubleClickOnItemInTheList(item);
            var itemInput = Elements.GetItemLabelInput(item);

            for (int i = 0; i < numberOfSymbols; i++)
            {
                itemInput.SendKeys(Keys.Backspace);
            }            
            itemInput.SendKeys(newItem.Name);
            itemInput.SendKeys(Keys.Enter);

            return newItem;
        }

        private void DoubleClickOnItemInTheList(IWebElement item)
        {
            var action = new Actions(Browser.Instance.WebDriver);

            action.DoubleClick(item).Build().Perform();
        }
    }
}
