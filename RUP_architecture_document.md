

NAP

Software Architecture Document

Version &lt;1.0&gt;

Revision History

| Date | Version | Description | Author |
| --- | --- | --- | --- |
| 26/11/17 | 1.0 | added class diagram | Patrick Siewert |
| 01/07/18 | 2.0 | updated class diagram | Patrick Siewert |
|   |   |   |   |
|   |   |   |   |

Table of Contents

| 1.        Introduction        |
| --- |
| 1.1        Purpose        |
| 1.2        Scope        |
| 1.3        Definitions, Acronyms, and Abbreviations        |
| 1.4        References        |
| 1.5        Overview        |
| 2.        Architectural Representation        |
| 3.        Architectural Goals and Constraints        |
| 4.        Use-Case View        |
| 4.1        Use-Case Realizations        |
| 5.        Logical View        |
| 5.1        Overview        |
| 5.2        Architecturally Significant Design Packages        |
| 6.        Process View        |
| 7.        Deployment View        |
| 8.        Implementation View        |
| 8.1        Overview        |
| 8.2        Layers        |
| 9.        Data View (optional)        |
| 10.        Size and Performance        |
| 11.        Quality        |

Software Architecture Document

# 1.Introduction

## 1.1 Purpose

This document provides a comprehensive architectural overview of the system, using a number of different architectural views to depict different aspects of the system. It is intended to capture and convey the significant architectural decisions which have been made on the system.

## 1.2 Scope

This document describes the architecture used in the NAP projekt. As we neather have a client-server architecture nor a database, this document only contains the mvc-pattern.

## 1.3 Definitions, Acronyms, and Abbreviations

n/a

## 1.4 References

n/a

## 1.5 Overview

n/a

# 2.Architectural Representation

Model-View-Controller pattern

# 3.Architectural Goals and Constraints

Goal is to apply the MVC pattern to our project. Since we are using Unity we do not have an external MVC framework but we use the Unity architecture which is similar to MVC. The difference is, that the view and the controller classes are not clearly divided.

# 4.Use-Case View

n/a

## 4.1Use-Case Realizations

n/a

# 5.Logical View

## 5.1Overview

<img src="https://github.com/AdrianSchneble/nap/blob/master/documentation/patterns/class_diagram_factory_pattern.png">

# 6.Process View

n/a

# 7.Deployment View

n/a

# 8.Implementation View

n/a

## 8.1Overview

## 8.2Layers

# 9.Data View (optional)

n/a

# 10.Size and Performance

n/a

# 11.Quality

n/a
