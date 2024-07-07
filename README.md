# Shortened URL Application

🚀 Welcome to the Shortened URL Application repository! 🌐

## Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
  - [Database Setup](#database-setup)
  - [Running the Application](#running-the-application)
- [Usage](#usage)
- [Contributing](#contributing)
- [Resources](#resources)
- [License](#license)

## Overview

The Shortened URL Application leverages a modern .NET Core 8 framework to provide a sleek and efficient solution for URL shortening. Designed with Clean Architecture, this application ensures a robust and scalable codebase. By adopting the Minimal API, the application offers high performance and maintainability. 

The application employs the following advanced design patterns and tools to enhance functionality and code organization:
- **Clean Architecture**: A modular architecture that separates concerns and promotes a clear separation of layers.
- **Repository Design Pattern**: Manages data access with repositories, ensuring a clean and abstracted data layer.
- **Mediator Design Pattern**: Facilitates communication between components, improving decoupling and flexibility.
- **CQRS (Command Query Responsibility Segregation) Design Pattern**: Differentiates between commands and queries to optimize performance and scalability.
- **Mapster**: Efficiently maps entities to Data Transfer Objects (DTOs) for smooth data manipulation.
- **Fluent Validation**: Validates incoming requests with an intuitive and fluent API.
- **JWT for Authentication and Authorization**: Ensures secure access and user identity verification.
- **Role-Based Authorization**: Provides fine-grained access control based on user roles.

## Features

- **Clean Architecture**: A structured and modular application design promoting separation of concerns.
- **Repository Design Pattern**: Abstracts data access, making it more maintainable and testable.
- **Minimal API**: Utilizes lightweight endpoints for efficient request handling.
- **Code First Approach**: Defines the database schema through code, allowing easy migrations and updates.
- **SQL Server**: Stores URLs in a robust and reliable database.
- **Carter Nugget Package**: Simplifies the Minimal API module organization.
- **Mapster for Entity Mapping**: Streamlines data transfer between entities and DTOs.
- **Fluent Validation**: Validates incoming requests to ensure data integrity.
- **JWT Authentication**: Secures endpoints with JSON Web Tokens.
- **Role-Based Authorization**: Controls access based on user roles.

## Getting Started

### Prerequisites

Ensure you have the following tools installed:

- [.NET Core 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or any compatible database provider.

### Installation

1. **Clone the repository**:

   ```bash
   git clone https://github.com/MohammadAhmadAlBourm/UrlShortener.git
   cd shortened-url-app
   ```

### Database Setup

2. **Configure the database connection**:

   - Open `appsettings.json` and update the `ConnectionStrings` section with your SQL Server details.

3. **Apply database migrations**:

   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

### Running the Application

4. **Start the application**:

   ```bash
   dotnet run
   ```

5. **Access the API**:

   Navigate to `http://localhost:7017/swagger` to explore the API documentation and test endpoints.

## Usage

- Interact with the API using the Swagger documentation to shorten URLs and manage them in the SQL Server database.

## Contributing

We welcome contributions! Feel free to fork the repository and submit pull requests to improve the project or fix issues.

## Resources

- [Carter GitHub Repository](https://github.com/CarterCommunity/Carter) for detailed information on using the Carter library.

## License

This project is licensed under the MIT License. For more details, see the [LICENSE](LICENSE) file.
