Feature: Items to-do (add/edit/delete)

Background: 
	Given Home page is loaded

Scenario: Default list of to-do items is empty
	Then The to-do list is empty
	And The item counter is not displayed
	
Scenario: Add single item to to-do list
	When 1 item is added to the to-do list
	Then The all-to-do list has 1 item
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
	Then The to-do list is empty
	And The item counter is not displayed

Scenario: Completed list is empty when there are only active items
	When 1 item is added to the to-do list
	Then The all-to-do list has 1 item
	And The active-to-do list has 1 item
	And The completed-to-do list is empty

Scenario: Active list is empty when there are only completed items
	When 1 item is added to the to-do list
	And The item at position 0 in the list is completed
	Then The all-to-do list has 1 item	
	And The active-to-do list is empty
	And The completed-to-do list has 1 item

Scenario: Clear completed item
	When 1 item is added to the to-do list
	And The item at position 0 in the list is completed
	And The completed items are cleared
	Then The to-do list is empty
	And The item counter is not displayed

Scenario: Edit a completed item
	When 1 item is added to the to-do list
	And The item at position 0 in the list is completed
	And The item at position 0 in the list is edited
	Then The name of the item is contained in the to-do list

Scenario: Add 1 active item and 1 completed item -> clear completed -> completed list is empty -> active list has 1 item
	When 2 items are added to the to-do list
	And The item at position 0 in the list is completed
	And The completed items are cleared
	Then The all-to-do list has 1 item
	And The active-to-do list has 1 item
	And The completed-to-do list is empty