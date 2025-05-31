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
  },
  "Jwt": {
    "Key": "YourSecretKeyHere_Minimum16Characters",
    "Issuer": "https://localhost:7001",
    "Audience": "https://localhost:7001"
  }
}
```

3. Run the application
```bash
cd AppWave.ECommerce.API
dotnet run
```

4. Access Swagger UI at `https://localhost:7001/swagger`

## API Usage Guide

### Authentication

#### Register a New User
```http
POST /api/auth/register
Content-Type: application/json

{
  "email": "user@example.com",
  "password": "YourPassword123!",
  "firstName": "John",
  "lastName": "Doe"
}
```

Response:
```json
{
  "isSuccess": true,
  "token": "eyJhbGciOiJIUzI1NiIs...",
  "user": {
    "id": "guid",
    "email": "user@example.com",
    "firstName": "John",
    "lastName": "Doe",
    "role": "User"
  }
}
```

#### Login
```http
POST /api/auth/login
Content-Type: application/json

{
  "email": "user@example.com",
  "password": "YourPassword123!"
}
```

Response:
```json
{
  "isSuccess": true,
  "token": "eyJhbGciOiJIUzI1NiIs...",
  "user": {
    "id": "guid",
    "email": "user@example.com",
    "firstName": "John",
    "lastName": "Doe",
    "role": "User"
  }
}
```

### Products

#### Get All Products (Paged)
```http
GET /api/products?pageNumber=1&pageSize=10
Authorization: Bearer your_jwt_token
```

Response:
```json
{
  "items": [
    {
      "id": "guid",
      "name": "Product Name",
      "description": "Product Description",
      "price": 99.99,
      "stock": 100
    }
  ],
  "totalCount": 50,
  "pageNumber": 1,
  "pageSize": 10,
  "totalPages": 5,
  "hasPreviousPage": false,
  "hasNextPage": true
}
```

#### Get Product by ID
```http
GET /api/products/{id}
Authorization: Bearer your_jwt_token
```

#### Create Product (Admin Only)
```http
POST /api/products
Authorization: Bearer your_jwt_token
Content-Type: application/json

{
  "name": "New Product",
  "description": "Product Description",
  "price": 99.99,
  "stock": 100
}
```

#### Update Product (Admin Only)
```http
PUT /api/products/{id}
Authorization: Bearer your_jwt_token
Content-Type: application/json

{
  "name": "Updated Product",
  "description": "Updated Description",
  "price": 89.99,
  "stock": 50
}
```

#### Delete Product (Admin Only)
```http
DELETE /api/products/{id}
Authorization: Bearer your_jwt_token
```

### Weather Forecast

#### Get Weather Forecast
```http
GET /api/weatherforecast/get
```

Response:
```json
{
  "2024-03-20": {
    "temperatureC": 25,
    "temperatureF": 77,
    "summary": "Warm"
  },
  "2024-03-21": {
    "temperatureC": 30,
    "temperatureF": 86,
    "summary": "Hot"
  }
}
```

## Error Handling

The API uses standard HTTP status codes:
- 200: Success
- 201: Created
- 400: Bad Request
- 401: Unauthorized
- 403: Forbidden
- 404: Not Found
- 500: Internal Server Error

Error Response Format:
```json
{
  "statusCode": 400,
  "message": "Error message here",
  "details": "Additional error details if available"
}
```

## Security

- All endpoints except `/api/auth/register` and `/api/auth/login` require JWT authentication
- Admin-only endpoints require the "Admin" role
- Passwords are hashed using BCrypt
- JWT tokens expire after 7 days

## Contributing

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## License

This project is licensed under the MIT License - see the LICENSE file for details. 