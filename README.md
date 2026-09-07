# 🛒 Ecommerce-API

A robust, scalable **RESTful Web API** for an E-commerce platform built with **.NET 8** and **ASP.NET Core**. This backend handles catalog management, multi-image product handling, shopping cart, order processing, and user authentication using clean code practices and SOLID design principles.

<p align="left">
  <img src="https://img.shields.io/badge/.NET-8.0-512BD4?style=flat&logo=dotnet" alt=".NET 8">
  <img src="https://img.shields.io/badge/C%23-12-239120?style=flat&logo=csharp" alt="C# 12">
  <img src="https://img.shields.io/badge/EF%20Core-8-512BD4?style=flat" alt="EF Core 8">
  <img src="https://img.shields.io/badge/SQL%20Server-CC2927?style=flat&logo=microsoftsqlserver&logoColor=white" alt="SQL Server">
  <img src="https://img.shields.io/badge/Redis-DC382D?style=flat&logo=redis&logoColor=white" alt="Redis">
  <img src="https://img.shields.io/badge/JWT-Auth-000000?style=flat&logo=jsonwebtokens" alt="JWT">
  <img src="https://img.shields.io/badge/Swagger-UI-85EA2D?style=flat&logo=swagger&logoColor=black" alt="Swagger">
</p>

---

## 📋 Table of Contents

- [Key Features](#-key-features)
- [Architecture & Design Patterns](#️-architecture--design-patterns)
- [Tech Stack](#️-tech-stack)
- [Getting Started](#-getting-started)

---

## 🚀 Key Features

| Feature | Description |
|---|---|
| **Product & Category Management** | Full CRUD operations for categories and products. |
| **Multi-Image Upload** | Support for uploading, updating, and managing multiple high-resolution images per product. |
| **Authentication & Authorization** | Secure user authentication using ASP.NET Core Identity and JWT (JSON Web Tokens) with role-based access control (Admin, Customer). |
| **Shopping Cart & Redis Caching** | Fast and responsive shopping cart operations using Redis in-memory caching. |
| **Order Processing System** | Comprehensive order lifecycle management with status tracking (`Pending`, `Processing`, `Completed`, `Cancelled`). |
| **Pagination, Filtering & Sorting** | Dynamic search queries, category filters, price ranges, and page indexing for product lists. |
| **Global Error Handling** | Custom middleware delivering standardized API response structures (`ProblemDetails`). |

---

## 🏗️ Architecture & Design Patterns

The architecture prioritizes **maintainability**, **testability**, and **separation of concerns**:

- **SOLID Principles** — Applied throughout the entire domain and service layers.
- **Repository & Unit of Work Patterns** — Decouples business logic from data access logic.
- **Data Transfer Objects (DTOs)** — Encapsulates API payloads and prevents over-posting.
- **AutoMapper / Mapster** — For object-to-object mapping between entities and DTOs.

---

## 🛠️ Tech Stack

| Category | Technology |
|---|---|
| **Framework** | .NET 8 (ASP.NET Core Web API) |
| **Language** | C# 12 |
| **Database** | Microsoft SQL Server |
| **ORM** | Entity Framework Core 8 |
| **Caching** | Distributed Redis Cache |
| **Security** | ASP.NET Core Identity, JWT Bearer Token |
| **Documentation** | Swagger UI (Swashbuckle) |

---

## ⚡ Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/sql-server) (LocalDB or full instance)
- [Redis](https://redis.io/) instance (local or hosted)

---

<p align="center">Built with ❤️ using .NET 8 and ASP.NET Core</p>
