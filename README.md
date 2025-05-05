# ToDoApp - Blazor & Clean Architecture Learning Project

![Blazor](https://img.shields.io/badge/blazor-%235C2D91.svg?style=for-the-badge&logo=blazor&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![MudBlazor](https://img.shields.io/badge/MudBlazor-00BCD4?style=for-the-badge)

## 📝 Project Overview

This project was developed as a learning exercise to:

- Gain hands-on experience with **Blazor WebAssembly**
- Implement **MudBlazor** component library in a real application
- Strengthen my understanding of:
  - **Clean Architecture** principles
  - **CQRS** pattern implementation
  - **MediatR** library usage
  - **Entity Framework Core** data access

## 🛠️ Technical Stack

### Core Technologies

- **Blazor WebAssembly** (ASP.NET Core Hosted)
- **.NET 8**
- **MudBlazor** (Component Library)
- **MediatR** (CQRS implementation)
- **Entity Framework Core** (Data Access)
- **AutoMapper** (Object-Object Mapping)

### Architectural Patterns

- Clean Architecture (Layered approach)
- CQRS (Command Query Responsibility Segregation)
- Repository Pattern (with EF Core)
- Dependency Injection

## 🚀 Features Implemented

### Application Functionality

- Task management (CRUD operations)
- Category system with color coding
- Priority-based task organization
- Responsive UI with MudBlazor components
- Client-side form validation

### Technical Highlights

- Proper separation of concerns:
  - `Application` (Core business logic)
  - `Infrastructure` (Persistence)
  - `Web` (Presentation)
- CQRS pattern with MediatR
- Domain-driven design elements
- Centralized exception handling

## 🔧 Known Issues & TODOs

### Refactoring Needed

- [ ] **Centralize Snackbar notifications** (Currently scattered through components)
- [ ] Refactor duplicate validation logic
- [ ] Improve error handling consistency
- [ ] Optimize EF Core queries

### Features to Add

- [ ] User authentication/authorization
- [ ] Task due date reminders
- [ ] Data export/import
- [ ] Advanced filtering/sorting

## 🏗️ Project Structure

ToDoApp\
├── ToDoApp.Application/ # Core business logic\
│ ├── Features/\
│ │ ├── Tasks/ # Task-related CQRS\
│ │ └── Categories/ # Category-related CQRS\
│ └── Shared/ # Common interfaces\
├── ToDoApp.Infrastructure/ # Data access\
│ └── Persistence/ # EF Core configurations\
├── ToDoApp.Web/ # Blazor WebAssembly\
│ ├── Pages/ # UI components\
│ ├── Shared/ # Shared components\
│ └── wwwroot/ # Static files\
└── ToDoApp.sln # Solution file

## 🧠 Learning Outcomes

Through this project, I've gained:

- Practical experience with Blazor component lifecycle
- Understanding of MudBlazor's component model
- Implementation of Clean Architecture in Blazor
- Better grasp of CQRS with MediatR
- Improved EF Core data modeling skills
