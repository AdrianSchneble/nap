

# Neverending Awesome PDungeon 

## Test Plan

Version 1.0

## Revision History

| **Date** | **Version** | **Description** | **Author** |
| --- | --- | --- | --- |
| 29.04.2018 | 1.0 | Initial Version | Nikolas Traut |
|   |   |   |   |
|   |   |   |   |
|   |   |   |   |

Table of Contents

| 1.        Introduction        |
| --- |
|         Purpose        |
|         Scope        |
|         Intended Audience        |
|         Document Terminology and Acronyms        |
|         References        |
|         Document Structure        |
| 2.        Evaluation Mission and Test Motivation        |
|         Background        |
|         Evaluation Mission        |
|         Test Motivators        |
| 3.        Target Test Items        |
| 4.        Outline of Planned Tests        |
|         Outline of Test Inclusions        |
|         Outline of other candidates for potential inclusion        |
|         Outline of Test Exclusions        |
| 5.        Test Approach        |
|         Initial Test-Idea Catalogs and other reference sources        |
|         Testing Techniques and Types        |
| 5.2.1        Data and Database Integrity Testing        |
| 5.2.2        Function Testing        |
| 5.2.3        Business Cycle Testing        |
| 5.2.4        User Interface Testing        |
| 5.2.5        Performance Profiling        |
| 5.2.6        Load Testing        |
| 5.2.7        Stress Testing        |
| 5.2.8        Volume Testing        |
| 5.2.9        Security and Access Control Testing        |
| 5.2.10        Failover and Recovery Testing        |
| 5.2.11        Configuration Testing        |
| 5.2.12        Installation Testing        |
| 6.        Entry and Exit Criteria        |
|         Test Plan        |
| 6.1.1        Test Plan Entry Criteria        |
| 6.1.2        Test Plan Exit Criteria        |
| 6.1.3        Suspension and resumption criteria        |
|         Test Cycles        |
| 6.2.1        Test Cycle Entry Criteria        |
| 6.2.2        Test Cycle Exit Criteria        |
| 6.2.3        Test Cycle abnormal termination        |
| 7.        Deliverables        |
|         Test Evaluation Summaries        |
|         Reporting on Test Coverage        |
|         Perceived Quality Reports        |
|         Incident Logs and Change Requests        |
|         Smoke Test Suite and supporting Test Scripts        |
|         Additional work products        |
| 7.6.1        Detailed Test Results        |
| 7.6.2        Additional automated functional Test Scripts        |
| 7.6.3        Test Guidelines        |
| 7.6.4        Traceability Matrices        |
| 8.        Testing Workflow        |
| 9.        Environmental Needs        |
|         Base System Hardware        |
|         Base Software Elements in the Test Environment        |
|         Productivity and Support Tools        |
|         Test Environment Configurations        |
| 10.        Responsibilities, Staffing and Training Needs        |
|         People and Roles        |
|         Staffing and Training Needs        |
| 11.        Iteration Milestones        |
| 12.        Risks, Dependencies, Assumptions and Constraints        |
| 13.        Management Process and Procedures        |
|         Measuring and Assessing the Extent of Testing        |
|         Assessing the deliverables of this Test Plan        |
|         Problem Reporting, Escalation and Issue Resolution        |
|         Managing Test Cycles        |
|         Traceability Strategies        |
|         Approval and Signoff        |
| &lt;Iteration/ Master&gt; Test Plan |

## 1. Introduction
###  1.1 Purpose

The purpose of the Iteration Test Plan is to gather all of the information necessary to plan and control the test effort for a given iteration. It describes the approach to testing the software, and is the top-level plan generated and used by managers to direct the test effort.

This Test plan for Neverending Awesome Pdungeon supports the following objectives:
- Model
- Controller

### 1.2 Scope

This test plan specifies the procedure of unit testing code in the model and the controller of the project.

### 1.3 Intended Audience

This document is written for internal usage by the project team and for evalutation of our unit tests by third parties. 

### 1.4 Document Terminology and Acronyms

### 1.5 References
- <a href="https://github.com/AdrianSchneble/nap/blob/master/documentation/risks.pdf">Risk assessment</a>


### 1.6 Document Structure
See Table of Contents

## 2. Evaluation Mission and Test Motivation

### 2.1 Background

