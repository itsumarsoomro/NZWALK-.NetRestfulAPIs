# NZWALK .NET RESTful APIs

A collection of .NET RESTful APIs that provides information on New Zealand's walks, trails, and natural landmarks. This project includes secure, reliable endpoints to manage and access walk data for applications featuring New Zealand's natural beauty.

## Table of Contents

- [Features](#features)
- [Technologies](#technologies)
- [Setup](#setup)
- [Usage](#usage)
- [API Endpoints](#api-endpoints)
- [Contributing](#contributing)
- [License](#license)

## Features

- **CRUD Operations:** Full Create, Read, Update, and Delete functionality for walk and trail data.
- **Secure Authentication & Authorization:** JWT-based security for protected endpoints.
- **Data Validation:** Ensures incoming data meets required structure and integrity.
- **Error Handling:** Consistent error responses for seamless client-side handling.
- **Scalability:** Designed to scale with ease for additional endpoints and data sources.

## Technologies

- **.NET Core 6.0** – Framework for building robust APIs
- **Entity Framework Core** – ORM for database management
- **SQL Server** – Database for storing walk, trail, and region data
- **JWT Authentication** – Secure token-based access control

## Setup

### Prerequisites

- [.NET SDK 6.0](https://dotnet.microsoft.com/download/dotnet/6.0)
- SQL Server (local or cloud instance)
- Postman or any REST client (for testing)

### Installation

1. **Clone the repository:**
   ```bash
   git clone https://github.com/itsumarsoomro/NZWALK-.NetRestfulAPIs.git
   cd NZWALK-.NetRestfulAPIs
   ```

2. **Install Dependencies:**
   ```bash
   dotnet restore
   ```

3. **Database Setup:**
   * Update the SQL Server connection string in `appsettings.json`:
     ```json
     {
       "ConnectionStrings": {
         "DefaultConnection": "Server=YOUR_SERVER;Database=NZWalksDB;Trusted_Connection=True;"
       }
     }
     ```
   * Run migrations to create the database schema:
     ```bash
     dotnet ef database update
     ```

4. **Run the Application:**
   ```bash
   dotnet run
   ```
   The API will be running at `http://localhost:5000`.

## Usage

Use Postman or any REST client to test the API. Refer to the API Endpoints section for routes and parameters.

### Authentication

The API uses JWT tokens for secure access. Obtain a token from the login endpoint and include it as a Bearer token in your requests.

## API Endpoints

### Authentication
* `POST /api/auth/login` - Authenticate and receive a JWT token.

### Walks
* `GET /api/walks` - Get all walks.
* `GET /api/walks/{id}` - Get details for a specific walk.
* `POST /api/walks` - Create a new walk (requires authentication).
* `PUT /api/walks/{id}` - Update a walk (requires authentication).
* `DELETE /api/walks/{id}` - Delete a walk (requires authentication).

### Trails
* `GET /api/trails` - List all trails.
* `GET /api/trails/{id}` - Get details for a specific trail.
* `POST /api/trails` - Add a new trail (requires authentication).
* `PUT /api/trails/{id}` - Update a trail (requires authentication).
* `DELETE /api/trails/{id}` - Remove a trail (requires authentication).

### Regions
* `GET /api/regions` - List all regions.
* `GET /api/regions/{id}` - Retrieve details for a specific region.

## Contributing

Contributions are welcome! To contribute:

1. **Fork the repository**
2. **Create a new feature branch:**
   ```bash
   git checkout -b feature-name
   ```
3. **Commit your changes:**
   ```bash
   git commit -m "Add feature description"
   ```
4. **Push the branch:**
   ```bash
   git push origin feature-name
   ```
5. **Open a pull request**

## License

This project is licensed under the MIT License. See the LICENSE file for details.
