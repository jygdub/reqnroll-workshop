# Reqnroll Workshop

---

## Overview

This repository hosts the Reqnroll workshop, demonstrated through a series of projects that build incrementally on one another. Each project adds new concepts and serves as the solution reference for its predecessor.

## Workshop Structure
> **Note:** The 'Core' project contains the business logic being tested, domain models, and some mock implementations.

1. **A.BasicImplementation.Tests**

    * Outline of a scenario (not yet implemented)
    * Goal: Get the scenario running

2. **B.AdditionalScenarios.Tests**

    * Implements **A.BasicImplementation.Tests**
    * Goal: Add scenarios, refactor using Background, Tables, and Scenario Outlines

3. **C.Hooks.Tests**

    * Implements **B.AdditionalScenarios.Tests**
    * Goal: Introduce Hooks to clean up test data after execution

4. **D.AdvancedConcepts.Tests**

    * Implements **C.Hooks.Tests**
    * Goal: Apply advanced features (StepArgumentTransformations, Table CreateInstance/CreateSet, Retrievers) to streamline code

5. **E.Final.Tests**

    * Implements **D.AdvancedConcepts.Tests**
    * Goal: Fix the failing test and use TDD to change the business logic.

> **Note:** Each project demonstrates the “next-step” solution for the previous one.

## Prerequisites

* [.NET 8 SDK (or later)](https://dotnet.microsoft.com/download)
* Preferred IDE configured for Reqnroll—see [Setup an IDE for Reqnroll](https://docs.reqnroll.net/latest/installation/setup-ide.html)

## Getting Started

1. Install the .NET 8 SDK (or newer).
2. Configure your IDE according to the Reqnroll documentation.
3. Clone this repository:

   ```bash
   git clone https://github.com/your-org/reqnroll-workshop.git
   ```
4. Open the solution file:

   ```
   ReqnrollWorkshop.sln
   ```