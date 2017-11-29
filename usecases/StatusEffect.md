
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
| 2.2.1        &lt; First Alternative Flow &gt;        |
| 2.2.2        &lt; Second Alternative Flow &gt;        |
| 3.        Special Requirements        |
|         &lt; First Special Requirement &gt;        |
| 4.        Preconditions        |
|         &lt; Precondition One &gt;        |
| 5.        Postconditions        |
|         &lt; Postcondition One &gt;        |
| 6.        Extension Points        |
|         &lt;Name of Extension Point&gt;        |
| Use-Case Specification: &lt;Use-Case Name&gt; |

[The following template is provided for a Use-Case Specification, which contains the textual properties of the use case. This document is used with a requirements management tool, such as Rational RequisitePro, for specifying and marking the requirements within the use-case properties.

The use-case diagrams can be developed in a visual modeling tool, such as Rational Rose. A use-case report, with all properties, may be generated with Rational SoDA. For more information, see the tool mentors in the Rational Unified Process.]

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

#### 2.2.1.1&lt; An Alternative Subflow &gt;

[Alternative flows may, in turn, be divided into subsections if it improves clarity.]

#### 2.2.2&lt; Second Alternative Flow &gt;

[There may be, and most likely will be, a number of alternative flows in a use case. Keep each alternative flow separate to improve clarity. Using alternative flows improves the readability of the use case, as well as preventing use cases from being decomposed into hierarchies of use cases. Keep in mind that use cases are just textual descriptions, and their main purpose is to document the behavior of a system in a clear, concise, and understandable way.]

## 3. Special Requirements

[A special requirement is typically a nonfunctional requirement that is specific to a use case, but is not easily or naturally specified in the text of the use case&#39;s event flow. Examples of special requirements include legal and regulatory requirements, application standards, and quality attributes of the system to be built including usability, reliability, performance or supportability requirements. Additionally, other requirementssuch as operating systems and environments, compatibility requirements, and design constraintsshould be captured in this section.]

### 3.1&lt; First Special Requirement &gt;

## 4. Preconditions

[A precondition of a use case is the state of the system that must be present prior to a use case being performed.]

### 4.1&lt; Precondition One &gt;
## 5. Postconditions

[A postcondition of a use case is a list of possible states the system can be in immediately after a use case has finished.]

### 5.1&lt; Postcondition One &gt;
## 6. Extension Points

[Extension points of the use case.]

### 6.1&lt;Name of Extension Point&gt;

[Definition of the location of the extension point in the flow of events.]

