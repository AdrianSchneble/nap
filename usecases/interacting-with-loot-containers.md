
# Neverending Awesome PDungeon

# Use-Case Specification: Interacting with loot containers

# Version 1.0

Revision History

| **Date** | **Version** | **Description** | **Author** |
| --- | --- | --- | --- |
| 03.11.17 | 1.0 | Initial commit | Patrick Siewert |
|   |   |   |   |
|   |   |   |   |
|   |   |   |   |

Table of Contents

| 1.        Interacting with loot containers        |
| --- |
|         Brief Description        |
| 2.        Flow of Events        |
|         Basic Flow        |
|         Alternative Flows        |
| 2.2.1        Player is killed during combat        |
| 2.2.2        Player flees       |
| 3.        Special Requirements        |
| 4.        Preconditions        |
|         &lt; Precondition One &gt;        |
| 5.        Postconditions        |
|         &lt; Postcondition One &gt;        |
| 6.        Extension Points        |
|         &lt;Name of Extension Point&gt;        |
| Use-Case Specification: Interacting with loot containers |

 ## 1. Interacting with loot containers
 
 ### 1.1 Brief Description

<img src = "https://raw.githubusercontent.com/AdrianSchneble/nap/master/usecases/Screenshot_interact_with_items.png">

## 2. Flow of Events
### 2.1 Basic Flow

The use case is initiated by the player interacting with a loot container. The system first checks if the loot container is a mimic, which was determined when the loot container was generated. If the loot container is not a mimic, items are randomly selected from the loot table for the respective loot container. If the loot container is a mimic, the player has to fight against it. Upon defeating the mimic, loot is then randomly selected from the mimic loot table. In both scenarios, the selected items are then added to the players inventory. The player is then able to inspect the items they just found. 

<img src="https://raw.githubusercontent.com/AdrianSchneble/nap/master/usecases/UC_InteractWithLootContainers_ActivityDiagram.png">

<a href= https://github.com/AdrianSchneble/nap/blob/master/usecases/InteractWithLootContainers.feature>Narrative</a>

<a href= https://github.com/AdrianSchneble/nap/blob/master/usecases/InteractWithLootContainersSteps.cs> Step definitions </a>

### 2.2 Alternative Flows
#### 2.2.1 Player is killed during combat

If the loot container turns out to be a mimic and the player loses the fight against it, the player is killed and the current game is over. In this case, the use case ends after "combat".

#### 2.2.2 Player flees

The loot container turns out to be a mimic, and the player disengages from combat and flees. In this case, the use case ends after "combat". In this alternative flow, the player is still alive and can continue to explore the dungeon. 

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

