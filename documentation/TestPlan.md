

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

-

### 1.2 Scope

[Describe the levels of testingfor example, Unit, Integration, or Systemand the types of testingsuch as Functionality, Usability, Reliability, Performance, and Supportabilitythat will be addressed by this **Test Plan**. It is also important to provide a general indication of significant areas that will be **excluded** from scope, especially where the intended audience might otherwise reasonably assume the inclusion of those areas.

**Note** : Avoid placing detail here that you will repeat in sections 3, Target Test Items, and 4,Outline of Planned Tests.]

### 1.3 Intended Audience

This document is written for internal usage by the project team and for evalutation of our unit tests by third parties. 

### 1.4 Document Terminology and Acronyms

[This subsection provides the definitions of any terms, acronyms, and abbreviations required to properly interpret the **Test Plan**. Avoid listing items that are generally applicable to the project as a whole and that are already defined in the project&#39;s Glossary. Include a reference to the project&#39;s Glossary in the References section.]

### 1.5 References

[This subsection provides a list of the documents referenced elsewhere within the **Test Plan**. Identify each document by title, version (or report number if applicable), date, and publishing organization or original author. Avoid listing documents that are influential but not directly referenced. Specify the sources from which the &quot;official versions&quot; of the references can be obtained, such as intranet UNC names or document reference codes. This information may be provided by reference to an appendix or to another document.]

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

UI testing is currently not included in out testing, as it requires addidional assets not included in unity by default. Our UI is expected to be simple enough to not warrant automated testing.

## 5. Test Approach

[The Test Approach presents the recommended strategy for designing and implementing the required tests. Sections 3, Target Test Items, and 4, Outline of Planned Tests, identified **what** items will be tested and **what** types of tests would be performed. This section describes **how** the tests will be realized.

One aspect to consider for the test approach is the techniques to be used. This should include an outline of how each technique can be implemented, both from a manual and/or an automated perspective, and the criterion for knowing that the technique is useful and successful. For each technique, provide a description of the technique and define why it is an important part of the test approach by briefly outlining how it helps achieve the Evaluation Mission or addresses the Test Motivators.

Another aspect to discuss in this section is the Fault or Failure models that are applicable and ways to approach evaluating them.

As you define each aspect of the approach, you should update Section 10, Responsibilities, Staffing, and Training Needs, to document the test environment configuration and other resources that will be needed to implement each aspect.]

### 5.1 Initial Test-Idea Catalogs and Other Reference Sources

[Provide a listing of existing resources that will be referenced to stimulate the identification and selection of specific tests to be conducted. An example Test-Ideas Catalog is provided in the examples section of RUP.]

### 5.2 Testing Techniques and Types

#### 5.2.1 Data and Database Integrity Testing
n/a

#### 5.2.2 Function Testing

[Function testing of the target-of-test should focus on any requirements for test that can be traced directly to use cases or business functions and business rules. The goals of these tests are to verify proper data acceptance, processing, and retrieval, and the appropriate implementation of the business rules. This type of testing is based upon black box techniques; that is verifying the application and its internal processes by interacting with the application via the Graphical User Interface (GUI) and analyzing the output or results. The following table identifies an outline of the testing recommended for each application.]

| Technique Objective: | [Exercise target-of-test functionality, including navigation, data entry, processing, and retrieval to observe and log target behavior.] |
| --- | --- |
| Technique: | [Execute each use-case scenario&#39;s individual use-case flows or functions and features, using valid and invalid data, to verify that: the expected results occur when valid data is used the appropriate error or warning messages are displayed when invalid data is used  each business rule is properly applied] |
| Oracles: | [Outline one or more strategies that can be used by the technique to accurately observe the outcomes of the test. The oracle combines elements of both the method by which the observation can be made and the characteristics of specific outcome that indicate probable success or failure. Ideally, oracles will be self-verifying, allowing automated tests to make an initial assessment of test pass or failure, however, be careful to mitigate the risks inherent in automated results determination.] |
| Required Tools: | [The technique requires the following tools:
- Test Script Automation Tool
- base configuration imager and restorer
- backup and recovery tools
- installation-monitoring tools (registry, hard disk, CPU, memory, and so forth)
- Data-generation tools]
 |
| Success Criteria: | [The technique supports the testing of:   all key use-case scenarios  all key features] |
| Special Considerations: | [Identify or describe those items or issues (internal or external) that impact the implementation and execution of  function test.] |

#### 5.2.3 Business Cycle Testing
n/a

#### 5.2.4 User Interface Testing

[User Interface (UI) testing verifies a user&#39;s interaction with the software. The goal of UI testing is to ensure that the UI provides the user with the appropriate access and navigation through the functions of the target-of-test. In addition, UI testing ensures that the objects within the UI function as expected and conform to corporate or industry standards.]

| Technique Objective: | [Exercise the following to observe and log standards conformance and target behavior:
- Navigation through the target-of-test reflecting business functions and requirements, including window-to-window, field-to-         field, and use of access methods (tab keys, mouse movements, accelerator keys).
- Window objects and characteristics can be exercised–such as menus, size, position, state, and focus.]
 |
| --- | --- |
| Technique: | [Create or modify tests for each window to verify proper navigation and object states for each application window and object.] |
| Oracles: | [Outline one or more strategies that can be used by the technique to accurately observe the outcomes of the test. The oracle combines elements of both the method by which the observation can be made and the characteristics of specific outcome that indicate probable success or failure. Ideally, oracles will be self-verifying, allowing automated tests to make an initial assessment of test pass or failure, however, be careful to mitigate the risks inherent in automated results determination.] |
| Required Tools: | [The technique requires the Test Script Automation Tool.] |
| Success Criteria: | [The technique supports the testing of each major screen or window that will be used extensively by the end user.] |
| Special Considerations: | [Not all properties for custom and third-party objects can be accessed.] |

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
 |
#### 5.1.12 Installation Testing

[Installation testing has two purposes. The first is to ensure that the software can be installed under different conditionssuch as a new installation, an upgrade, and a complete or custom installationunder normal and abnormal conditions. Abnormal conditions include insufficient disk space, lack of privilege to create directories, and so on. The second purpose is to verify that, once installed, the software operates correctly. This usually means running a number of the tests that were developed for Function Testing.]

| Technique Objective: | [Exercise the installation of the target-of-test onto each required hardware configuration under the following conditions to observe and log installation behavior and configuration state changes:
- new installation: a new machine, never installed previously with &lt;Project Name&gt;
- update: a  machine previously installed &lt;Project Name&gt;, same version
- update: a machine previously installed &lt;Project Name&gt;, older version]
 |
| --- | --- |
| Technique: |
- [Develop automated or manual scripts to validate the condition of the target machine.
  - new: never installed
  - same or older version already installed
- Launch or perform installation.
- Using a predetermined subset of Function Test scripts, run the transactions.]
 |
| Oracles: | [Outline one or more strategies that can be used by the technique to accurately observe the outcomes of the test. The oracle combines elements of both the method by which the observation can be made and the characteristics of specific outcome that indicate probable success or failure. Ideally, oracles will be self-verifying, allowing automated tests to make an initial assessment of test pass or failure, however, be careful to mitigate the risks inherent in automated results determination.] |
| Required Tools: | [The technique requires the following tools:
- base configuration imager and restorer
- installation monitoring tools (registry, hard disk, CPU, memory, and so on)]
 |
| Success Criteria: | [The technique supports the testing of the installation of the developed product in one or more installation configurations.] |
| Special Considerations: | [What &lt;Project Name&gt; transactions should be selected to comprise a confidence test that &lt;Project Name&gt; application has been successfully installed and no major software components are missing?] |

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

[In this section, list the various artifacts that will be created by the test effort that are useful deliverables to the various stakeholders of the test effort. Don&#39;t list all work products; only list those that give direct, tangible benefit to a stakeholder and those by which you want the success of the test effort to be measured.]

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
n/a

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

The following table sets forth the system resources for the test effort presented in this _Test Plan_.

[The specific elements of the test system may not be fully understood in early iterations, so expect this section to be completed over time. We recommend that the system simulates the production environment, scaling down the concurrent access and database size, and so forth, if and where appropriate.]

[**Note** :  Add or delete items as appropriate.]

| **System Resources** |
| --- |
| **Resource** | **Quantity** | **Name and Type** |
| Database Server |   |   |
| —Network or Subnet |   | TBD |
| —Server Name |   | TBD |
| —Database Name |   | TBD |
| Client Test PCs |   |   |
| —Include special configuration requirements |   | TBD |
| Test Repository |   |   |
| —Network or Subnet |   | TBD |
| —Server Name |   | TBD |
| Test Development PCs |   | TBD |

### 9.2 Base Software Elements in the Test Environment

The following base software elements are required in the test environment for this _Test Plan_.

[Note:  Add or delete items as appropriate.]

| **Software Element Name** | **Version** | **Type and Other Notes** |
| --- | --- | --- |
| NT Workstation |   | Operating System |
| Windows 2000 |   | Operating System |
| Internet Explorer |   | Internet Browser |
| Netscape Navigator |   | Internet Browser |
| MS Outlook |   | eMail Client software |
| Network Associates McAfee Virus Checker |   | Virus Detection and Recovery Software |

### 9.3 Productivity and Support Tools

The following tools will be employed to support the test process for this _Test Plan_.

[Note:  Add or delete items as appropriate.]

| **Tool Category or Type** | **Tool Brand Name** | **Vendor or In-house** | **Version** |
| --- | --- | --- | --- |
| Test Management |   |   |   |
| Defect Tracking |   |   |   |
| ASQ Tool for functional testing |   |   |   |
| ASQ Tool for performance testing |   |   |   |
| Test Coverage Monitor or Profiler |   |   |   |
| Project Management |   |   |   |
| DBMS tools |   |   |   |

### 9.4 Test Environment Configurations

The following Test Environment Configurations needs to be provided and supported for this project.

| **Configuration Name** | **Description** | **Implemented in Physical Configuration** |
| --- | --- | --- |
| Average user configuration |   |   |
| Minimal configuration supported |   |   |
| Visually and mobility challenged |   |   |
| International Double Byte OS |   |   |
| Network installation (not client) |   |   |

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

[Identify the key schedule milestones that set the context for the Testing effort. Avoid repeating too much detail that is documented elsewhere in plans that address the entire project.]

| **Milestone** | **Planned      Start Date** | **Actual         Start Date** | **Planned        End Date** | **Actual           End Date** |
| --- | --- | --- | --- | --- |
| Iteration Plan agreed |   |   |   |   |
| Iteration starts |   |   |   |   |
| Requirements baselined |   |   |   |   |
| Architecture baselined |   |   |   |   |
| User Interface baselined |   |   |   |   |
| First Build delivered to test |   |   |   |   |
| First Build accepted into test |   |   |   |   |
| First Build test cycle finishes |   |   |   |   |
| [Build Two will not be tested] |   |   |   |   |
| Third Build delivered to test |   |   |   |   |
| Third Build accepted into test |   |   |   |   |
| Third Build test cycle finishes |   |   |   |   |
| Fourth Build delivered to test |   |   |   |   |
| Fourth Build accepted into test |   |   |   |   |
| Iteration Assessment review |   |   |   |   |
| Iteration ends |   |   |   |   |

# 12. Risks, Dependencies, Assumptions, and Constraints

[List any risks that may affect the successful execution of this **Test Plan** , and identify mitigation and contingency strategies for each risk. Also indicate a relative ranking for both the likelihood of occurrence and the impact if the risk is realized.]

| **Risk** | **Mitigation Strategy** | **Contingency (Risk is realized)** |
| --- | --- | --- |
| Prerequisite entry criteria is not met. | &lt;Tester&gt; will define the prerequisites that must be met before Load Testing can start. &lt;Customer&gt; will endeavor to meet prerequisites indicated by &lt;Tester&gt;. |
- Meet outstanding prerequisites
- Consider Load Test Failure
 |
| Test data proves to be inadequate. | &lt;Customer&gt; will ensure a full set of suitable and protected test data is available. &lt;Tester&gt; will indicate what is required and will verify the suitability of test data. |
- Redefine test data
- Review Test Plan and modify
- components (that is, scripts)
- Consider Load Test Failure
 |
| Database requires refresh. | &lt;System Admin&gt; will endeavor to ensure the Database is regularly refreshed as required by &lt;Tester&gt;. |
- Restore data and restart
- Clear Database
 |

[List any dependencies identified during the development of this **Test Plan** that may affect its successful execution if those dependencies are not honored. Typically these dependencies relate to activities on the critical path that are prerequisites or post-requisites to one or more preceding (or subsequent) activities You should consider responsibilities you are relying on other teams or staff members external to the test effort completing, timing and dependencies of other planned tasks, the reliance on certain work products being produced.]

| **Dependency between** | **Potential Impact of Dependency** | **Owners** |
| --- | --- | --- |
|   |   |   |
|   |   |   |
|   |   |   |

[List any assumptions made during the development of this **Test Plan** that may affect its successful execution if those assumptions are proven incorrect. Assumptions might relate to work you assume other teams are doing, expectations that certain aspects of the product or environment are stable, and so forth].

| **Assumption to be proven** | **Impact of Assumption being incorrect** | **Owners** |
| --- | --- | --- |
|   |   |   |
|   |   |   |
|   |   |   |

[List any constraints placed on the test effort that have had a negative effect on the way in which this **Test Plan** has been approached.]

| **Constraint on** | **Impact Constraint has on test effort** | **Owners** |
| --- | --- | --- |
|   |   |   |
|   |   |   |
|   |   |   |
## 13. Management Process and Procedures

[Outline what processes and procedures are to be used when issues arise with the **Test Plan** and its enactment.]

### 13.1 Measuring and Assessing the Extent of Testing

[Outline the measurement and assessment process to be used to track the extent of testing.]
### 13.2 Assessing the Deliverables of this Test Plan

[Outline the assessment process for reviewing and accepting the deliverables of this **Test Plan**]

### 13.3 Problem Reporting, Escalation, and Issue Resolution

[Define how process problems will be reported and escalated, and the process to be followed to achieve resolution.]

### 13.4 Managing Test Cycles

[Outline the management control process for a test cycle.]
### 13.5 Traceability Strategies

[Consider appropriate traceability strategies for:

- Coverage of Testing against Specifications — enables measurement the extent of testing
- Motivations for Testing — enables assessment of relevance of tests to help determine whether to maintain or retire tests
- Software Design Elements — enables tracking of subsequent design changes that would necessitate rerunning tests or retiring them
- Resulting Change Requests — enables the tests that discovered the need for the change to be identified and re-run to verify the change request has been completed successfully]

### 13.6 Approval and Signoff

[Outline the approval process and list the job titles (and names of current incumbents) that initially must approve the plan, and sign off on the plans satisfactory execution.]

