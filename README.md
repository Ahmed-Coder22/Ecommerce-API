Ecommerce-API
A robust, scalable RESTful Web API for an E-commerce platform built with .NET 8 and ASP.NET Core. This backend handles catalog management, multi-image product handling, shopping cart, order processing, and user authentication using clean code practices and SOLID design principles.

🚀 Key Features
Product & Category Management: Full CRUD operations for categories and products.

Multi-Image Upload: Support for uploading, updating, and managing multiple high-resolution images per product.

Authentication & Authorization: Secure user authentication using ASP.NET Core Identity and JWT (JSON Web Tokens) with role-based access control (Admin, Customer).

Shopping Cart & Redis Caching: Fast and responsive shopping cart operations using Redis in-memory caching.

Order Processing System: Comprehensive order lifecycle management with status tracking (Pending, Processing, Completed, Cancelled).

Pagination, Filtering & Sorting: Dynamic search queries, category filters, price ranges, and page indexing for product lists.

Global Error Handling: Custom middleware delivering standardized API response structures (ProblemDetails).

🏗️ Architecture & Design Patterns
The architecture prioritizes maintainability, testability, and separation of concerns:

SOLID Principles: Applied throughout the entire domain and service layers.

Repository & Unit of Work Patterns: Decouples business logic from data access logic.

Data Transfer Objects (DTOs): Encapsulates API payloads and prevents over-posting.

AutoMapper / Mapster: For object-to-object mapping between entities and DTOs.

FluentValidation: Validates incoming request payloads before reaching controller actions.

🛠️ Tech Stack
Framework: .NET 8 (ASP.NET Core Web API)

Language: C# 12

Database: Microsoft SQL Server

ORM: Entity Framework Core 8

Caching: Distributed Redis Cache

Security: ASP.NET Core Identity, JWT Bearer Token

Documentation: Swagger UI (Swashbuckle)
