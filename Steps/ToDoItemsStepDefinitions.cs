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

        [Then(@"^There are no to-do items in the list$")]
        public void ThereAreNoItemsInTheList()
        {
            page.Validate().ListWithItemsIsEmpty();
        }

        [Then(@"^The item counter is not displayed$")]
        public void TheItemCounterIsNotDisplayed()
        {
            page.Validate().ItemsCounterIsNotDisplayed();
        }

        [Then(@"^The list has (\d+) item$")]
        [Then(@"^The list has (\d+) items$")]
        public void TheListHasItems(int numberOfItems)
        {
            page.Validate().TheListHasItems(numberOfItems);
        }

        [Then(@"^The name of the item is contained in the to-do list$")]       
        public void TheNameOfTheItemIsContainedInTheToDoList()
        {
            var item = listOfToDoItems[0];

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
    }
}