When writing or refactoring code, there always is a risk of introducing bugs or breaking established functionilities. By writing unit tests, we try to reduce this risk to a minimum by making shure that new functions are implemented properly and that already implemented functions return the same result after making changes to them.  

### 2.2 Evaluation Mission

Our mission is to reduce the amount of errors in the code, and therefor the number of bugs in our finished product, to a minimum. Out Motivation to do this is to give our users the best experience possible. 

### 2.3 Test Motivators

Our Testing is motivated by technical risks, use cases, and both funcional and non-funcional requirements

## 3. Target Test Items

The listing below identifies those test items (software, hardware, and supporting product elements) that have been identified as targets for testing. This list represents what items will be tested.

- Controller
- Model
- Behavior of indidual assets

## 4. Outline of Planned Tests


### 4.1 Outline of Test Inclusions

Creation of unit tests for all target test items. 

### 4.2 Outline of Other Candidates for Potential Inclusion

n/a

### 4.3 Outline of Test Exclusions

UI testing is currently not included in out testing, as it requires additional assets not included in unity by default. Our UI is expected to be simple enough to not warrant automated testing.

## 5. Test Approach
### 5.1 Initial Test-Idea Catalogs and Other Reference Sources

### 5.2 Testing Techniques and Types

#### 5.2.1 Data and Database Integrity Testing
n/a

#### 5.2.2 Function Testing

| Technique Objective: | Assert correct behavior of each functionality of the project |
| --- | --- |
| Technique: | Creation of unit tests for each functionality that is part of model or controller |
| Oracles: |  Sucessful execution of unit tests in Unity Test Runner - Sucessful execution of unit tests on build |
| Required Tools: | Unity Test Runner, NUnit, Unity Cloud Build |
| Success Criteria: | Test coverage of 50% |
| Special Considerations: | Seperation between Controller and View diffucult due to internal patterns of unity |

#### 5.2.3 Business Cycle Testing
n/a

#### 5.2.4 User Interface Testing
n/a

#### 5.2.5 Performance Profiling
n/a

#### 5.2.6 Load Testing
n/a

#### 5.2.7 Stress Testing
n/a

#### 5.2.8 Volume Testing
n/a

#### 5.2.9 Security and Access Control Testing
n/a

#### 5.2.10 Failover and Recovery Testing
n/a

#### 5.2.11 Configuration Testing
n/a

#### 5.2.12 Installation Testing
| Technique Objective:| Exercise the installation of the target-of-test onto each required hardware configuration under the following conditions to observe and log installation behavior and configuration state changes: new installation: a new machine, never installed previously with NAP; update: a  machine previously installed NAP, same versionupdate: a machine previously installed NAP, older version |
| --- | --- |
| Technique: | Manual download and installation. This test is not common enough to warrant automization.  |
| Oracles: | Manual launch of installed programm. |
| Required Tools: | Unity Cloud Build, 7ZIP or WinRar |
| Success Criteria: | Successful install on multiple computers with different operating systems |
| Special Considerations: | -  |

## 6. Entry and Exit Criteria
### 6.1Test Plan
#### 6.1.1 Test Plan Entry Criteria
The execution of the test plan can begin as soon as the firtst unit test is written. 

#### 6.1.2 Test Plan Exit Criteria
The execution of the test plan is complete when the project is finished

#### 6.1.3 Suspension and Resumption Criteria
The test plan is not supposed to be suspended. Therefore, there are no suspension and resumption criteria.  

### 6.2 Test Cycles

#### 6.2.1 Test Cycle Entry Criteria
A test cycle begins when the build of a new version is initiated.

#### 6.2.2 Test Cycle Exit Criteria
The test effort of a cycle is deemed sufficient when a build has been completed without failures and all unit tests are run successfully.

#### 6.2.3 Test Cycle Abnormal Termination
A test cycle is terminated prematurely when an error during the build occurs. 

## 7.Deliverables

### 7.1 Test Evaluation Summaries
A test evaluation summary will be automatically created after every build and is sent to all developers. 

### 7.2 Reporting on Test Coverage
n/a

### 7.3 Perceived Quality Reports
n/a

### 7.4 Incident Logs and Change Requests
Reports for individual tests created by Unity Test Runner, also included in the Test evaluation summaries.

### 7.5 Smoke Test Suite and Supporting Test Scripts
n/a

### 7.6 Additional Work Products
n/a

#### 7.6.1 Detailed Test Results
Detailes test results can be accessed on the unity cloud website and are automatically created for every build. 

