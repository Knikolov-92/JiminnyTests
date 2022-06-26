using Faker;
using Jiminny.UITests.TestInfrastructure.Helpers;
using Jiminny.UITests.TestInfrastructure.Models;
using Jiminny.UITests.TestInfrastructure.Pages.ToDoItems;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Jiminny.UITests.Steps
{
    [Binding]
    public sealed class ToDoItemsStepDefinitions
    {
        private readonly ToDoItemsFacade page = new();
        private List<ToDoItem> listOfToDoItems = new();

        [Given(@"^Home page is loaded$")]
        public void HomePageIsLoaded()
        {
            page.NavigateToHomePage();
        }

        [When(@"^(\d+) item is added to the to-do list$")]
        [When(@"^(\d+) items are added to the to-do list$")]
        public void ItemsAreAddedToTheToDoList(int numberOfItems)
        {
            var listOfItems = RandomUtility.CreateListOfToDoITems(numberOfItems);
            
            page.AddItemsToTheToDoList(listOfItems);
            listOfToDoItems = listOfItems;
        }

        [When(@"^The item at position (\d+) in the list is edited$")]
        public void TheItemAtPositionNisEdited(int itemPosition)
        {
            var editedItem = page.EditItemInTheToDoList(itemPosition);

            listOfToDoItems.Clear();
            listOfToDoItems.Add(editedItem);
        }

        [When(@"^The item at position (\d+) in the list is completed")]
        public void TheItemAtPositionNisCompleted(int itemPosition)
        {
            page.CompleteItemInTheToDoList(itemPosition);
        }

        [When(@"^The item at position (\d+) in the list is deleted")]
        public void TheItemAtPositionNisDeleted(int itemPosition)
        {
            page.DeleteItemInTheToDoList(itemPosition);
        }

        [When(@"^The completed items are cleared")]
        public void TheCompletedItemsAreCleared()
        {
            page.ClearCompletedItems();
        }

        [When(@"^All items are marked as completed")]
        public void AllItemsAreMarkedAsCompleted()
        {
            page.MarkAllItemsAsCompleted();
        }

        [Then(@"^The to-do list is empty$")]
        public void TheToDoListIsEmpty()
        {
            page.Validate().ListWithItemsIsEmpty();
        }

        [Then(@"^The active-to-do list is empty$")]
        public void TheActiveToDoListIsEmpty()
        {
            page.LoadActiveList();
            page.Validate().ListWithItemsIsEmpty();
        }

        [Then(@"^The completed-to-do list is empty$")]
        public void TheCompletedToDoListIsEmpty()
        {
            page.LoadCompletedList();
            page.Validate().ListWithItemsIsEmpty();
        }

        [Then(@"^The item counter is not displayed$")]
        public void TheItemCounterIsNotDisplayed()
        {
            page.Validate().ItemsCounterIsNotDisplayed();
        }

        [Then(@"^The all-to-do list has (\d+) item$")]
        [Then(@"^The all-to-do list has (\d+) items$")]
        public void TheAllToDoListHasItems(int numberOfItems)
        {
            page.Validate().TheListHasItems(numberOfItems);
        }

        [Then(@"^The active-to-do list has (\d+) item$")]
        [Then(@"^The active-to-do list has (\d+) items$")]
        public void TheActiveToDoListHasItems(int numberOfItems)
        {
            page.LoadActiveList();
            page.Validate().TheListHasItems(numberOfItems);
        }

        [Then(@"^The completed-to-do list has (\d+) item$")]
        [Then(@"^The completed-to-do list has (\d+) items$")]
        public void TheCompletedToDoListHasItems(int numberOfItems)
        {
            page.LoadCompletedList();
            page.Validate().TheListHasItems(numberOfItems);
        }

        [Then(@"^The name of the item at position (\d+) is contained in the to-do list$")]       
        public void TheNameOfTheItemAtPositionNIsContainedInTheToDoList(int itemPosition)
        {
            var item = listOfToDoItems[itemPosition];

            page.Validate().TheListContainsItemName(item);
        }

        [Then(@"^The name of the item at position (\d+) is contained in the completed-to-do list$")]
        public void TheNameOfTheItemAtPositionNIsContainedInTheCompletedToDoList(int itemPosition)
        {
            var item = listOfToDoItems[itemPosition];

            page.LoadCompletedList();
            page.Validate().TheListContainsItemName(item);
        }

        [Then(@"^The counter shows (\d+) active item$")]
        [Then(@"^The counter shows (\d+) active items$")]
        public void TheCounterShowsActiveItems(int numberOfActiveItems)
        {
            page.Validate().ItemsCounterShowsCorrectNumberOfItems(numberOfActiveItems);
        }

        [Then(@"^The item at position (\d+) in the list is marked as 'completed'$")]
        public void TheItemAtPositionNisMarkedAsCompleted(int itemPosition)
        {
            page.Validate().TheItemIsMarkedAsCompleted(itemPosition);
        }

        [Then(@"^The active-to-do list contains the correct items$")]
        public void TheActiveToDoListContainsTheCorrectItems()
        {
            var itemsList = listOfToDoItems;

            page.LoadActiveList();
            page.Validate().TheListContainsTheCorrectItems(itemsList);
        }

        [Then(@"^The completed-to-do list contains the correct items$")]
        public void TheCompletedToDoListContainsTheCorrectItems()
        {
            var itemsList = listOfToDoItems;

            page.LoadCompletedList();
            page.Validate().TheListContainsTheCorrectItems(itemsList);
        }
    }
}