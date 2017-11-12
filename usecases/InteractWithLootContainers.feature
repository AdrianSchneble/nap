Feature: InteractWithLootContainers
	In order to aquire items and gold 
	as a player
	I want to interact with loot containers 

Scenario: Normal loot container
	Given I am standing on a GroundTile adjacent to the loot container
	And the loot container is not a mimic
	When I press e
	Then the loot container should open
	And the contained items should be added to my inventory

Scenario: Mimic
	Given I am standing on a GroundTile adjacent to the loot container
	And the loot container is a mimic
	When the mimic dies
	Then the items dropped by the mimic should be added to my inventory
