Feature: Items to-do (add/edit/delete)

Background: 
	Given User has navigated to the Home page

Scenario: Default list of to-do items is empty
	Then There are no to-do items in the list
	And The item counter is not displayed
	
Scenario: Add single item to to-do list
	When 1 item is added to the to-do list
	Then The list has 1 item
	And The name of the item is contained in the to-do list
	And The counter shows 1 active item