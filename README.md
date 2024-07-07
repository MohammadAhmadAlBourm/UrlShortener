# Shortened URL Application

🚀 Welcome to the Shortened URL Application repository! 🌐

## Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Application Structure](#application-structure)
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

This application is built using .NET Core 8, utilizing Minimal API and Service Design Pattern for a streamlined and efficient structure. It allows users to generate short URLs from long URLs and store them in a SQL Server database.

## Features

- **Minimal API**: Lightweight HTTP endpoints for optimal performance.
- **Service Design Pattern**: Separation of concerns for maintainable and scalable code.
- **Code First Approach**: Database schema defined in code for easy updates.
- **SQL Server**: Reliable and robust database for URL storage.
- **Carter Nugget Package**: Simplifies Minimal API module structure.

## Application Structure

```
Shortened URL Application
│
├── Modules/         # Minimal API Modules
│   ├── Shortener/
|       ├── Endpoints.cs
│
│
├── Services/            # Business logic services
│   ├── IShortenUrlService.cs
│   └── ShortenUrlService.cs
│
├── Entities/              # Data models
│   └── ShortenedUrl.cs
│
├── Database/            # Database context and migrations
│   ├── ApplicationDbContext.cs
│
├── appsettings.json     # Configuration file including database connection string
│
└── Program.cs           # Entry point for the application
```

## Getting Started

### Prerequisites

Ensure you have the following installed:

- [.NET Core 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or another compatible database provider.

### Installation

1. **Clone the repository**:

   ```bash
   git clone https://github.com/MohammadAhmadAlBourm/UrlShortener.git
   cd shortened-url-app
   ```

### Database Setup

2. **Configure database connection**:

   - Open `appsettings.json` and modify the `ConnectionStrings` section to point to your SQL Server instance.

3. **Run database migrations**:

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

   Navigate to `http://localhost:7017/swagger` for API documentation and interact with the endpoints.

## Usage

- Use the API endpoints documented in Swagger to shorten URLs and manage them in the database.

## Contributing

Contributions are welcome! Please fork the repository and submit pull requests to suggest improvements or fix issues.

## Resources

- [Carter GitHub Repository](https://github.com/CarterCommunity/Carter) for more details on Carter and its usage.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