#### 7.6.2 Additional Automated Functional Test Scripts
n/a

#### 7.6.3 Test Guidelines
n/a

#### 7.6.4 Traceability Matrices
n/a

## 8.Testing Workflow
When an Implementer adds a new function to the project, they also write a Unit-Test covering the function. All unit tests are then automatically executed on a build.

## 9. Environmental Needs

### 9.1 Base System Hardware

The following table sets forth the system resources for the test effort presented in this Test plan.

System Resources


| **Resource** | **Quantity** | **Name and Type** |
| --- | --- | --- |
| Client Test PCs | 3 | Laptop, Windows 10 |
| Client Test PCs | 1 | Desktop PC, Windows 7 |
| Client Test PCs | 3 | Desktop PC, Windows 10 |
| Test Development PCs | 3 | Laptop, Windows 10 |

### 9.2 Base Software Elements in the Test Environment

| **Software Element Name** | **Version** | **Type and Other Notes** |
| --- | --- | --- |
| Windows |  7,10 | Operating System |
| Internet Browser | Any | Any Browser |
| 7ZIP | Any | Unzipping of ZIP-Files |

### 9.3 Productivity and Support Tools

The following tools will be employed to support the test process for this Test plan.

| **Tool Category or Type** | **Tool Brand Name** | **Vendor or In-house** | **Version** |
| --- | --- | --- | --- |
| Game Engine and Testing tools | Unity  | Vendor | 2017.02.0f3 |
| IDE | Visual Studio | Vendor | 2017 |
| Project Management | YouTrack  | Vendor | 2018.1 |

### 9.4 Test Environment Configurations

The Testing environement must be able to run the game at an acceptable framerate (minimum 30 FPS, 60FPS or more is ideal). Otherwise, there is no specific configuration necessary.

## 10. Responsibilities, Staffing, and Training Needs
### 10.1 People and Roles

This table shows the staffing assumptions for the test effort.
Human Resources

| Role | Minimum Resources Recommended (number of full-time roles allocated) |	Specific Responsibilities or Comments |
|---|---|---|
| Implementer | 3 | Responsibilities include:<br> creates the test components required to support testability requirements as defined by the designer |
| Tester | 3 | implement tests and test suites<br> execute test suites<br> log results<br> analyze and recover from test failures<br> document incidents|
| Test Designer | 1 | Defines the technical approach to the implementation of the test effort. <br> Responsibilities include:<br> define test approach<br> define test automation architecture<br> verify test techniques<br> define testability elements<br> structure test implementation|
 
### 10.2 Staffing and Training Needs

All necessary roles are staffed by members of the project team. Unit Testing with Unity Test Runner and NUnit is similar to unit testing with JUnit, which all team members are famliar with. Therefore, no additional training is necessary. 

# 11. Iteration Milestones
| **Milestone** | **Planned Start Date** | **Actual Start Date** | **Planned End Date** | **Actual End Date** |
| --- | --- | --- | --- | --- |
| Iteration Plan agreed | 30.04.2018  | 30.04.2018  | End of Project |  |
| Iteration starts |  30.04.2018 | 06.11.2017 | End of Project |  |
|>= 20% Test Coverage | 15.05.2018||
|>= 30% Test Coverage | 30.05.2018||
|>= 50% Test Coverage | 15.06.2018||
|Tests integrated in CI | 30.04.2018 | 30.04.2018 | End of Project ||

# 12. Risks, Dependencies, Assumptions, and Constraints
n/a. The risk for our project are outlined in our <a href="https://github.com/AdrianSchneble/nap/blob/master/documentation/risks.pdf"> risk assessment document </a>. There are no additional risks for testing. 

## 13. Management Process and Procedures
### 13.1 Measuring and Assessing the Extent of Testing
Test coverage can be calculated by the Unity Testing tools. 

### 13.2 Assessing the Deliverables of this Test Plan
Basic assessment is done by checking success for every test cycle. Failures can be assessed by checking the detailed test reports. 

### 13.3 Problem Reporting, Escalation, and Issue Resolution
Minor Problems will be fixed by the Implementer of the corresponding task. Major Problems will be escalated and warrant an additional task in YouTrack. 

### 13.4 Managing Test Cycles
n/a

### 13.5 Traceability Strategies
n/a

### 13.6 Approval and Signoff
This test plan has to be approved by the Test Designer and the Testers

