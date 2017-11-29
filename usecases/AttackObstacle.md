
# Neverending Awesome PDungeon

# Use-Case Specification: Attack Obstacle

# Version 1.0


Revision History

| **Date** | **Version** | **Description** | **Author** |
| --- | --- | --- | --- |
| 29.11.2017| 1.0.0 | Initial Version | Nikolas Traut |
|   |   |   |   |
|   |   |   |   |
|   |   |   |   |

Table of Contents

| 1.        Attack Obstacle    |
| --- |
|         Brief Description        |
| 2.        Flow of Events        |
|         Basic Flow        |
|         Alternative Flows        |
| 2.2.1        Player does not destroy obstacle       |      
| 3.        Special Requirements        |
| 4.        Preconditions        |
| 4.4.1     Player must be near obstacle |
| 4.4.2 Player must be able to attack |
| 5.        Postconditions        |
| 6.        Extension Points        |

[The following template is provided for a Use-Case Specification, which contains the textual properties of the use case. This document is used with a requirements management tool, such as Rational RequisitePro, for specifying and marking the requirements within the use-case properties.

The use-case diagrams can be developed in a visual modeling tool, such as Rational Rose. A use-case report, with all properties, may be generated with Rational SoDA. For more information, see the tool mentors in the Rational Unified Process.]

## 1. Attack Obstacle
 
### 1.1 Brief Description

This use case describes how the game handles a attack on an obstacle. 

<img src = "https://github.com/AdrianSchneble/nap/blob/master/usecases/UC_AttackObstacle_Screenshot1.png">
(Before Attack)

<img src = "https://github.com/AdrianSchneble/nap/blob/master/usecases/UC_AttackObstacle_Screenshot2.png">
(After Attack)

The damage depends on the weapon used. In this case, the basic attack dealt 1 damage to the obstacle

## 2. Flow of Events
### 2.1 Basic Flow

<img src = "https://github.com/AdrianSchneble/nap/blob/master/usecases/UC_AttackObstacle_ActivityDiagram.png" >

### 2.2 Alternative Flows
#### 2.2.1 Player does not destroy obstacle

The player attacks the obstacle not enough times to reduce its HP to 0. In this case, the obstacle is not destroyed. 
The damage the obstacle has taken is saved. 

## 3. Special Requirements

n/a

## 4. Preconditions

### 4.1 Player must be near obstacle

The player must be near the obstacle they are trying to attack. The obstacle has to be in the range of the weapon or the spell
the player is using to attack the obstacle. 

### 4.2 Player is able to attack

In Order to attack an obstacle, the player needs to have a way of attacking. This can be a weapon or a damaging spell.  

## 5. Postconditions

n/a

## 6. Extension Points

n/a

