
# Employee Management System 






## Overview
This is a RESTful API built with .NET 8 to manage employee data within an organization. It supports CRUD operations, follows SOLID principles, and uses JWT authentication for secure access.

## Features

- **CRUD Operations**: Create, Read, Update, Delete employees.
- **Authentication**: JWT-based authentication for securing endpoints.\
- **Entity Framework Core**: SQL database integration with EF Core.\
- **Dependency Injection**: Modular architecture for maintainability.\
- **Swagger Documentation**: Auto-generated API documentation.
 


## Technologies Used
- .NET 8 Web API
- C#
- Entity Framework Core
- SQL Server
- JWT Authentication
- Swagger
## Project Structure

|  EmployeeManagement ||
| :-------- | :------- |
| Controllers/  | ` # API Controllers`|
| Services/  | ` # Business Logic Layer`|
| Repositories/   | `# Data Access Layer`|
| Models/   | ` # Data Models`|
| DTOs/   | ` # Data Transfer Objects`|
| Data/    | `# DbContext and Migrations`|
| Program.cs   | `# Application Entry Point`|
| appsettings.json   | ` # Configuration Settings`|


## Installation

- .NET 8 SDK
- SQL Server
- Entity Framework Core

**Setup Instructions**

- Clone the repository:
```bash
 git clone https://github.com/your-repo/EmployeeManagementAPI.git
 cd EmployeeManagementAPI
```

- Install required dependencies:
```bash
dotnet restore
```

- Add EF Core design package:
```bash
dotnet add package Microsoft.EntityFrameworkCore.Design
```

- Apply Migrations:
```bash
dotnet ef migrations add InitialCreate
```
```bash
dotnet ef database update
```

- Run the API:
```bash
dotnet run
```
- Open Swagger UI at::
```bash
http://localhost:5103/swagger/index.html
```
    
## API Endpoints

### Authentication

- `POST /api/auth/login` - Authenticate and get JWT token

### Employee Management

- `GET /api/employees` - Get all employees

- `POST /api/employees` - Create a new employee

- `PUT /api/employees/{id}` - Update an employee

- `DELETE /api/employees/{id}` - Delete an employee
