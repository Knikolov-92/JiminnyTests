using Jiminny.UITests.TestInfrastructure.Helpers;
using Jiminny.UITests.TestInfrastructure.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Jiminny.UITests.TestInfrastructure.Pages.ToDoItems
{
    public class ToDoItemsValidator : BaseValidator<ToDoItemsElements>
    {
        public void ListWithItemsIsEmpty()
        {
            bool isListEmpty = WebElementUtility.DoElementsExistInDom(() => Elements.AllItemsList);

            Assert.That(isListEmpty, Is.False, "List of items is not empty");
        }

        public void ItemsCounterIsNotDisplayed()
        {
            var element = WebElementUtility.WaitForElementToExistInDom(() => Elements.ItemCounter);

            Assert.That(element.Displayed, Is.False, "Items counter is displayed");
        }

        public void DeleteItemButtonIsNotDisplayed(int index)
        {
            var elementList = WebElementUtility.WaitForElementsToExistInDom(() => Elements.AllItemsList);
            var element = elementList.ElementAt(index);
            bool isDisplayed = WebElementUtility.IsElementDisplayed(() => Elements.GetItemDeleteButton(element));

            Assert.That(isDisplayed, Is.False, "Delete-item-button is displayed");
        }

        public void SelectItemCheckboxIsNotDisplayed(int index)
        {
            var elementList = WebElementUtility.WaitForElementsToExistInDom(() => Elements.AllItemsList);
            var element = elementList.ElementAt(index);
            bool isDisplayed = WebElementUtility.IsElementDisplayed(() => Elements.GetItemCheckbox(element));

            Assert.That(isDisplayed, Is.False, "Select-item-checkbox is displayed");
        }

        public void ItemsCounterShowsCorrectNumberOfItems(int expectedNumber)
        {
            var element = WebElementUtility.WaitForElementToExistInDom(() => Elements.ItemCounter);

            Assert.That(element.Text, Is.EqualTo(expectedNumber.ToString()), "Items counter shows incorrect number of items");
        }

        public void TheListHasItems(int numberOfItems)
        {
            var elementList = WebElementUtility.WaitForElementsToExistInDom(() => Elements.AllItemsList).ToList();

            Assert.That(elementList.Count, Is.EqualTo(numberOfItems), "Number of items in the list is not expected");
        }

        public void TheListContainsItemName(ToDoItem item)
        {
            var elementList = WebElementUtility.WaitForElementsToExistInDom(() => Elements.AllItemsList);
            bool doesContain = elementList.Any(element => Elements.GetItemLabel(element).Text.Equals(item.Name));

            Assert.That(doesContain, Is.True, "Item name is not in the list");
        }

        public void TheItemIsMarkedAsCompleted(int itemPosition)
        {
            var itemList = WebElementUtility.WaitForElementsToExistInDom(() => Elements.AllItemsList);
            var item = itemList.ElementAt(itemPosition);
            var className = Elements.GetItemCheckboxClass(item);

            Assert.That(className, Is.EqualTo("todo completed"), "Item name is not marked as 'completed'");
        }

        public void TheListContainsTheCorrectItems(List<ToDoItem> items)
        {
            var toDoList = WebElementUtility.WaitForElementsToExistInDom(() => Elements.AllItemsList);
            List<string> expectedItems = new();
            List<string> actualItems = new();

            foreach (var toDo in items)
            {
                string itemName = toDo.Name;
                expectedItems.Add(itemName);
            }

            foreach (var toDo in toDoList)
            {
                var item = new ToDoItem()
                {
                    Name = Elements.GetItemLabel(toDo).Text
                };

                actualItems.Add(item.Name);
            }

            CollectionAssert.IsSubsetOf(actualItems, expectedItems, "Actual list does not contain the expected list of to-do-items");
        }
    }
}
