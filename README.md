Project Structure
1. Core: Contains business logic and domain entities.
  Purpose: Contains domain entities, value objects, and domain logic.
  Dependencies: Should not depend on any other project.
  Contents: Entities, domain services, interfaces.
2. Application: Contains application logic, including interfaces and use cases.
  Purpose: Contains application logic, use cases, DTOs, and interfaces.
  Dependencies: Depends on Core. Interfaces defined here can be implemented in Infrastructure.
  Contents: Use cases, application services, DTOs, interface definitions.
3. Infrastructure: Contains implementation details, such as data access with Dapper.
  Purpose: Handles data access, external service integrations, and other infrastructure concerns.
  Dependencies: Depends on Core and Application. Implements the interfaces defined in Application.
  Contents: Dapper repositories, external API clients, database migrations, configurations.
4. Application (Web Project or MVC Project): 
  Purpose: Handles the presentation layer for a web application, such as controllers, views, and static content.
  Dependencies: Depends on Application and possibly Infrastructure for services and repositories.
  Contents: MVC controllers, Razor views, static files (CSS, JavaScript).
5.WebApi: The entry point for the application, such as a Web API project.
  Purpose: Exposes the application’s functionality via a RESTful API.
  Dependencies: Depends on Application and possibly Infrastructure.
  Contents: API controllers, endpoints, Swagger configuration.
