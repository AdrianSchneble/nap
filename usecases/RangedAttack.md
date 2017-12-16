# Neverending Awesome PDungeon

# Use-Case Specification: Ranged Attack

# Version 1.0

Revision Histoy

| **Date** | **Version** | **Description** | **Author** |
| --- | --- | --- | --- |
|16.12.2017 | 1.0.0 | Initial Version| Nikolas Traut |
|   |   |   |   |
|   |   |   |   |
|   |   |   |   |
			
			

Table of Contents


| 1.        Ranged Attack       |
| --- |
|         Brief Description        |
| 2.        Flow of Events        |
|         Basic Flow        |
| 3.        Special Requirements        |
| 4.        Preconditions        |
| 4.4.1    Player must be in the dungeon |
| 4.4.2    Player must have ranged weapon|
| 5.        Postconditions        |
| 6.        Extension Points        |

## 1. Ranged Attacks

### 1.1 Brief Description

This use case describes how a ranged attack is handled by the system. A ranged attack can be initiated by the player pressing 
space while holding a ranged weapon, or by the AI of an enemy capable to perform ranged attacks. Valid targets for ranged attacks are enemies, obstacles, and the player. 

Before Attack              |  During Attack |  After Attack 
:-------------------------:|:-------------------------:|:-------------------------:
 <img src= "https://github.com/AdrianSchneble/nap/blob/master/usecases/UC_RangedAttack_Screenshot1.png"> |  <img src="https://github.com/AdrianSchneble/nap/blob/master/usecases/UC_RangedAttack_Screenshot2.png">|  <img src= "https://github.com/AdrianSchneble/nap/blob/master/usecases/UC_RangedAttack_Screenshot3.png">


## 2. Flow of Events

### 2.1 Basic Flow

<img src= "https://github.com/AdrianSchneble/nap/blob/master/usecases/UC_RangedAttack_ActivityDiagram.png">

### 2.2 Alternative Flows

n/a


## 3. Special Requirements

n/a

## 4. Preconditions

### 4.1 Player must be in the dungeon

In order for the player to initiate a ranged attack, they have to be a dungeon. While performing attacks is possible in the players base, there are no valid targets in the base. 

### 4.2 Player must have a ranged weapon

In order to be able to perform a ranged attack, a player must possess a ranged weapon. This restriction does not apply to enemies, as some enemies will be able to shoot projectiles without a ranged weapon. 

## 5. Postconditions

n/a

## 6. Extension Points

n/a



