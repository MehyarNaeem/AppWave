# AppWave E-Commerce API

A modern e-commerce API built with ASP.NET Core 8.0, featuring JWT authentication, role-based authorization, and a clean architecture approach.

## Features

- JWT Authentication
- Role-based Authorization (Admin, User roles)
- Clean Architecture
- Entity Framework Core with SQL Server
- AutoMapper for object mapping
- Swagger/OpenAPI documentation
- Weather Forecast API example

## Project Structure

- **AppWave.ECommerce.API**: Web API project
- **AppWave.ECommerce.Business**: Business logic layer
- **AppWave.ECommerce.DataAccess**: Data access layer
- **AppWave.ECommerce.Domain**: Domain models and interfaces

## Prerequisites

- .NET 8.0 SDK
- SQL Server
- Visual Studio 2022 or VS Code

## Getting Started

1. Clone the repository
```bash
git clone https://github.com/yourusername/AppWave.ECommerce.git
```

2. Update the connection string in `appsettings.json`
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=your_server;Database=AppWaveECommerce;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

3. Run the application
```bash
cd AppWave.ECommerce.API
dotnet run
```

4. Access Swagger UI at `https://localhost:7001/swagger`

## API Endpoints

### Authentication
- POST `/api/auth/login` - User login
- POST `/api/auth/register` - User registration

### Products
- GET `/api/products` - Get all products (paged)
- GET `/api/products/{id}` - Get product by ID
- POST `/api/products` - Create product (Admin only)
- PUT `/api/products/{id}` - Update product (Admin only)
- DELETE `/api/products/{id}` - Delete product (Admin only)

### Weather Forecast
- GET `/api/weatherforecast/get` - Get weather forecast

## Contributing

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## License

This project is licensed under the MIT License - see the LICENSE file for details. 