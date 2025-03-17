# BaseAPI.DomainDrivenDesign.WebApi

🚀 **A .NET 8 API Template with Domain-Driven Design (DDD) Architecture**  

This repository provides a **base project** for building .NET 8 APIs using **DDD (Domain-Driven Design)** principles.
It includes a structured architecture, database migration setup, and pre-configured essential packages like **Entity Framework, AutoMapper, Swagger** and **DbUp** for SQL Server migrations.

## 📂 Project Structure  

```plaintext
.
└── BaseAPI.DomainDrivenDesign/
    ├── database/                          # Database migration project
    │   └── BaseAPI.DomainDrivenDesign.Database
    ├── src/                               # Source code following DDD principles
    │   ├── BaseAPI.DomainDrivenDesign.Application    # Application logic (services, DTOs)
    │   ├── BaseAPI.DomainDrivenDesign.Domain         # Domain entities & repository interfaces
    │   ├── BaseAPI.DomainDrivenDesign.Infrastructure # Infrastructure (EF, repositories implementations)
    │   └── BaseAPI.DomainDrivenDesign.WebApi         # API entry point (controllers)
    └── test/                              # (Tests to be implemented)
```


## 🚀 Getting Started  

1. **Configure the Database Connection**  
   - Set your connection string in the [Database settings](./BaseAPI.DomainDrivenDesign/database/BaseAPI.DomainDrivenDesign.Database/App_Config/Database.settings.json).  
   - Also, update in the [Web API settings](./BaseAPI.DomainDrivenDesign/src/BaseAPI.DomainDrivenDesign.WebApi/appsettings.json).  

2. **Run Database Migrations**  
   - Execute the database project to apply migration scripts to your database.  

3. **Start the Web API**  
   - Run the Web API project, and it will automatically launch [Swagger UI](https://localhost:7164/swagger/index.html).  

4. **You're all set!**  
   - Your API is now running—start building your features! 🚀  

