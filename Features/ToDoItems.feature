Feature: Items to-do (add/edit/delete)

Background: 
	Given Home page is loaded

Scenario: Default list of to-do items is empty
	Then There are no to-do items in the list
	And The item counter is not displayed
	
Scenario: Add single item to to-do list
	When 1 item is added to the to-do list
	Then The list has 1 item
	And The name of the item is contained in the to-do list
	And The counter shows 1 active item

Scenario: Edit an active item
	When 1 item is added to the to-do list
	And The item at position 0 in the list is edited
	Then The name of the item is contained in the to-do list

Scenario: Complete an active item
	When 1 item is added to the to-do list
	And The item at position 0 in the list is completed
	Then The item at position 0 in the list is marked as 'completed'
	And The counter shows 0 active items

Scenario: Delete an active item
	When 1 item is added to the to-do list
	And The item at position 0 in the list is deleted
	Then There are no to-do items in the list
	And The item counter is not displayed