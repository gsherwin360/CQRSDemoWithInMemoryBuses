# CQRS Pattern Demo with In-Memory Command and Query Buses

In this demo API, I've implemented the Command Query Responsibility Segregation (CQRS) pattern using custom in-memory command and query buses in .NET Web API. The primary aim is to demonstrate the clear separation of concerns between command (write) and query (read) operations, achieved without relying on third-party CQRS libraries.

## Overview
The CQRS pattern separates the responsibility for handling command (write) operations from query (read) operations. By separating commands and queries, we can optimize and scale them independently. This is achieved by using distinct models and handlers for each type of operation. Overall, this approach helps in making the system easier to maintain, test, and evolve.

## Solution Structure
- **Commands:** Contains interfaces, implementations, and handlers for command operations.
- **Queries:** Includes interfaces, implementations, and handlers for query operations.
- **Buses:** Implements in-memory command and query buses.
- **Domain:** Houses domain entities and business logic.
- **Controllers:** Contains API controllers for request handling.
- **Services:** Implements services for configuring command and query buses in the DI container.

## Features
- **Command Handling:** Commands are sent to the command bus, where they are routed to the appropriate command handler for execution.
- **Query Handling:** Queries are sent to the query bus, which forwards them to the corresponding query handler to retrieve data.
- **In-Memory Implementation:** The command and query buses are implemented as in-memory services, simplifying setup and demonstrating the pattern without relying on third-party CQRS libraries.

## Example Scenario
Consider an e-commerce platform where users engage in various activities such as browsing products, adding items to their cart, and more. During peak usage periods, such as flash sales, the database server can become overloaded with read queries, potentially causing delays in write operations. The CQRS pattern addresses this challenge by segregating read and write operations, enabling the system to optimize the handling of each type of operation independently. This separation ensures that read-heavy queries do not impact the responsiveness of write operations, thus maintaining overall system performance even during high-traffic periods.

## Development Prerequisites
Before diving into development with this project, ensure you have the following prerequisites:
- **Development Environment:** Either Visual Studio 2022 (IDE) or Visual Studio Code (Source-code editor)
- **.NET 8:** Required framework version for building and running the project

## Getting Started
To run the API locally, follow these steps:
1. Clone this repository to your local machine.
2. Open the project in your preferred development environment.
3. Build and run the project.
4. Access the API documentation via Swagger in your web browser while the API is running to explore available endpoints.
