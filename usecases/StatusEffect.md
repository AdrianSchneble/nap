
# Neverending Awesome PDungeon

# Use-Case Specification: Status Effects

# Version 1.0

Revision History

| **Date** | **Version** | **Description** | **Author** |
| --- | --- | --- | --- |
| 29.11.2017 | 1.0.0 | Initial Version| Nikolas Traut |
|   |   |   |   |
|   |   |   |   |
|   |   |   |   |

Table of Contents

| 1.        Status Effects       |
| --- |
|         Brief Description        |
| 2.        Flow of Events        |
|         Basic Flow        |
|         Alternative Flows        |
| 2.2.1        Identical Status Effect is applied again        |
| 2.2.2        Player Dies       |
| 3.        Special Requirements        |
| 4.        Preconditions        |
| 4.4.1     Player must be alive |
| 4.4.2     Player must be in the dungeon |
| 5.        Postconditions        |
| 6.        Extension Points        |




 ## 1. Use-Case Name
 
 ### 1.1 Brief Description

This use case shows how the game handles the application of a status affect to a player. These status effects are triggerd
by the players action. The following example shows a "Slowed Down" status effect, which is triggered by stepping into a tile
of water

<img src = "https://github.com/AdrianSchneble/nap/blob/master/usecases/UC_StatusEffect_Screenshot1.png">
(Before Status Effect is triggered) 


<img src = "https://github.com/AdrianSchneble/nap/blob/master/usecases/UC_StatusEffect_Screenshot2.png">
(After Status Effect is triggered, please note the changed speed)

## 2. Flow of Events
### 2.1 Basic Flow

<img src= "https://github.com/AdrianSchneble/nap/blob/master/usecases/UC_StatusEffect_ActivityDiagram.png">

### 2.2 Alternative Flows
#### 2.2.1 Identical Status Effect is applied again

In some cases, a status effect can be applied to a player while an identical status effect is already active. In this case,
the new status affect is not applied, but the duration of the existing status effect is set to the new status effects duration,
if it is lower. The flow of the existing status effect is not interrupted. 

#### 2.2.2 Player Dies 

If a player dies while beeing affected by status affects, the duration of all status effects is set to 0. 

## 3. Special Requirements

n/a

## 4. Preconditions

### 4.1 Player must be alive

In order the able to be affected by status effects and to trigger them, the player must be alive. A dead player can not trigger
status effects, and all status effects present when a player dies are removed on the next tick (See 2.2.2)

### 4.2 Player must be in the dungeon 

The player must be in the dungeon to trigger status effects, as there are no triggers in the players base. If the player leaves the dungeon, all status effects are removed

## 5. Postconditions

n/a

## 6. Extension Points

n/a

