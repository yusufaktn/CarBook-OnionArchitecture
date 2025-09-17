# Qwen Code - Project Tracking

## Project Information
- **Project Name**: CarBook
- **Framework**: .NET 8
- **Architecture**: Onion Architecture with CQRS and Mediator pattern
- **Solution File**: CarBook.sln
- **Date**: 17 Eylül 2025

rules:
  - name: "General"
    description: "AI must follow these general coding principles."
    items:
      - "Generated code should NOT be blocked by linting or strict error validation. (Skip runtime validation)"
      - "Always add short, clear comments explaining the purpose of classes, methods, and handlers."
      - "Do NOT auto-fix architecture decisions. Respect Onion Architecture + CQRS + Mediator + Repository."
      - "Preserve project namespaces and solution structure (CarBook.Api, CarBook.Application, CarBook.Domain, CarBook.Persistence)."
      - "Prefer readability over strict correctness; developer will handle debugging if needed."

  - name: "CQRS & Mediator"
    description: "Ensure CQRS pattern with Mediator is respected."
    items:
      - "Queries go into CarBook.Application/Queries."
      - "Commands go into CarBook.Application/Commands."
      - "Handlers must implement IRequestHandler<TRequest, TResponse> from Mediator."
      - "Add comments like: // Handles user login query or // Executes create car command."

  - name: "Domain Layer"
    description: "Protect the Domain model."
    items:
      - "Entities stay in CarBook.Domain/Entities."
      - "Do NOT reference Infrastructure or API inside Domain."
      - "Add comments explaining entity properties (e.g., // License plate of the car)."

  - name: "Persistence Layer"
    description: "Repository & DbContext rules."
    items:
      - "Repositories must implement interfaces from CarBook.Domain."
      - "DbContext should be in CarBook.Persistence."
      - "Migration files must not be altered unless explicitly requested."

  - name: "API Layer"
    description: "Controller & Endpoint rules."
    items:
      - "Controllers must be placed in CarBook.Api/Controllers."
      - "Each controller action must call Application layer via Mediator."
      - "Add comments like: // Endpoint to create a new car."

