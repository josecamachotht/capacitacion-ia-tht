# Supermarket Products API - Copilot Instructions

This is a .NET Web API project for managing supermarket products. The project follows clean architecture principles and includes:

## Project Structure
- **Controllers**: REST API endpoints for product management
- **Models**: Product entities and data models  
- **Services**: Business logic layer
- **Repositories**: Data access layer with Entity Framework Core
- **DTOs**: Data Transfer Objects for API requests/responses

## Key Features
- Product CRUD operations (GET, POST, PUT, DELETE)
- Entity Framework Core for database operations
- Repository pattern implementation
- Input validation and error handling
- Swagger/OpenAPI documentation
- Logging and CORS configuration

## Development Guidelines
- Follow .NET naming conventions
- Use async/await patterns for database operations
- Implement proper error handling and validation
- Maintain separation of concerns between layers
- Use dependency injection for service registration