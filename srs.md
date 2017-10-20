# Neverending Awesome Pdungeon

## Software Requirements Specification

Version 1.0

## Revision History

n/a

## Table of Contents

| 1.        Introduction        |
| --- |
|         Purpose        |
|         Scope        |
|         Definitions, Acronyms, and Abbreviations        |
|         References        |
|         Overview        |
| 2.        Overall Description        |
| 3.        Specific Requirements        |
|         Functionality        |
| 3.1.1        &lt;Functional Requirement One&gt;        |
|         Usability        |
| 3.2.1        &lt;Usability Requirement One&gt;        |
|         Reliability        |
| 3.3.1        &lt;Reliability Requirement One&gt;        |
|         Performance        |
| 3.4.1        &lt;Performance Requirement One&gt;        |
|         Supportability        |
| 3.5.1        &lt;Supportability Requirement One&gt;        |
|         Design Constraints        |
| 3.6.1        &lt;Design Constraint One&gt;        |
|         On-line User Documentation and Help System Requirements        |
|         Purchased Components        |
|         Interfaces        |
| 3.9.1        User Interfaces        |
| 3.9.2        Hardware Interfaces        |
| 3.9.3        Software Interfaces        |
| 3.9.4        Communications Interfaces        |
|         Licensing Requirements        |
|         Legal, Copyright, and Other Notices        |
|         Applicable Standards        |
| 4.        Supporting Information        |
| Software Requirements Specification |

## 1. Introduction

### 1.1 Purpose

The **SRS** fully describes the external behavior of the application or subsystem identified. It also describes nonfunctional requirements, design constraints, and other factors necessary to provide a complete and comprehensive description of the requirements for the software.

### 1.2 Scope

The scope of this project consists of two parts - the "Dungeon Crawler" part and the base-building aspect.

### 1.3 Definitions, Acronyms, and Abbreviations

NAP [studio name]: Nightmare Adventure Productions  
NAP [game]: Neverending Awesome Pdungeon  
HP: Hitpoints (Health)  
MP: Manapoints (Used to activate skills)  
GUI: Graphical User Interface  

### 1.4 References

n/a

### 1.5 Overview

Our Vision is to create a game, that combines features of a dungeon crawler game with those of a base-building system. Not only are you going to crawl through the dungeon and explore a new world, but you will have to buy upgrades at your base to gain access to more advanced equipment.

With „Neverending AWESOME Pdungeon – We needed a name edition“ (Yes, we know the name is stupid…) we want to promote the players‘ curiosity and ambition by facing them with increasingly difficult challenges.

Technologies:

* Our Project will be realised with Unity.
* For Project Management we will use TeamCity.
* IDE: VisualStudio

Planned subtasks / features:
* creating the GUI
* the dungeon part
* endless, procedurally generated dungeon
* implement different enemies
* combat system (weapons)
* random items for players to find
* movement system
* upgrade system / skill points
* different terrains
* skill tree
* character creation
* base
* upgrades
* build workshops to craft your own gear

## 2. Overall Description

<img src="https://raw.githubusercontent.com/AdrianSchneble/nap/master/usecases_uml.png" />

## 3. Specific Requirements

### 3.1 Functionality

* creating the GUI
* the dungeon part
* endless, procedurally generated dungeon
* implement different enemies
* combat system (weapons)
* random items for players to find
* movement system
* upgrade system / skill points
* different terrains
* skill tree
* character creation
* base
* upgrades
* build workshops to craft your own gear

#### 3.1.1 &lt;Functional Requirement One&gt;

[The requirement description.]

### 3.2 Usability

[This section includes all those requirements that affect usability. For example,

- specify the required training time for a normal users and a power user to become productive at particular operations
- specify measurable task times for typical tasks or base the new system&#39;s usability requirements on other systems that the users know and like
- specify requirement to conform to common usability standards, such as IBM&#39;s CUA standards Microsoft&#39;s GUI standards]

#### 3.2.1 Accessability

The game should be playable on most modern desktop computers by being ressource-efficient and cross-platform. A keyboard/mouse-combo or a standard XBox or PlayStation controller should be sufficient.

#### 3.2.2 Settings

The user should be able to customize different settings, such as ...
* volume
* controls

#### 3.2.3 Deployment

The game will be published as a free download on our blog. Automatic updates will be available if published via game distribution platforms like Steam or the Google Play Store.

#### 3.2.3 Required training time

The controls will be simple, intuitive and easy to remember. Mastering the game, however, requires a lot of practice and strategy.

### 3.3 Reliability

#### 3.3.1 Bugs

The game should be as bug-free as possible. Any game-breaking bugs will be fixed as soon as possible, even after the release.

### 3.4 Performance

#### 3.4.1 Ressource utilization

The game will be arguably ressource-efficient and should run on most computers that can run Unity at all - see https://unity3d.com/unity/system-requirements.  
An internet connection will not be required for any purpose other than initially downloading the game or subsequently updating it.

### 3.5 Supportability

n/a (yet)

### 3.6 Design Constraints

#### 3.6.1 Language

Due to Unity being the utilized game engine, we will be using C#. Javascript would be possible as well, but C# is more powerful.

### 3.7 On-line User Documentation and Help System Requirements

There will be a tutorial and a manual.

### 3.8 Purchased Components

Unity Personal is free to use for up to 100.000$ yearly income. Since we'll be publishing the game for free, this will not be an issue. Even if we someday publish paid DLCs, we're unlikely to cross this threshold.

### 3.9 Interfaces

#### 3.9.1 User Interfaces

The game will feature a GUI.

#### 3.9.2 Hardware Interfaces

The game requires access to a keyboard and mouse or a game controller, as well as some way to be displayed.

#### 3.9.3 Software Interfaces

The only software that our game interacts with is Unity itself.

#### 3.9.4 Communications Interfaces

n/a

### 3.10 Licensing Requirements

The game will be published under the <a href="https://raw.githubusercontent.com/AdrianSchneble/nap/master/LICENSE">MIT</a> license.

### 3.11 Legal, Copyright, and Other Notices

Unity will be used for the game.

This list will be expanded as necessary.

### 3.12 Applicable Standards

We will adhere to common standards in game controls, such as using WASD-keys for movement.

## 4. Supporting Information

n/a
