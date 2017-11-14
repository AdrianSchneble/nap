
# Neverending Awesome PDungeon

# Use-Case Specification: Opening Doors

# Version 1.0

Revision History

| **Date** | **Version** | **Description** | **Author** |
| --- | --- | --- | --- |
| 03.11.17 | 1.0 | Initial commit | Patrick Siewert |
|   |   |   |   |
|   |   |   |   |
|   |   |   |   |

Table of Contents

| 1.        Opening Doors        |
| --- |
|         Brief Description        |
| 2.        Flow of Events        |
|         Basic Flow        |
|         Alternative Flows        |
| 3.        Special Requirements        |
| 4.        Preconditions        |
|         &lt; Precondition One &gt;        |
| 5.        Postconditions        |
|         &lt; Postcondition One &gt;        |
| 6.        Extension Points        |
|         &lt;Name of Extension Point&gt;        |
| Use-Case Specification: &lt;Use-Case Name&gt; |

 ## 1. Opening Doors
 
 ### 1.1 Brief Description
This use case describes how the game is processing an attempt to open a door. Both locked and unlocked doors are covered by this use case.

<img src = "https://raw.githubusercontent.com/AdrianSchneble/nap/master/usecases/Screenshot_open_door_1.png">

<img src = "https://raw.githubusercontent.com/AdrianSchneble/nap/master/usecases/Screenshot_open_door_2.png">

## 2. Flow of Events
### 2.1 Basic Flow

The use case is intiated by the player trying to open a door by approaching it. The system then checks whether the door is locked, which was determind when the dungeon floor was generated. If the door is not locked or the player has a key for a locked door, the door is considered open, and the doors icon is changed to represent an opened door. If the door is locked and the player does not have a key, the system displays a message to the player telling them that a key is required. The player then has to find a key to open the door.

<img src="https://raw.githubusercontent.com/AdrianSchneble/nap/master/usecases/UC_OpenDoor_ActivityDiagram.png">

```gherkin
Feature: OpenDoor
	As a player
	I want to open a door

Scenario: Open unlocked door 
	Given I am standing on a GroundTile adjacent to the door
	And the door is closed
	And the door is unlocked 
	When I press e
	Then the door should open 

Scenario: Open locked door with Key
	Given I am standing on a GroundTile adjacent to the door
	And the door is closed
	And the door is locked
	And I have a key
	When I press e
	Then the door should open
	And the key should be removed from my Inventory

Scenario: Open locked door without Key
	Given I am standing on a GroundTile adjacent to the door
	And the door is closed
	And the door is locked
	And I do not have a key
	When I press e
	Then the door should not open

Scenario: Closing Door
	Given I am standing on a GroundTile adjacent to the door
	And the door is open
	And no Entity is in the door
	When I press e
        Then the door should close
```

<a href= https://github.com/AdrianSchneble/nap/blob/master/usecases/OpenDoor.feature>Narrative</a>

<a href= https://github.com/AdrianSchneble/nap/blob/master/usecases/OpenDoorSteps.cs>Step definitions</a>

### 2.2 Alternative Flows

The use case has only two possible flows, which are both part of the basic flow. Therefore, this use case does not have any alternative flows

## 3. Special Requirements

n/a

## 4. Preconditions

### 4.1&lt; Precondition One &gt;

tbd

## 5. Postconditions

### 5.1&lt; Postcondition One &gt;

tbd

## 6. Extension Points

### 6.1&lt;Name of Extension Point&gt;

tbd

