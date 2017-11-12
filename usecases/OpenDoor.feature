Feature: OpenDoor
	As a player
	I want to open a door

Scenario: Open unlocked door 
	Given I am standing on a GroundTile adjacent to the door
	And the door is closed
	And the door is unlocked 
	When I press E
	Then the door should open 

Scenario: Open locked door with Key
	Given I am standing on a GroundTile adjacent to the door
	And the door is closed
	And the door is locked
	And I have a key
	When I press E
	Then the door should open
	And the key should be removed from my Inventory

Scenario: Open locked door without Key
	Given I am standing on a GroundTile adjacent to the door
	And the door is closed
	And the door is locked
	And I do not have a key
	When I press E
	Then the door should not open

Scenario: Closing Door
	Given I am standing on a GroundTile adjacent to the door
	And the door is open
	And no Entity is in the door
	When I press E
	Then the door should close
